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

    private void AuthenticationComboBox_SelectedValueChanged(object sender, EventArgs e)
    {
        bool status = ((ComboBox)sender).SelectedItem.Equals("SQL Server Authentication") ? true : false;
        UserNameLabel.Enabled = PasswordLabel.Enabled = status;
        UserNameTextBox.Enabled = PasswordTextBox.Enabled = status;
    }

    private void ConnectButton_Click(object sender, EventArgs e)
    {
        using SqlConnection connection = new SqlConnection(GenerateConnectionString());
        string sqlQuery = "SELECT name FROM sys.databases";
        connection.Open();
        using SqlCommand command = new SqlCommand(sqlQuery, connection);
        var reader = command.ExecuteReader();
        List<string> databases = new List<string>();

        while (reader.Read())
            databases.Add($"{reader["name"]}");

        DatabasesComboBox.DataSource = databases;
        DatabasesGroupBox.Enabled = true;
        StatusToolStripLabel.ForeColor = Color.Green;
        StatusToolStripLabel.Text = "Connected";
    }

    private string GenerateConnectionString()
    {
        bool isIntegratedSecurity = AuthenticationComboBox.SelectedValue.Equals("Windows Authentication");
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