namespace RomulatorFrontend.View
{
    partial class ConfigurationEnvironmentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RunAsAdministratorButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ThemeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OpenThemesButton = new System.Windows.Forms.Button();
            this.GamepadPollRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SystemShellComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.FullScreenStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LaunchExplorerButton = new System.Windows.Forms.Button();
            this.RestartWindowsButton = new System.Windows.Forms.Button();
            this.ShutdownWindowsButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.RunOnLoadDataGridView = new System.Windows.Forms.DataGridView();
            this.CommandPathTextBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommandParametersTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommandEnabledCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.NetworkSharePathTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.InstallNetworkSharePathButton = new System.Windows.Forms.Button();
            this.ScanExternalCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamepadPollRateNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunOnLoadDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.RunAsAdministratorButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(697, 482);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RunAsAdministratorButton
            // 
            this.RunAsAdministratorButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RunAsAdministratorButton.Location = new System.Drawing.Point(506, 454);
            this.RunAsAdministratorButton.Name = "RunAsAdministratorButton";
            this.RunAsAdministratorButton.Size = new System.Drawing.Size(188, 25);
            this.RunAsAdministratorButton.TabIndex = 0;
            this.RunAsAdministratorButton.Text = "Restart and run as Administrator";
            this.RunAsAdministratorButton.UseVisualStyleBackColor = true;
            this.RunAsAdministratorButton.Click += new System.EventHandler(this.RunAsAdministratorButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(691, 445);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Look & Feel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.ThemeComboBox, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.OpenThemesButton, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.GamepadPollRateNumericUpDown, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(677, 413);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gamepad Poll Rate";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "This is the frequency that the game pads are polled at.";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Theme";
            // 
            // ThemeComboBox
            // 
            this.ThemeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ThemeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ThemeComboBox.FormattingEnabled = true;
            this.ThemeComboBox.Location = new System.Drawing.Point(149, 53);
            this.ThemeComboBox.Name = "ThemeComboBox";
            this.ThemeComboBox.Size = new System.Drawing.Size(141, 21);
            this.ThemeComboBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "These are the themes available to RomFlow. Some themes may require additional plu" +
    "gins to operate.";
            // 
            // OpenThemesButton
            // 
            this.OpenThemesButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.OpenThemesButton.Location = new System.Drawing.Point(149, 89);
            this.OpenThemesButton.Name = "OpenThemesButton";
            this.OpenThemesButton.Size = new System.Drawing.Size(141, 23);
            this.OpenThemesButton.TabIndex = 6;
            this.OpenThemesButton.Text = "Open Themes Folder";
            this.OpenThemesButton.UseVisualStyleBackColor = true;
            this.OpenThemesButton.Click += new System.EventHandler(this.OpenThemesButton_Click);
            // 
            // GamepadPollRateNumericUpDown
            // 
            this.GamepadPollRateNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GamepadPollRateNumericUpDown.Location = new System.Drawing.Point(149, 6);
            this.GamepadPollRateNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.GamepadPollRateNumericUpDown.Name = "GamepadPollRateNumericUpDown";
            this.GamepadPollRateNumericUpDown.Size = new System.Drawing.Size(141, 20);
            this.GamepadPollRateNumericUpDown.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 419);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Startup";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 278F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.SystemShellComboBox, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.FullScreenStartupCheckBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.LaunchExplorerButton, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.RestartWindowsButton, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.ShutdownWindowsButton, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.RunOnLoadDataGridView, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 7);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(677, 413);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "System Shell";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 39);
            this.label6.TabIndex = 1;
            this.label6.Text = "If running as administrator you can install RomFlow as your system shell, replaci" +
    "ng windows explorer.";
            // 
            // SystemShellComboBox
            // 
            this.SystemShellComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SystemShellComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SystemShellComboBox.FormattingEnabled = true;
            this.SystemShellComboBox.Location = new System.Drawing.Point(190, 33);
            this.SystemShellComboBox.Name = "SystemShellComboBox";
            this.SystemShellComboBox.Size = new System.Drawing.Size(272, 21);
            this.SystemShellComboBox.TabIndex = 2;
            this.SystemShellComboBox.SelectedIndexChanged += new System.EventHandler(this.SystemShellComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Full Screen on Startup";
            // 
            // FullScreenStartupCheckBox
            // 
            this.FullScreenStartupCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FullScreenStartupCheckBox.AutoSize = true;
            this.FullScreenStartupCheckBox.Location = new System.Drawing.Point(190, 96);
            this.FullScreenStartupCheckBox.Name = "FullScreenStartupCheckBox";
            this.FullScreenStartupCheckBox.Size = new System.Drawing.Size(15, 14);
            this.FullScreenStartupCheckBox.TabIndex = 4;
            this.FullScreenStartupCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(481, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 26);
            this.label8.TabIndex = 5;
            this.label8.Text = "Run RomFlow as a full screen application.";
            // 
            // LaunchExplorerButton
            // 
            this.LaunchExplorerButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LaunchExplorerButton.Location = new System.Drawing.Point(190, 121);
            this.LaunchExplorerButton.Name = "LaunchExplorerButton";
            this.LaunchExplorerButton.Size = new System.Drawing.Size(130, 21);
            this.LaunchExplorerButton.TabIndex = 6;
            this.LaunchExplorerButton.Text = "Launch Explorer";
            this.LaunchExplorerButton.UseVisualStyleBackColor = true;
            this.LaunchExplorerButton.Click += new System.EventHandler(this.LaunchExplorerButton_Click);
            // 
            // RestartWindowsButton
            // 
            this.RestartWindowsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RestartWindowsButton.Location = new System.Drawing.Point(190, 148);
            this.RestartWindowsButton.Name = "RestartWindowsButton";
            this.RestartWindowsButton.Size = new System.Drawing.Size(130, 23);
            this.RestartWindowsButton.TabIndex = 7;
            this.RestartWindowsButton.Text = "Restart Windows";
            this.RestartWindowsButton.UseVisualStyleBackColor = true;
            this.RestartWindowsButton.Click += new System.EventHandler(this.RestartWindowsButton_Click);
            // 
            // ShutdownWindowsButton
            // 
            this.ShutdownWindowsButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ShutdownWindowsButton.Location = new System.Drawing.Point(190, 178);
            this.ShutdownWindowsButton.Name = "ShutdownWindowsButton";
            this.ShutdownWindowsButton.Size = new System.Drawing.Size(130, 21);
            this.ShutdownWindowsButton.TabIndex = 8;
            this.ShutdownWindowsButton.Text = "Shutdown Windows";
            this.ShutdownWindowsButton.UseVisualStyleBackColor = true;
            this.ShutdownWindowsButton.Click += new System.EventHandler(this.ShutdownWindowsButton_Click);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Background Commands";
            // 
            // RunOnLoadDataGridView
            // 
            this.RunOnLoadDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RunOnLoadDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RunOnLoadDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommandPathTextBox,
            this.CommandParametersTextBoxColumn,
            this.CommandEnabledCheckBox});
            this.tableLayoutPanel3.SetColumnSpan(this.RunOnLoadDataGridView, 3);
            this.RunOnLoadDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RunOnLoadDataGridView.Location = new System.Drawing.Point(190, 213);
            this.RunOnLoadDataGridView.Name = "RunOnLoadDataGridView";
            this.tableLayoutPanel3.SetRowSpan(this.RunOnLoadDataGridView, 2);
            this.RunOnLoadDataGridView.Size = new System.Drawing.Size(470, 156);
            this.RunOnLoadDataGridView.TabIndex = 10;
            // 
            // CommandPathTextBox
            // 
            this.CommandPathTextBox.HeaderText = "Command Path";
            this.CommandPathTextBox.Name = "CommandPathTextBox";
            // 
            // CommandParametersTextBoxColumn
            // 
            this.CommandParametersTextBoxColumn.HeaderText = "Parameters";
            this.CommandParametersTextBoxColumn.Name = "CommandParametersTextBoxColumn";
            // 
            // CommandEnabledCheckBox
            // 
            this.CommandEnabledCheckBox.HeaderText = "Enabled";
            this.CommandEnabledCheckBox.Name = "CommandEnabledCheckBox";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 65);
            this.label13.TabIndex = 11;
            this.label13.Text = "These commands will run invisibly in the background for as long as RomFlow is run" +
    "ning. This is ideal for running something like an FTP Server.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(683, 419);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Sharing";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.NetworkSharePathTextBox, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 4, 3);
            this.tableLayoutPanel4.Controls.Add(this.label10, 4, 2);
            this.tableLayoutPanel4.Controls.Add(this.InstallNetworkSharePathButton, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.ScanExternalCheckBox, 2, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(683, 419);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Network Share Path";
            // 
            // NetworkSharePathTextBox
            // 
            this.NetworkSharePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.NetworkSharePathTextBox, 3);
            this.NetworkSharePathTextBox.Location = new System.Drawing.Point(149, 12);
            this.NetworkSharePathTextBox.Name = "NetworkSharePathTextBox";
            this.NetworkSharePathTextBox.Size = new System.Drawing.Size(505, 20);
            this.NetworkSharePathTextBox.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(348, 111);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(303, 39);
            this.label11.TabIndex = 5;
            this.label11.Text = "This feature requires RomFlow to be run as an administrator as well as file shari" +
    "ng to be enabled on this computer. See the following link for more information.";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(285, 26);
            this.label10.TabIndex = 2;
            this.label10.Text = "Location on the local area network where you can find the roms folder on this com" +
    "puter";
            // 
            // InstallNetworkSharePathButton
            // 
            this.InstallNetworkSharePathButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.InstallNetworkSharePathButton.Location = new System.Drawing.Point(149, 119);
            this.InstallNetworkSharePathButton.Name = "InstallNetworkSharePathButton";
            this.InstallNetworkSharePathButton.Size = new System.Drawing.Size(160, 23);
            this.InstallNetworkSharePathButton.TabIndex = 4;
            this.InstallNetworkSharePathButton.Text = "Install Network Share Path";
            this.InstallNetworkSharePathButton.UseVisualStyleBackColor = true;
            this.InstallNetworkSharePathButton.Click += new System.EventHandler(this.InstallNetworkSharePathButton_Click);
            // 
            // ScanExternalCheckBox
            // 
            this.ScanExternalCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ScanExternalCheckBox.AutoSize = true;
            this.ScanExternalCheckBox.Location = new System.Drawing.Point(149, 171);
            this.ScanExternalCheckBox.Name = "ScanExternalCheckBox";
            this.ScanExternalCheckBox.Size = new System.Drawing.Size(169, 17);
            this.ScanExternalCheckBox.TabIndex = 6;
            this.ScanExternalCheckBox.Text = "Scan External Media for Roms";
            this.ScanExternalCheckBox.UseVisualStyleBackColor = true;
            this.ScanExternalCheckBox.CheckedChanged += new System.EventHandler(this.ScanExternalCheckBox_CheckedChanged);
            // 
            // ConfigurationEnvironmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 482);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigurationEnvironmentForm";
            this.Text = "Configure RomFlow Environment";
            this.Load += new System.EventHandler(this.ConfigurationEnvironmentForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamepadPollRateNumericUpDown)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RunOnLoadDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button RunAsAdministratorButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ThemeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button OpenThemesButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SystemShellComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox FullScreenStartupCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NetworkSharePathTextBox;
        private System.Windows.Forms.Button InstallNetworkSharePathButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown GamepadPollRateNumericUpDown;
        private System.Windows.Forms.Button LaunchExplorerButton;
        private System.Windows.Forms.Button RestartWindowsButton;
        private System.Windows.Forms.Button ShutdownWindowsButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView RunOnLoadDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommandPathTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommandParametersTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CommandEnabledCheckBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox ScanExternalCheckBox;
    }
}