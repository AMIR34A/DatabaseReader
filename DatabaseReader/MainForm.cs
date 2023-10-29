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
}