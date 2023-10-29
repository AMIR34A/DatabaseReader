namespace DatabaseReader
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ConnectServerGroupBox = new GroupBox();
            ConnectButton = new Button();
            AuthenticationComboBox = new ComboBox();
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            ServerNameTextBox = new TextBox();
            PasswordLabel = new Label();
            UserNameLabel = new Label();
            AuthenticationLabel = new Label();
            ServerNameLabel = new Label();
            DatabasesGroupBox = new GroupBox();
            DatabasesComboBox = new ComboBox();
            statusStrip1 = new StatusStrip();
            StatusToolStripLabel = new ToolStripStatusLabel();
            ConnectServerGroupBox.SuspendLayout();
            DatabasesGroupBox.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ConnectServerGroupBox
            // 
            ConnectServerGroupBox.Controls.Add(ConnectButton);
            ConnectServerGroupBox.Controls.Add(AuthenticationComboBox);
            ConnectServerGroupBox.Controls.Add(UserNameTextBox);
            ConnectServerGroupBox.Controls.Add(PasswordTextBox);
            ConnectServerGroupBox.Controls.Add(ServerNameTextBox);
            ConnectServerGroupBox.Controls.Add(PasswordLabel);
            ConnectServerGroupBox.Controls.Add(UserNameLabel);
            ConnectServerGroupBox.Controls.Add(AuthenticationLabel);
            ConnectServerGroupBox.Controls.Add(ServerNameLabel);
            ConnectServerGroupBox.Location = new Point(12, 12);
            ConnectServerGroupBox.Name = "ConnectServerGroupBox";
            ConnectServerGroupBox.Size = new Size(538, 224);
            ConnectServerGroupBox.TabIndex = 0;
            ConnectServerGroupBox.TabStop = false;
            ConnectServerGroupBox.Text = "Connect to Server";
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(438, 189);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(94, 29);
            ConnectButton.TabIndex = 5;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            // 
            // AuthenticationComboBox
            // 
            AuthenticationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AuthenticationComboBox.FlatStyle = FlatStyle.Popup;
            AuthenticationComboBox.FormattingEnabled = true;
            AuthenticationComboBox.Location = new Point(127, 70);
            AuthenticationComboBox.Name = "AuthenticationComboBox";
            AuthenticationComboBox.Size = new Size(405, 28);
            AuthenticationComboBox.TabIndex = 2;
            AuthenticationComboBox.SelectedValueChanged += AuthenticationComboBox_SelectedValueChanged;
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(127, 109);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(405, 27);
            UserNameTextBox.TabIndex = 3;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(127, 149);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(405, 27);
            PasswordTextBox.TabIndex = 4;
            // 
            // ServerNameTextBox
            // 
            ServerNameTextBox.Location = new Point(127, 30);
            ServerNameTextBox.Name = "ServerNameTextBox";
            ServerNameTextBox.Size = new Size(405, 27);
            ServerNameTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(6, 152);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(77, 20);
            PasswordLabel.TabIndex = 0;
            PasswordLabel.Text = "Password :";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Location = new Point(6, 112);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(86, 20);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "User name :";
            // 
            // AuthenticationLabel
            // 
            AuthenticationLabel.AutoSize = true;
            AuthenticationLabel.Location = new Point(6, 73);
            AuthenticationLabel.Name = "AuthenticationLabel";
            AuthenticationLabel.Size = new Size(113, 20);
            AuthenticationLabel.TabIndex = 0;
            AuthenticationLabel.Text = "Authentication :";
            // 
            // ServerNameLabel
            // 
            ServerNameLabel.AutoSize = true;
            ServerNameLabel.Location = new Point(6, 33);
            ServerNameLabel.Name = "ServerNameLabel";
            ServerNameLabel.Size = new Size(98, 20);
            ServerNameLabel.TabIndex = 0;
            ServerNameLabel.Text = "Server name :";
            // 
            // DatabasesGroupBox
            // 
            DatabasesGroupBox.Controls.Add(DatabasesComboBox);
            DatabasesGroupBox.Location = new Point(12, 246);
            DatabasesGroupBox.Name = "DatabasesGroupBox";
            DatabasesGroupBox.Size = new Size(538, 68);
            DatabasesGroupBox.TabIndex = 1;
            DatabasesGroupBox.TabStop = false;
            DatabasesGroupBox.Text = "Databases";
            // 
            // DatabasesComboBox
            // 
            DatabasesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DatabasesComboBox.FlatStyle = FlatStyle.Popup;
            DatabasesComboBox.FormattingEnabled = true;
            DatabasesComboBox.Location = new Point(6, 26);
            DatabasesComboBox.Name = "DatabasesComboBox";
            DatabasesComboBox.Size = new Size(526, 28);
            DatabasesComboBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusToolStripLabel });
            statusStrip1.Location = new Point(0, 330);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(562, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "ConnectStatusStrip";
            // 
            // StatusToolStripLabel
            // 
            StatusToolStripLabel.ForeColor = Color.Red;
            StatusToolStripLabel.Name = "StatusToolStripLabel";
            StatusToolStripLabel.Size = new Size(82, 20);
            StatusToolStripLabel.Text = "Disconnect";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 356);
            Controls.Add(statusStrip1);
            Controls.Add(DatabasesGroupBox);
            Controls.Add(ConnectServerGroupBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Reader";
            Load += MainForm_Load;
            ConnectServerGroupBox.ResumeLayout(false);
            ConnectServerGroupBox.PerformLayout();
            DatabasesGroupBox.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox ConnectServerGroupBox;
        private Label PasswordLabel;
        private Label UserNameLabel;
        private Label AuthenticationLabel;
        private Label ServerNameLabel;
        private ComboBox AuthenticationComboBox;
        private TextBox UserNameTextBox;
        private TextBox PasswordTextBox;
        private TextBox ServerNameTextBox;
        private Button ConnectButton;
        private GroupBox DatabasesGroupBox;
        private ComboBox DatabasesComboBox;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusToolStripLabel;
    }
}