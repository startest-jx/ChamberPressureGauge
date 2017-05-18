using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChamberPressureGauge.UI
{
    public partial class ConfigWindow : Form
    {
        Thread cThread = null;  // 主控板接收线程
        Thread dThread = null;  // 数位板接收线程

        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
