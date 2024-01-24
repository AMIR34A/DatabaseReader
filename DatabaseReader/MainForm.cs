using DatabaseReader.Models;
using DatabaseReader.Repositories;
using IronXL;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using Color = System.Drawing.Color;

namespace DatabaseReader;

public partial class MainForm : Form
{
    private readonly IRepository _repository;
    public MainForm()
    {
        InitializeComponent();
        AuthenticationComboBox.DataSource = new string[] { "Windows Authentication", "SQL Server Authentication" };
        _repository = new Repository.Repository(GenerateConnectionString());
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        DatabasesGroupBox.Enabled = false;
        UserNameLabel.Enabled = PasswordLabel.Enabled = false;
        UserNameTextBox.Enabled = PasswordTextBox.Enabled = false;

        var path = Application.StartupPath + "Servers";
        string filePath = path + "\\Servers.json";

        if (Directory.Exists(path) && File.Exists(filePath))
        {
            string jsonData = await File.ReadAllTextAsync(filePath);
            var servers = JsonConvert.DeserializeObject<List<ServerInformation>>(jsonData);
            ServerComboBox.DataSource = servers.Select(server => server.Server).ToList();
        }
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ServerComboBox.Text))
        {
            MessageBox.Show("Please enter server name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (AuthenticationComboBox.Text.Equals("SQL Server Authentication") && (string.IsNullOrEmpty(UserNameTextBox.Text) || string.IsNullOrEmpty(PasswordTextBox.Text)))
        {
            MessageBox.Show("You should enter username and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (RemeberMeCheckBox.Checked)
        {
            var path = Application.StartupPath + "Servers";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filePath = path + "\\Servers.json";
            if (!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
            var jsonData = await File.ReadAllTextAsync(filePath);
            var servers = JsonConvert.DeserializeObject<List<ServerInformation>>(jsonData) ?? new List<ServerInformation>();


            ServerInformation serverInformation = new()
            {
                Server = ServerComboBox.Text,
                Username = UserNameTextBox.Text,
                Password = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(PasswordTextBox.Text)),
                AuthenticationMode = AuthenticationComboBox.Text.Equals("SQL Server Authentication") ? AuthenticationMode.SQLServerAuthentication : AuthenticationMode.WindowsAuthentication
            };

            if (!servers.Contains(serverInformation))
            {
                servers.Add(serverInformation);
                jsonData = JsonConvert.SerializeObject(servers, Formatting.Indented);
                await File.WriteAllTextAsync(filePath, jsonData);
            }
        }

        StatusToolStripLabel.ForeColor = Color.Yellow;
        StatusToolStripLabel.Text = "Connecting";

        _repository.UpdateConnectionString(GenerateConnectionString());
        string sqlQuery = "SELECT name FROM sys.databases";

        using var dataTable = await Task.Run(() => _repository.ExecuteSQLCommandAsync(sqlQuery));
        List<string> databases = new List<string>() { "Choose..." };

        foreach (DataRow row in dataTable.Rows)
            databases.Add(row["name"].ToString());

        DatabasesComboBox.DataSource = databases;
        DatabasesGroupBox.Enabled = true;
        StatusToolStripLabel.ForeColor = Color.Green;
        StatusToolStripLabel.Text = "Connected";
    }

    private async void OpenButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TablesComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
        {
            MessageBox.Show("Please select a database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DataGridView dataGridView = new DataGridView()
        {
            ReadOnly = true,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Dock = DockStyle.Fill,
        };

        var tableData = await GetTableData();
        foreach (DataRow row in tableData.Item1.Rows)
            dataGridView.Columns.Add(row["Column_NAME"].ToString(), row["Column_NAME"].ToString());

        foreach (DataRow row in tableData.Item2.Rows)
        {
            object[] objects = new object[row.ItemArray.Length];

            for (int i = 0; i < row.ItemArray.Length; i++)
                objects[i] = row.ItemArray[i] != DBNull.Value ? row.ItemArray[i] : "-";

            dataGridView.Rows.Add(objects);
        }

        Form databaseShowForm = new Form()
        {
            Height = 500,
            Width = 750,
            StartPosition = FormStartPosition.CenterParent
        };
        databaseShowForm.Controls.Add(dataGridView);
        databaseShowForm.Show();
    }

    private void AuthenticationComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        bool status = ((ComboBox)sender).Text.Equals("SQL Server Authentication") ? true : false;
        UserNameLabel.Enabled = PasswordLabel.Enabled = status;
        UserNameTextBox.Enabled = PasswordTextBox.Enabled = status;
    }

    private async void DatabasesComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        if (((ComboBox)sender).Text.Equals("Choose..."))
            return;

        string sqlQuery = $"SELECT TABLE_SCHEMA, TABLE_NAME FROM {DatabasesComboBox.Text}.INFORMATION_SCHEMA.TABLES";

        using var dataTable = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        List<string> tables = new List<string>();
        foreach (DataRow row in dataTable.Rows)
            tables.Add($"{row["TABLE_SCHEMA"]}.{row["TABLE_NAME"]}");
        TablesComboBox.DataSource = tables;
    }

    private async void TablesComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        int count = await Invoke(() => _repository.GetCountAsync($"{DatabasesComboBox.Text}.{TablesComboBox.Text}"));
        CountOfRowsTextBox.Text = count.ToString();
        OperationGroupBox.Enabled = true;
        List<string> tables = new List<string>();
        var table = await Invoke(GetTableData);
        foreach (DataRow row in table.Item1.Rows)
            tables.Add(row["Column_NAME"].ToString());
        DeleteOrUpdateByComboBox.DataSource = tables;
    }

    private string GenerateConnectionString()
    {
        bool isIntegratedSecurity = AuthenticationComboBox.Text.Equals("Windows Authentication");
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        sqlConnectionStringBuilder.DataSource = ServerComboBox.Text;
        sqlConnectionStringBuilder.IntegratedSecurity = isIntegratedSecurity;
        sqlConnectionStringBuilder.TrustServerCertificate = true;
        if (!isIntegratedSecurity)
        {
            sqlConnectionStringBuilder.UserID = UserNameTextBox.Text;
            sqlConnectionStringBuilder.Password = PasswordTextBox.Text;
        }
        return sqlConnectionStringBuilder.ConnectionString;
    }

    private async void ExportToExcelButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TablesComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
        {
            MessageBox.Show("Please select a database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
        var workSheet = workBook.CreateWorkSheet(TablesComboBox.Text);

        var tableData = await GetTableData();
        var tableInfo = tableData.Item1.Rows;
        var rows = tableData.Item2.Rows;

        int i = 0;
        for (char character = 'A'; i < tableInfo.Count && character <= 'Z'; character++, i++)
            workSheet[$"{character}1"].Value = tableInfo[i].ItemArray[0].ToString();

        for (i = 2; i < rows.Count + 2; i++)
        {
            char character = 'A';
            for (int j = 0; j < rows[i - 2].ItemArray.Length; j++, character++)
                workSheet[$"{character}{i}"].Value = rows[i - 2].ItemArray[j] != DBNull.Value ? rows[i - 2].ItemArray[j] : "-";
        }

        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
        {
            SelectedPath = "C:\\Desktop"
        };
        folderBrowserDialog.ShowDialog();
        if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
        {
            workBook.SaveAs($"{folderBrowserDialog.SelectedPath}\\{TablesComboBox.Text}.xlsx");
            MessageBox.Show("Done", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async Task<(DataTable, DataTable)> GetTableData()
    {
        string sqlQuery = $"select Column_NAME from {DatabasesComboBox.Text}.INFORMATION_SCHEMA.Columns where TABLE_NAME = '{TablesComboBox.Text.Split('.')[1]}'";
        using var dataTable = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        sqlQuery = $"SELECT * FROM [{DatabasesComboBox.SelectedValue}].{TablesComboBox.SelectedValue}";
        using var data = await _repository.ExecuteSQLCommandAsync(sqlQuery);
        return (dataTable, data);
    }

    private async void DeleteButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ValueTextBox.Text))
        {
            MessageBox.Show("Please enter a value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var result = await _repository.DeleteAsync($"{DatabasesComboBox.Text}.{TablesComboBox.Text}", DeleteOrUpdateByComboBox.Text, ValueTextBox.Text);
        if (result)
        {
            MessageBox.Show("Done", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int count = await _repository.GetCountAsync($"{DatabasesComboBox.Text}.{TablesComboBox.Text}");
            CountOfRowsTextBox.Text = count.ToString();
        }
        else
            MessageBox.Show("Something went wrong", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async void UpdateButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TablesComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
        {
            MessageBox.Show("Please select a database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrEmpty(ValueTextBox.Text))
        {
            MessageBox.Show("Please enter a value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        if (string.IsNullOrEmpty(NewValueTextBox.Text))
        {
            MessageBox.Show("Please enter a new value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        var result = await _repository.UpdateAsync($"{DatabasesComboBox.Text}.{TablesComboBox.Text}", DeleteOrUpdateByComboBox.Text, ValueTextBox.Text, NewValueTextBox.Text);
        if (result)
            MessageBox.Show("Done", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private async void ExportToJsonButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TablesComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
        {
            MessageBox.Show("Please select a database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        List<IEnumerable<object>> items = new List<IEnumerable<object>>();
        var tableData = await GetTableData();

        foreach (DataRow row in tableData.Item2.Rows)
        {
            object[] objects = new object[row.ItemArray.Length];

            for (int i = 0; i < row.ItemArray.Length; i++)
                objects[i] = row.ItemArray[i] != DBNull.Value ? row.ItemArray[i] : "-";

            items.Add(objects);
        }
        string jsonString = System.Text.Json.JsonSerializer.Serialize(items);
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
        {
            SelectedPath = "C:\\Desktop"
        };
        folderBrowserDialog.ShowDialog();
        if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
        {
            File.WriteAllText($"{folderBrowserDialog.SelectedPath}\\{TablesComboBox.Text}.json", jsonString);
            MessageBox.Show("Done", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private async void ServerComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        var path = Application.StartupPath + "Servers";
        string filePath = path + "\\Servers.json";
        if (Directory.Exists(path) && File.Exists(filePath))
        {
            string jsonData = await File.ReadAllTextAsync(filePath);
            if (!string.IsNullOrEmpty(jsonData))
            {
                var servers = JsonConvert.DeserializeObject<List<ServerInformation>>(jsonData);
                ServerInformation serverInformation = servers.First(server => server.Server == ServerComboBox.Text);
                if (serverInformation.AuthenticationMode == AuthenticationMode.SQLServerAuthentication)
                {
                    AuthenticationComboBox.Text = "SQL Server Authentication";
                    UserNameTextBox.Enabled = PasswordTextBox.Enabled = true;
                    UserNameTextBox.Text = serverInformation.Username;
                    PasswordTextBox.Text = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(serverInformation.Password));
                }
            }
        }
    }

    private void PasswordTextBox_MouseEnter(object sender, EventArgs e) => PasswordTextBox.PasswordChar = '\u0000';

    private void PasswordTextBox_MouseLeave(object sender, EventArgs e) => PasswordTextBox.PasswordChar = '*';
}
