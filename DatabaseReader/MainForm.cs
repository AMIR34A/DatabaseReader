using Microsoft.Data.SqlClient;

namespace DatabaseReader;

public partial class MainForm : Form
{
    public MainForm() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e)
    {
        AuthenticationComboBox.DataSource = new string[] { "Windows Authentication", "SQL Server Authentication" };
        DatabasesGroupBox.Enabled = false;
        UserNameLabel.Enabled = PasswordLabel.Enabled = false;
        UserNameTextBox.Enabled = PasswordTextBox.Enabled = false;
    }

    private async void ConnectButton_Click(object sender, EventArgs e)
    {
        _repository.UpdateConnectionString(GenerateConnectionString());
        string sqlQuery = "SELECT name FROM sys.databases";

        using var reader = await _repository.ExecuteSQLCommandAsync(sqlQuery);
        List<string> databases = new List<string>() { "Choose..." };

        while (reader.Read())
            databases.Add($"{reader["name"]}");

        DatabasesComboBox.DataSource = databases;
        DatabasesGroupBox.Enabled = true;
        StatusToolStripLabel.ForeColor = Color.Green;
        StatusToolStripLabel.Text = "Connected";
        await _repository.CloseConnection();
    }

    private async void OpenButton_Click(object sender, EventArgs e)
    {
        DataGridView dataGridView = new DataGridView()
        {
            ReadOnly = true,
            RowHeadersVisible = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            Dock = DockStyle.Fill,
        };

        string sqlQuery = $"select Column_NAME from {DatabasesComboBox.Text}.INFORMATION_SCHEMA.Columns where TABLE_NAME = '{TabelsComboBox.Text.Split('.')[1]}'";
        var readerColums = await _repository.ExecuteSQLCommandAsync(sqlQuery);
        while (readerColums.Read())
            dataGridView.Columns.Add(readerColums[readerColums.GetName(0)].ToString(), readerColums[readerColums.GetName(0)].ToString());

        await _repository.CloseConnection();

        sqlQuery = $"SELECT * FROM [{DatabasesComboBox.SelectedValue}].{TabelsComboBox.SelectedValue}";
        var readerRows = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        while (readerRows.Read())
        {
            object[] row = new object[readerRows.FieldCount];
            for (int i = 0; i < readerRows.FieldCount; i++)
                row[i] = readerRows[readerRows.GetName(i)] != DBNull.Value ? readerRows[readerRows.GetName(i)] : "-";

            dataGridView.Rows.Add(row);
        }
        await _repository.CloseConnection();

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
        using var reader = await _repository.ExecuteSQLCommandAsync(sqlQuery);

        List<string> tabels = new List<string>();

        while (reader.Read())
            tabels.Add($"{reader[reader.GetName(0)]}.{reader[reader.GetName(1)]}");
        await _repository.CloseConnection();
        TabelsComboBox.DataSource = tabels;
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
}
