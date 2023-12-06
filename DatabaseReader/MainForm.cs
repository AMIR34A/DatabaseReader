using DatabaseReader.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;

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

    private void MainForm_Load(object sender, EventArgs e)
    {
        DatabasesGroupBox.Enabled = false;
        UserNameLabel.Enabled = PasswordLabel.Enabled = false;
        UserNameTextBox.Enabled = PasswordTextBox.Enabled = false;
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ServerNameTextBox.Text))
        {
            MessageBox.Show("Please enter server name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        _repository.UpdateConnectionString(GenerateConnectionString());
        string sqlQuery = "SELECT name FROM sys.databases";

        using var dataTable = await _repository.ExecuteSQLCommandAsync(sqlQuery);
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
        if (string.IsNullOrEmpty(TabelsComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
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

        string sqlQuery = $"select Column_NAME from {DatabasesComboBox.Text}.INFORMATION_SCHEMA.Columns where TABLE_NAME = '{TabelsComboBox.Text.Split('.')[1]}'";
        using var dataTable = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        foreach (DataRow row in dataTable.Rows)
            dataGridView.Columns.Add(row["Column_NAME"].ToString(), row["Column_NAME"].ToString());

        sqlQuery = $"SELECT * FROM [{DatabasesComboBox.SelectedValue}].{TabelsComboBox.SelectedValue}";
        using var data = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        foreach (DataRow row in data.Rows)
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

        List<string> tabels = new List<string>();
        foreach (DataRow row in dataTable.Rows)
            tabels.Add($"{row["TABLE_SCHEMA"]}.{row["TABLE_NAME"]}");
        TabelsComboBox.DataSource = tabels;
    }

    private async void TabelsComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        int count = await _repository.GetCount($"{DatabasesComboBox.Text}.{TabelsComboBox.Text}");
        CountRowsTextBox.Text = count.ToString();
    }

    private string GenerateConnectionString()
    {
        bool isIntegratedSecurity = AuthenticationComboBox.Text.Equals("Windows Authentication");
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
        sqlConnectionStringBuilder.DataSource = ServerNameTextBox.Text;
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
        if (string.IsNullOrEmpty(TabelsComboBox.Text) || DatabasesComboBox.Text.Equals("Choose..."))
        {
            MessageBox.Show("Please select a database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
        var workSheet = workBook.CreateWorkSheet(TabelsComboBox.Text);

        var tableData = await GetTableData();
        var tableInfo = tableData.Item1.Rows;
        var rows = tableData.Item2.Rows;
        //foreach (DataRow row in tableData.Item1.Rows)

        int i = 0;
        for (char character = 'A'; i < tableInfo.Count && character <= 'Z'; character++, i++)
            workSheet[$"{character}1"].Value = tableInfo[i].ItemArray[0].ToString();

        for (i = 2; i < rows.Count + 2; i++)
    {
            char character = 'A';
            for (int j = 0; j < rows[i - 2].ItemArray.Length; j++, character++)
                workSheet[$"{character}{i}"].Value = rows[i - 2].ItemArray[j] != DBNull.Value ? rows[i - 2].ItemArray[j] : "-";
        }


        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        folderBrowserDialog.ShowDialog();
        workBook.SaveAs($"{folderBrowserDialog.SelectedPath}\\{TabelsComboBox.Text}.xlsx");
        MessageBox.Show("Done", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
