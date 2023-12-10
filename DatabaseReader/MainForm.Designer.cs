﻿using Point = System.Drawing.Point;
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
            CountRowsTextBox = new TextBox();
            IdLabel = new Label();
            label1 = new Label();
            ExportToExcelButton = new Button();
            DeleteButton = new Button();
            OpenButton = new Button();
            TabelsComboBox = new ComboBox();
            DatabasesComboBox = new ComboBox();
            StatusStrip = new StatusStrip();
            StatusToolStripLabel = new ToolStripStatusLabel();
            OperationGroupBox = new GroupBox();
            ConnectServerGroupBox.SuspendLayout();
            DatabasesGroupBox.SuspendLayout();
            StatusStrip.SuspendLayout();
            OperationGroupBox.SuspendLayout();
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
            ConnectServerGroupBox.Size = new Size(537, 224);
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
            DatabasesGroupBox.Controls.Add(label1);
            DatabasesGroupBox.Controls.Add(ExportToExcelButton);
            DatabasesGroupBox.Controls.Add(OpenButton);
            DatabasesGroupBox.Controls.Add(TabelsComboBox);
            DatabasesGroupBox.Controls.Add(DatabasesComboBox);
            DatabasesGroupBox.Location = new Point(12, 246);
            DatabasesGroupBox.Name = "DatabasesGroupBox";
            DatabasesGroupBox.Size = new Size(537, 163);
            DatabasesGroupBox.TabIndex = 1;
            DatabasesGroupBox.TabStop = false;
            DatabasesGroupBox.Text = "Databases";
            // 
            // CountRowsTextBox
            // 
            CountRowsTextBox.Location = new Point(41, 26);
            CountRowsTextBox.Name = "CountRowsTextBox";
            CountRowsTextBox.ReadOnly = true;
            CountRowsTextBox.Size = new Size(95, 27);
            CountRowsTextBox.TabIndex = 4;
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Location = new Point(6, 29);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(29, 20);
            IdLabel.TabIndex = 3;
            IdLabel.Text = "Id :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 80);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 2;
            label1.Text = "Tabels :";
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
            // DeleteButton
            // 
            DeleteButton.Location = new Point(438, 20);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 1;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += OpenButton_Click;
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
            // TabelsComboBox
            // 
            TabelsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TabelsComboBox.FlatStyle = FlatStyle.Popup;
            TabelsComboBox.FormattingEnabled = true;
            TabelsComboBox.Location = new Point(69, 77);
            TabelsComboBox.Name = "TabelsComboBox";
            TabelsComboBox.Size = new Size(463, 28);
            TabelsComboBox.TabIndex = 0;
            TabelsComboBox.SelectedValueChanged += TablesComboBox_SelectedValueChanged;
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
            // StatusStrip
            // 
            StatusStrip.ImageScalingSize = new Size(20, 20);
            StatusStrip.Items.AddRange(new ToolStripItem[] { StatusToolStripLabel });
            StatusStrip.Location = new Point(0, 510);
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
            OperationGroupBox.Controls.Add(CountRowsTextBox);
            OperationGroupBox.Controls.Add(IdLabel);
            OperationGroupBox.Controls.Add(DeleteButton);
            OperationGroupBox.Location = new Point(12, 415);
            OperationGroupBox.Name = "OperationGroupBox";
            OperationGroupBox.Size = new Size(537, 80);
            OperationGroupBox.TabIndex = 3;
            OperationGroupBox.TabStop = false;
            OperationGroupBox.Text = "Operation";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 536);
            Controls.Add(OperationGroupBox);
            Controls.Add(StatusStrip);
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
        private TextBox ServerNameTextBox;
        private Button ConnectButton;
        private GroupBox DatabasesGroupBox;
        private ComboBox DatabasesComboBox;
        private StatusStrip StatusStrip;
        private ToolStripStatusLabel StatusToolStripLabel;
        private Button OpenButton;
        private Label label1;
        private ComboBox TabelsComboBox;
        private Label IdLabel;
        private TextBox CountRowsTextBox;
        private Button ExportToExcelButton;
        private Button DeleteButton;
        private GroupBox OperationGroupBox;
    }
}