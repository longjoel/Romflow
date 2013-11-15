using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomulatorFrontend.View
{
    public partial class ConfigurationGamePad : UserControl
    {
        private Model.Gamepad _gamepad;
        private Model.ConfigurationGamePad _gamepadConf;

        public ConfigurationGamePad(Model.Gamepad g, Model.ConfigurationGamePad gConf)
        {
            _gamepad = g;
            _gamepadConf = gConf;
            InitializeComponent();

            if ( gConf != null)
                this.LoadFromConfig();

        }

        public ConfigurationGamePad()
            : this(null, null)
        {
        }


        private void DPadPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_gamepad == null)
            {
                e.Graphics.FillEllipse(Brushes.Gray, DPadPictureBox.ClientRectangle);
                return;
            }
            e.Graphics.FillEllipse(Brushes.Black, DPadPictureBox.ClientRectangle);


            if (_gamepad.DirectionalPad == Model.DPadEnum.Up)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, -90 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.UpRight)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, -45 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.Right)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 0 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.DownRight)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 45 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.Down)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 90 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.UpLeft)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 225 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.Left)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 180 - 22.5f, 45);
            }

            if (_gamepad.DirectionalPad == Model.DPadEnum.DownLeft)
            {
                e.Graphics.FillPie(Brushes.Green, DPadPictureBox.ClientRectangle, 135 - 22.5f, 45);
            }
        }

        private void ButtonsPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var crx = ButtonsPictureBox.ClientRectangle.Width / 16.0;
            if (_gamepad == null)
            {
                e.Graphics.FillRectangle(Brushes.Gray, ButtonsPictureBox.ClientRectangle);
                return;
            }
            e.Graphics.FillRectangle(Brushes.Black, ButtonsPictureBox.ClientRectangle);


            for (int x = 0; x < 16; x++)
            {
                if (_gamepad.Buttons[x] == true)
                {
                    e.Graphics.FillRectangle(Brushes.Green, new Rectangle((int)(Math.Ceiling(x * crx)),
                        0,
                        (int)(crx),
                        ButtonsPictureBox.ClientRectangle.Height));
                }
            }

        }

        private void GamepadPollingTimer_Tick(object sender, EventArgs e)
        {
            if (_gamepad != null && this.Visible)
            {
                ButtonsPictureBox.Invalidate();
                DPadPictureBox.Invalidate();
            }
        }

        private void SaveToConfig()
        {
            if (_gamepadConf != null)
            {
                _gamepadConf.NavigateBackButton = NavigateBackComboBox.Text;
                _gamepadConf.NavigateDownButton = NavigateDownComboBox.Text;
                _gamepadConf.NavigateForwardButton = NavigateEnterComboBox.Text;
                _gamepadConf.NavigateLeftButton = NavigateLeftComboBox.Text;
                _gamepadConf.NavigateRightButton = NavigateRightComboBox.Text;
                _gamepadConf.NavigateUpButton = NavigateUpComboBox.Text;

                _gamepadConf.QuickLoadCombo = QuickLoadComboTextBox.Text;
                _gamepadConf.QuickSaveCombo = QuickSaveComboTextBox.Text;
                _gamepadConf.QuitCombo = ComboQuitTextBox.Text;
            }
        }

        private void LoadFromConfig()
        {
            if (_gamepadConf != null)
            {
                NavigateBackComboBox.Text = _gamepadConf.NavigateBackButton;
                NavigateDownComboBox.Text = _gamepadConf.NavigateDownButton;
                NavigateEnterComboBox.Text = _gamepadConf.NavigateForwardButton;
                NavigateLeftComboBox.Text = _gamepadConf.NavigateLeftButton;
                NavigateRightComboBox.Text = _gamepadConf.NavigateRightButton;
                NavigateUpComboBox.Text = _gamepadConf.NavigateUpButton;

                QuickLoadComboTextBox.Text = _gamepadConf.QuickLoadCombo;
                QuickSaveComboTextBox.Text = _gamepadConf.QuickSaveCombo;
                ComboQuitTextBox.Text = _gamepadConf.QuitCombo;
            }
        }

        private void ConfigurationGamePad_Load(object sender, EventArgs e)
        {

            var parent = FindForm();
            if (parent != null)
                parent.FormClosed += (o, ex) => { SaveToConfig(); };
        }

    }
}
