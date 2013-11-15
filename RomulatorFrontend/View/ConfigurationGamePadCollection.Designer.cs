namespace RomulatorFrontend.View
{
    partial class ConfigurationGamePadCollection
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
            this.GamePadsTabControls = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddGamepadButton = new System.Windows.Forms.Button();
            this.RemoveGamepadButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.GamePadsTabControls, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GamePadsTabControls
            // 
            this.GamePadsTabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamePadsTabControls.Location = new System.Drawing.Point(3, 3);
            this.GamePadsTabControls.Name = "GamePadsTabControls";
            this.GamePadsTabControls.SelectedIndex = 0;
            this.GamePadsTabControls.Size = new System.Drawing.Size(636, 303);
            this.GamePadsTabControls.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.AddGamepadButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RemoveGamepadButton, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 312);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(636, 26);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // AddGamepadButton
            // 
            this.AddGamepadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddGamepadButton.Location = new System.Drawing.Point(421, 3);
            this.AddGamepadButton.Name = "AddGamepadButton";
            this.AddGamepadButton.Size = new System.Drawing.Size(92, 20);
            this.AddGamepadButton.TabIndex = 0;
            this.AddGamepadButton.Text = "Add Gamepad";
            this.AddGamepadButton.UseVisualStyleBackColor = true;
            this.AddGamepadButton.Click += new System.EventHandler(this.AddGamepadButton_Click);
            // 
            // RemoveGamepadButton
            // 
            this.RemoveGamepadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveGamepadButton.Location = new System.Drawing.Point(519, 3);
            this.RemoveGamepadButton.Name = "RemoveGamepadButton";
            this.RemoveGamepadButton.Size = new System.Drawing.Size(114, 20);
            this.RemoveGamepadButton.TabIndex = 1;
            this.RemoveGamepadButton.Text = "Remove Gamepad";
            this.RemoveGamepadButton.UseVisualStyleBackColor = true;
            this.RemoveGamepadButton.Click += new System.EventHandler(this.RemoveGamepadButton_Click);
            // 
            // ConfigurationGamePadCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConfigurationGamePadCollection";
            this.Text = "Configure Gamepads";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl GamePadsTabControls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button AddGamepadButton;
        private System.Windows.Forms.Button RemoveGamepadButton;
    }
}