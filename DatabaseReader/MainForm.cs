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
