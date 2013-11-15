using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RomulatorFrontend
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();

            string romflowNotice = File.ReadAllText(Path.Combine(Vars.ApplicationRootPath, "RomFlowLicense.txt"));
            string sevenzipNotice = File.ReadAllText(Path.Combine(Vars.ApplicationRootPath, "7zalicense.txt"));
            string unrarNotice = File.ReadAllText(Path.Combine(Vars.ApplicationRootPath, "UnRarlicense.txt"));

            this.textBox1.Text = romflowNotice + Environment.NewLine + sevenzipNotice + Environment.NewLine + unrarNotice;

        }
    }
}
