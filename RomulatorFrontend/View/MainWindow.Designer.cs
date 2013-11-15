namespace RomulatorFrontend.View
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PrimaryMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.romulationConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamepadsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RootWebBrowser = new System.Windows.Forms.WebBrowser();
            this.ControllerPollingTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.PrimaryMainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.PrimaryMainMenuStrip, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RootWebBrowser, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(744, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PrimaryMainMenuStrip
            // 
            this.PrimaryMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.romulationConfigurationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.PrimaryMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.PrimaryMainMenuStrip.Name = "PrimaryMainMenuStrip";
            this.PrimaryMainMenuStrip.Size = new System.Drawing.Size(744, 24);
            this.PrimaryMainMenuStrip.TabIndex = 0;
            this.PrimaryMainMenuStrip.Text = "menuStrip1";
            // 
            // romulationConfigurationToolStripMenuItem
            // 
            this.romulationConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamepadsToolStripMenuItem,
            this.emulatorsToolStripMenuItem,
            this.systemConfigurationToolStripMenuItem});
            this.romulationConfigurationToolStripMenuItem.Name = "romulationConfigurationToolStripMenuItem";
            this.romulationConfigurationToolStripMenuItem.Size = new System.Drawing.Size(158, 20);
            this.romulationConfigurationToolStripMenuItem.Text = "Romulation Configuration";
            // 
            // gamepadsToolStripMenuItem
            // 
            this.gamepadsToolStripMenuItem.Name = "gamepadsToolStripMenuItem";
            this.gamepadsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gamepadsToolStripMenuItem.Text = "Gamepads";
            this.gamepadsToolStripMenuItem.Click += new System.EventHandler(this.gamepadsToolStripMenuItem_Click);
            // 
            // emulatorsToolStripMenuItem
            // 
            this.emulatorsToolStripMenuItem.Name = "emulatorsToolStripMenuItem";
            this.emulatorsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.emulatorsToolStripMenuItem.Text = "Emulators";
            this.emulatorsToolStripMenuItem.Click += new System.EventHandler(this.emulatorsToolStripMenuItem_Click);
            // 
            // systemConfigurationToolStripMenuItem
            // 
            this.systemConfigurationToolStripMenuItem.Name = "systemConfigurationToolStripMenuItem";
            this.systemConfigurationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.systemConfigurationToolStripMenuItem.Text = "System Configuration";
            this.systemConfigurationToolStripMenuItem.Click += new System.EventHandler(this.systemConfigurationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // RootWebBrowser
            // 
            this.RootWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootWebBrowser.Location = new System.Drawing.Point(0, 24);
            this.RootWebBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.RootWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.RootWebBrowser.Name = "RootWebBrowser";
            this.RootWebBrowser.Size = new System.Drawing.Size(744, 424);
            this.RootWebBrowser.TabIndex = 1;
            // 
            // ControllerPollingTimer
            // 
            this.ControllerPollingTimer.Enabled = true;
            this.ControllerPollingTimer.Interval = 250;
            this.ControllerPollingTimer.Tick += new System.EventHandler(this.ControllerPollingTImer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "ROMFlow (Limited Alpha)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PrimaryMainMenuStrip.ResumeLayout(false);
            this.PrimaryMainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip PrimaryMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem romulationConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamepadsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emulatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.WebBrowser RootWebBrowser;
        private System.Windows.Forms.Timer ControllerPollingTimer;
    }
}

