using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
namespace RainTheme
{
    public partial class MainPage : UserControl
    {
        ScriptHost _scriptHost = null;


        System.Windows.Controls.ChildWindow _cw;

        int _selectedListBoxIndex;

        List<ListBox> _listBoxes;

        public MainPage()
        {
            InitializeComponent();

            _scriptHost = new ScriptHost(() =>
            {
                if (_listBoxes[_selectedListBoxIndex].SelectedIndex > 0)
                    _listBoxes[_selectedListBoxIndex].SelectedIndex--;
            },
                () =>
                {
                    if (_listBoxes[_selectedListBoxIndex].SelectedIndex < _listBoxes[_selectedListBoxIndex].Items.Count - 1)
                        _listBoxes[_selectedListBoxIndex].SelectedIndex++;
                },
                () =>
                {
                    if (_selectedListBoxIndex > 0)
                        _selectedListBoxIndex--;
                    SetActiveGridbox();
                },
                () =>
                {
                    if (_selectedListBoxIndex < _listBoxes.Count - 1)
                        _selectedListBoxIndex++;
                    SetActiveGridbox();
                },
                () => { Execute(); },
                () => { },
                () =>
                {
                    if (_cw != null)
                        _cw.Close();
                });

            HtmlPage.RegisterScriptableObject("RFSO", _scriptHost);


            RefreshEmulators();

            _listBoxes = new List<ListBox>() { EmulatorsListBox, RomsListBox, SettingsListBox };
            _selectedListBoxIndex = 0;
            SetActiveGridbox();

            this.ShareName.Text = (string)HtmlPage.Window.Eval("fetchSharePath();");
        }

        public void SetActiveGridbox()
        {
            for (int i = 0; i < _listBoxes.Count; i++)
            {
                if (i != _selectedListBoxIndex)
                {
                    _listBoxes[i].Background = new LinearGradientBrush(new GradientStopCollection() 
                    {
                        new GradientStop(){Color = Color.FromArgb((byte)0x9b, (byte)0x00, (byte)0x00, (byte)0x00),
                        Offset = 0.221},
                        new GradientStop(){Color = Color.FromArgb((byte)0x06, (byte)0xFF, (byte)0xFF, (byte)0xFF),
                        Offset = 1}
                    }, 90);
                }
                else
                {
                    _listBoxes[i].Background = new SolidColorBrush(Colors.Black);
                }
            }
        }

        public void RefreshEmulators()
        {

            var emulatorStrings = ((ScriptObject)HtmlPage.Window.Eval("fetchEmulators();"))
                .ConvertTo<List<string>>();// ((string[])HtmlPage.Window.Eval("fetchEmulators();"));

            EmulatorsListBox.Items.Clear();

            foreach (var e in emulatorStrings)
            {
                EmulatorsListBox.Items.Add(e);
            }

            if (EmulatorsListBox.Items.Count > 0)
            {
                EmulatorsListBox.SelectedIndex = 0;

            }
        }

        public void RefreshRoms()
        {
            var emulator = EmulatorsListBox.Items[EmulatorsListBox.SelectedIndex];

            var roms = ((ScriptObject)HtmlPage.Window.Eval("fetchRoms('" + emulator + "');"))
                .ConvertTo<List<string>>();
            RomsListBox.Items.Clear();

            foreach (var r in roms)
            {
                RomsListBox.Items.Add(r);
            }

            if (RomsListBox.Items.Count > 0)
                RomsListBox.SelectedIndex = 0;

        }

        private void EmulatorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshRoms();
        }

        private void Execute()
        {

            if (RomsListBox.SelectedIndex >= 0 && EmulatorsListBox.SelectedIndex >= 0 &&
                _listBoxes[_selectedListBoxIndex] == RomsListBox)
            {
                var rom = RomsListBox.SelectedItem.ToString();

                var emu = EmulatorsListBox.SelectedItem.ToString();

                if (emu.Trim().Any() && rom.Trim().Any())
                {
                    //MessageBox.Show(string.Format("exeRom('{0}', '{1}');", emu, rom));
                    HtmlPage.Window.Eval(string.Format("exeRom('{0}', '{1}');", emu, rom));

                    _cw = new ChildWindow();
                    _cw.Title = null;
                    _cw.HasCloseButton = false;
                    _cw.OverlayOpacity = 1.0;
                    _cw.OverlayBrush = new SolidColorBrush(Colors.Black);
                    _cw.Show();
                }
            } else 

            if (_listBoxes[_selectedListBoxIndex] == SettingsListBox)
            {
                //MessageBox.Show("!");
                if (SettingsListBox.SelectedIndex == 0)
                {
                    HtmlPage.Window.Eval("reboot();");
                }

                if (SettingsListBox.SelectedIndex == 1)
                {
                    HtmlPage.Window.Eval("shutdown();");
                }

            }

        }


        private void RomsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || e.Key == Key.Enter)
                Execute();
        }


        private void ListBoxActivate(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < _listBoxes.Count; i++)
            {
                if (_listBoxes[i] == sender)
                    _selectedListBoxIndex = i;
            }

            Dispatcher.BeginInvoke(() => ((ListBox)sender).Focus());

            SetActiveGridbox();
        }


    }
}
