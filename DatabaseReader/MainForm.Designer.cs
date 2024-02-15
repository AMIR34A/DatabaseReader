using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using SizeF = System.Drawing.SizeF;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            ConnectServerGroupBox = new GroupBox();
            RemeberMeCheckBox = new CheckBox();
            RemeberMeLabel = new Label();
            DisconnectButton = new Button();
            ConnectButton = new Button();
            AuthenticationComboBox = new ComboBox();
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            PasswordLabel = new Label();
            ServerComboBox = new ComboBox();
            UserNameLabel = new Label();
            AuthenticationLabel = new Label();
            ServerNameLabel = new Label();
            DatabasesGroupBox = new GroupBox();
            CountOfRowsLabel = new Label();
            CountOfRowsTextBox = new TextBox();
            TableLabel = new Label();
            ExportToJsonButton = new Button();
            ExportToExcelButton = new Button();
            DeleteTableButton = new Button();
            OpenButton = new Button();
            TablesComboBox = new ComboBox();
            DatabasesComboBox = new ComboBox();
            DeleteButton = new Button();
            StatusStrip = new StatusStrip();
            StatusToolStripLabel = new ToolStripStatusLabel();
            OperationGroupBox = new GroupBox();
            ValueLabel = new Label();
            NewValueLabel = new Label();
            DeleteOrUpdateLabel = new Label();
            UpdateButton = new Button();
            NewValueTextBox = new TextBox();
            ValueTextBox = new TextBox();
            DeleteOrUpdateByComboBox = new ComboBox();
            ConnectServerGroupBox.SuspendLayout();
            DatabasesGroupBox.SuspendLayout();
            StatusStrip.SuspendLayout();
            OperationGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // ConnectServerGroupBox
            // 
            ConnectServerGroupBox.Controls.Add(RemeberMeCheckBox);
            ConnectServerGroupBox.Controls.Add(RemeberMeLabel);
            ConnectServerGroupBox.Controls.Add(DisconnectButton);
            ConnectServerGroupBox.Controls.Add(ConnectButton);
            ConnectServerGroupBox.Controls.Add(AuthenticationComboBox);
            ConnectServerGroupBox.Controls.Add(UserNameTextBox);
            ConnectServerGroupBox.Controls.Add(PasswordTextBox);
            ConnectServerGroupBox.Controls.Add(PasswordLabel);
            ConnectServerGroupBox.Controls.Add(ServerComboBox);
            ConnectServerGroupBox.Controls.Add(UserNameLabel);
            ConnectServerGroupBox.Controls.Add(AuthenticationLabel);
            ConnectServerGroupBox.Controls.Add(ServerNameLabel);
            ConnectServerGroupBox.Location = new Point(12, 12);
            ConnectServerGroupBox.Name = "ConnectServerGroupBox";
            ConnectServerGroupBox.Size = new Size(537, 224);
            ConnectServerGroupBox.TabIndex = 0;
            ConnectServerGroupBox.TabStop = false;
            ConnectServerGroupBox.Text = "Connect to Server";
            // 
            // RemeberMeCheckBox
            // 
            RemeberMeCheckBox.AutoSize = true;
            RemeberMeCheckBox.Location = new Point(6, 188);
            RemeberMeCheckBox.Name = "RemeberMeCheckBox";
            RemeberMeCheckBox.Size = new Size(116, 24);
            RemeberMeCheckBox.TabIndex = 6;
            RemeberMeCheckBox.Text = "Remeber Me";
            RemeberMeCheckBox.UseVisualStyleBackColor = true;
            // 
            // RemeberMeLabel
            // 
            RemeberMeLabel.AutoSize = true;
            RemeberMeLabel.Location = new Point(6, 189);
            RemeberMeLabel.Name = "RemeberMeLabel";
            RemeberMeLabel.Size = new Size(0, 20);
            RemeberMeLabel.TabIndex = 4;
            // 
            // DisconnectButton
            // 
            DisconnectButton.Location = new Point(338, 189);
            DisconnectButton.Name = "DisconnectButton";
            DisconnectButton.Size = new Size(94, 29);
            DisconnectButton.TabIndex = 5;
            DisconnectButton.Text = "Disconnect";
            DisconnectButton.UseVisualStyleBackColor = true;
            DisconnectButton.Click += DisconnectButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(438, 189);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(94, 29);
            ConnectButton.TabIndex = 5;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
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
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(405, 27);
            PasswordTextBox.TabIndex = 4;
            PasswordTextBox.MouseEnter += PasswordTextBox_MouseEnter;
            PasswordTextBox.MouseLeave += PasswordTextBox_MouseLeave;
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
            // ServerComboBox
            // 
            ServerComboBox.FlatStyle = FlatStyle.Popup;
            ServerComboBox.FormattingEnabled = true;
            ServerComboBox.Location = new Point(127, 30);
            ServerComboBox.Name = "ServerComboBox";
            ServerComboBox.Size = new Size(404, 28);
            ServerComboBox.TabIndex = 0;
            ServerComboBox.SelectedValueChanged += ServerComboBox_SelectedValueChanged;
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
            DatabasesGroupBox.Controls.Add(CountOfRowsLabel);
            DatabasesGroupBox.Controls.Add(CountOfRowsTextBox);
            DatabasesGroupBox.Controls.Add(TableLabel);
            DatabasesGroupBox.Controls.Add(ExportToJsonButton);
            DatabasesGroupBox.Controls.Add(ExportToExcelButton);
            DatabasesGroupBox.Controls.Add(DeleteTableButton);
            DatabasesGroupBox.Controls.Add(OpenButton);
            DatabasesGroupBox.Controls.Add(TablesComboBox);
            DatabasesGroupBox.Controls.Add(DatabasesComboBox);
            DatabasesGroupBox.Location = new Point(12, 242);
            DatabasesGroupBox.Name = "DatabasesGroupBox";
            DatabasesGroupBox.Size = new Size(537, 195);
            DatabasesGroupBox.TabIndex = 1;
            DatabasesGroupBox.TabStop = false;
            DatabasesGroupBox.Text = "Databases";
            // 
            // CountOfRowsLabel
            // 
            CountOfRowsLabel.AutoSize = true;
            CountOfRowsLabel.Location = new Point(6, 125);
            CountOfRowsLabel.Name = "CountOfRowsLabel";
            CountOfRowsLabel.Size = new Size(55, 20);
            CountOfRowsLabel.TabIndex = 3;
            CountOfRowsLabel.Text = "Count :";
            // 
            // CountOfRowsTextBox
            // 
            CountOfRowsTextBox.Location = new Point(69, 121);
            CountOfRowsTextBox.Name = "CountOfRowsTextBox";
            CountOfRowsTextBox.ReadOnly = true;
            CountOfRowsTextBox.Size = new Size(95, 27);
            CountOfRowsTextBox.TabIndex = 4;
            // 
            // TableLabel
            // 
            TableLabel.AutoSize = true;
            TableLabel.Location = new Point(6, 80);
            TableLabel.Name = "TableLabel";
            TableLabel.Size = new Size(57, 20);
            TableLabel.TabIndex = 2;
            TableLabel.Text = "Tables :";
            // 
            // ExportToJsonButton
            // 
            ExportToJsonButton.Location = new Point(193, 121);
            ExportToJsonButton.Name = "ExportToJsonButton";
            ExportToJsonButton.Size = new Size(117, 29);
            ExportToJsonButton.TabIndex = 1;
            ExportToJsonButton.Text = "Export to JSON";
            ExportToJsonButton.UseVisualStyleBackColor = true;
            ExportToJsonButton.Click += ExportToJsonButton_Click;
            // 
            // ExportToExcelButton
            // 
            ExportToExcelButton.Location = new Point(316, 121);
            ExportToExcelButton.Name = "ExportToExcelButton";
            ExportToExcelButton.Size = new Size(116, 29);
            ExportToExcelButton.TabIndex = 1;
            ExportToExcelButton.Text = "Export to Excel";
            ExportToExcelButton.UseVisualStyleBackColor = true;
            ExportToExcelButton.Click += ExportToExcelButton_Click;
            // 
            // DeleteTableButton
            // 
            DeleteTableButton.Location = new Point(316, 156);
            DeleteTableButton.Name = "DeleteTableButton";
            DeleteTableButton.Size = new Size(116, 29);
            DeleteTableButton.TabIndex = 1;
            DeleteTableButton.Text = "Delete Table";
            DeleteTableButton.UseVisualStyleBackColor = true;
            // 
            // OpenButton
            // 
            OpenButton.Location = new Point(438, 121);
            OpenButton.Name = "OpenButton";
            OpenButton.Size = new Size(94, 29);
            OpenButton.TabIndex = 1;
            OpenButton.Text = "Open";
            OpenButton.UseVisualStyleBackColor = true;
            OpenButton.Click += OpenButton_Click;
            // 
            // TablesComboBox
            // 
            TablesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TablesComboBox.FlatStyle = FlatStyle.Popup;
            TablesComboBox.FormattingEnabled = true;
            TablesComboBox.Location = new Point(69, 77);
            TablesComboBox.Name = "TablesComboBox";
            TablesComboBox.Size = new Size(463, 28);
            TablesComboBox.TabIndex = 0;
            TablesComboBox.SelectedValueChanged += TablesComboBox_SelectedValueChanged;
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
            DatabasesComboBox.SelectedValueChanged += DatabasesComboBox_SelectedValueChanged;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(437, 29);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 1;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new Size(20, 20);
            StatusStrip.Items.AddRange(new ToolStripItem[] { StatusToolStripLabel });
            StatusStrip.Location = new Point(0, 558);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(561, 26);
            StatusStrip.TabIndex = 2;
            StatusStrip.Text = "ConnectStatusStrip";
            // 
            // StatusToolStripLabel
            // 
            StatusToolStripLabel.ForeColor = System.Drawing.Color.Red;
            StatusToolStripLabel.Name = "StatusToolStripLabel";
            StatusToolStripLabel.Size = new Size(82, 20);
            StatusToolStripLabel.Text = "Disconnect";
            // 
            // OperationGroupBox
            // 
            OperationGroupBox.Controls.Add(ValueLabel);
            OperationGroupBox.Controls.Add(NewValueLabel);
            OperationGroupBox.Controls.Add(DeleteOrUpdateLabel);
            OperationGroupBox.Controls.Add(UpdateButton);
            OperationGroupBox.Controls.Add(DeleteButton);
            OperationGroupBox.Controls.Add(NewValueTextBox);
            OperationGroupBox.Controls.Add(ValueTextBox);
            OperationGroupBox.Controls.Add(DeleteOrUpdateByComboBox);
            OperationGroupBox.Enabled = false;
            OperationGroupBox.Location = new Point(12, 443);
            OperationGroupBox.Name = "OperationGroupBox";
            OperationGroupBox.Size = new Size(537, 97);
            OperationGroupBox.TabIndex = 3;
            OperationGroupBox.TabStop = false;
            OperationGroupBox.Text = "Operation";
            // 
            // ValueLabel
            // 
            ValueLabel.AutoSize = true;
            ValueLabel.Location = new Point(254, 33);
            ValueLabel.Name = "ValueLabel";
            ValueLabel.Size = new Size(52, 20);
            ValueLabel.TabIndex = 3;
            ValueLabel.Text = "Value :";
            // 
            // NewValueLabel
            // 
            NewValueLabel.AutoSize = true;
            NewValueLabel.Location = new Point(6, 66);
            NewValueLabel.Name = "NewValueLabel";
            NewValueLabel.Size = new Size(85, 20);
            NewValueLabel.TabIndex = 3;
            NewValueLabel.Text = "New value :";
            // 
            // DeleteOrUpdateLabel
            // 
            DeleteOrUpdateLabel.AutoSize = true;
            DeleteOrUpdateLabel.Location = new Point(6, 33);
            DeleteOrUpdateLabel.Name = "DeleteOrUpdateLabel";
            DeleteOrUpdateLabel.Size = new Size(135, 20);
            DeleteOrUpdateLabel.TabIndex = 3;
            DeleteOrUpdateLabel.Text = "Delete/Update by :";
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(437, 62);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(94, 29);
            UpdateButton.TabIndex = 1;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // NewValueTextBox
            // 
            NewValueTextBox.Location = new Point(97, 63);
            NewValueTextBox.Name = "NewValueTextBox";
            NewValueTextBox.Size = new Size(334, 27);
            NewValueTextBox.TabIndex = 4;
            // 
            // ValueTextBox
            // 
            ValueTextBox.Location = new Point(312, 31);
            ValueTextBox.Name = "ValueTextBox";
            ValueTextBox.Size = new Size(120, 27);
            ValueTextBox.TabIndex = 4;
            // 
            // DeleteOrUpdateByComboBox
            // 
            DeleteOrUpdateByComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            DeleteOrUpdateByComboBox.FlatStyle = FlatStyle.Popup;
            DeleteOrUpdateByComboBox.FormattingEnabled = true;
            DeleteOrUpdateByComboBox.Location = new Point(147, 31);
            DeleteOrUpdateByComboBox.Name = "DeleteOrUpdateByComboBox";
            DeleteOrUpdateByComboBox.Size = new Size(101, 28);
            DeleteOrUpdateByComboBox.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 584);
            Controls.Add(OperationGroupBox);
            Controls.Add(StatusStrip);
            Controls.Add(DatabasesGroupBox);
            Controls.Add(ConnectServerGroupBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Reader";
            Load += MainForm_Load;
            ConnectServerGroupBox.ResumeLayout(false);
            ConnectServerGroupBox.PerformLayout();
            DatabasesGroupBox.ResumeLayout(false);
            DatabasesGroupBox.PerformLayout();
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            OperationGroupBox.ResumeLayout(false);
            OperationGroupBox.PerformLayout();
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
        private Button ConnectButton;
        private GroupBox DatabasesGroupBox;
        private ComboBox DatabasesComboBox;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel StatusToolStripLabel;
        private Button OpenButton;
        private Label TableLabel;
        private ComboBox TablesComboBox;
        private Label CountOfRowsLabel;
        private TextBox CountOfRowsTextBox;
        private Button ExportToExcelButton;
        private Button DeleteButton;
        private GroupBox OperationGroupBox;
        private Label DeleteOrUpdateLabel;
        private ComboBox DeleteOrUpdateByComboBox;
        private Label ValueLabel;
        private TextBox ValueTextBox;
        private Button ExportToJsonButton;
        private Button UpdateButton;
        private Label NewValueLabel;
        private TextBox NewValueTextBox;
        private CheckBox RemeberMeCheckBox;
        private Label RemeberMeLabel;
        private ComboBox ServerComboBox;
        private Button DisconnectButton;
        private Button DeleteTableButton;
    }
}