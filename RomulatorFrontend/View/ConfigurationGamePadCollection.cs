using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomulatorFrontend.View
{
    public partial class ConfigurationGamePadCollection : Form
    {
        private Model.ConfigurationRoot _root;
        private Model.GamepadCollection _gamePads;

        public ConfigurationGamePadCollection(Model.ConfigurationRoot root, Model.GamepadCollection pads)
        {
            InitializeComponent();

            _root = root;
            _gamePads = pads;


            if (_root != null)
            {
                if (_root.Gamepads == null)
                {
                    _root.Gamepads = new Model.ConfigurationGamePadCollection();

                }
            }

            LoadData();
        }

        private void LoadData()
        {
            if (_root == null)
                return;



            for (int i = 0; i < _root.Gamepads.GamePadInformation.Count; i++)
            {
                ConfigurationGamePad gpx = null;
                if (i < _gamePads.Count())
                    gpx = new ConfigurationGamePad(_gamePads[i], _root.Gamepads.GamePadInformation[i]);
                else
                    gpx = new ConfigurationGamePad(null, _root.Gamepads.GamePadInformation[i]);

                var tp = new TabPage("Game pad:" + (i + 1).ToString());
                tp.Controls.Add(gpx);
                gpx.Dock = DockStyle.Fill;

                this.GamePadsTabControls.Controls.Add(tp);
            }
        }

        public ConfigurationGamePadCollection()
            : this(null, null)
        {
        }

        private void AddGamepadButton_Click(object sender, EventArgs e)
        {
            _root.Gamepads.GamePadInformation.Add(new Model.ConfigurationGamePad());

            var i = _root.Gamepads.GamePadInformation.Count - 1;
            ConfigurationGamePad gpx = null;

            if (i < _gamePads.Count())
            {
                gpx = new ConfigurationGamePad(_gamePads[i], _root.Gamepads.GamePadInformation[i]);
            }

            else
            {
                gpx = new ConfigurationGamePad(null, _root.Gamepads.GamePadInformation[i]);
            }

            var tp = new TabPage("Game pad:" + (i + 1).ToString());
            tp.Controls.Add(gpx);
            gpx.Dock = DockStyle.Fill;

            this.GamePadsTabControls.TabPages.Add(tp);

        }

        private void RemoveGamepadButton_Click(object sender, EventArgs e)
        {
            var si = GamePadsTabControls.SelectedIndex;
            if (si != -1)
            {
                _root.Gamepads.GamePadInformation.RemoveAt(si);
                GamePadsTabControls.Controls.Remove(GamePadsTabControls.TabPages[si]);
            }
        }
    }
}
