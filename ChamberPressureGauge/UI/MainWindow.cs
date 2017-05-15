using ChamberPressureGauge.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChamberPressureGauge
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EventConfig(object sender, EventArgs e)
        {
            ConfigWindow _ConfigWindow = new ConfigWindow();
            _ConfigWindow.ShowDialog();
        }

    }
}
