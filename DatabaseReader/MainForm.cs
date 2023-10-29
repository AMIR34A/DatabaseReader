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
        bool status = true;
        if (((ComboBox)sender).SelectedItem.Equals("SQL Server Authentication"))
            status = false;
            UserNameLabel.Enabled = PasswordLabel.Enabled = status;
            UserNameTextBox.Enabled = PasswordTextBox.Enabled = status;
        
    }
}