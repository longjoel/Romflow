namespace RomulatorFrontend.View
{
    partial class ConfigurationEmulatorCollection
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
            this.EmulatorCollectionTabControl = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RemoveEmulatorButton = new System.Windows.Forms.Button();
            this.AddEmulatorButton = new System.Windows.Forms.Button();
            this.DownloadEmulatorButton = new System.Windows.Forms.Button();
            this.EmulatorListingComboBox = new System.Windows.Forms.ComboBox();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.EmulatorCollectionTabControl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(772, 623);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // EmulatorCollectionTabControl
            // 
            this.EmulatorCollectionTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmulatorCollectionTabControl.Location = new System.Drawing.Point(3, 21);
            this.EmulatorCollectionTabControl.Name = "EmulatorCollectionTabControl";
            this.EmulatorCollectionTabControl.SelectedIndex = 0;
            this.EmulatorCollectionTabControl.Size = new System.Drawing.Size(766, 558);
            this.EmulatorCollectionTabControl.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 197F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel2.Controls.Add(this.RemoveEmulatorButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddEmulatorButton, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.DownloadEmulatorButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.EmulatorListingComboBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DownloadProgressBar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 585);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(766, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // RemoveEmulatorButton
            // 
            this.RemoveEmulatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveEmulatorButton.Location = new System.Drawing.Point(644, 6);
            this.RemoveEmulatorButton.Name = "RemoveEmulatorButton";
            this.RemoveEmulatorButton.Size = new System.Drawing.Size(119, 23);
            this.RemoveEmulatorButton.TabIndex = 0;
            this.RemoveEmulatorButton.Text = "Remove Emulator";
            this.RemoveEmulatorButton.UseVisualStyleBackColor = true;
            this.RemoveEmulatorButton.Click += new System.EventHandler(this.RemoveEmulatorButton_Click);
            // 
            // AddEmulatorButton
            // 
            this.AddEmulatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddEmulatorButton.Location = new System.Drawing.Point(532, 6);
            this.AddEmulatorButton.Name = "AddEmulatorButton";
            this.AddEmulatorButton.Size = new System.Drawing.Size(106, 23);
            this.AddEmulatorButton.TabIndex = 1;
            this.AddEmulatorButton.Text = "Add Emulator";
            this.AddEmulatorButton.UseVisualStyleBackColor = true;
            this.AddEmulatorButton.Click += new System.EventHandler(this.AddEmulatorButton_Click);
            // 
            // DownloadEmulatorButton
            // 
            this.DownloadEmulatorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadEmulatorButton.Location = new System.Drawing.Point(399, 6);
            this.DownloadEmulatorButton.Name = "DownloadEmulatorButton";
            this.DownloadEmulatorButton.Size = new System.Drawing.Size(127, 23);
            this.DownloadEmulatorButton.TabIndex = 2;
            this.DownloadEmulatorButton.Text = "Download Emulator";
            this.DownloadEmulatorButton.UseVisualStyleBackColor = true;
            this.DownloadEmulatorButton.Click += new System.EventHandler(this.DownloadEmulatorButton_Click);
            // 
            // EmulatorListingComboBox
            // 
            this.EmulatorListingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmulatorListingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmulatorListingComboBox.FormattingEnabled = true;
            this.EmulatorListingComboBox.Location = new System.Drawing.Point(202, 7);
            this.EmulatorListingComboBox.Name = "EmulatorListingComboBox";
            this.EmulatorListingComboBox.Size = new System.Drawing.Size(191, 21);
            this.EmulatorListingComboBox.TabIndex = 3;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DownloadProgressBar.Location = new System.Drawing.Point(3, 6);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(193, 23);
            this.DownloadProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "When you leave this form, your configuration will automatically be saved.";
            // 
            // ConfigurationEmulatorCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 623);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigurationEmulatorCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emulator Configuration";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl EmulatorCollectionTabControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button RemoveEmulatorButton;
        private System.Windows.Forms.Button AddEmulatorButton;
        private System.Windows.Forms.Button DownloadEmulatorButton;
        private System.Windows.Forms.ComboBox EmulatorListingComboBox;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Label label1;
    }
}