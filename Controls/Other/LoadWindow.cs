using System;
using System.Windows.Forms;

namespace Controls.Other
{
    public partial class LoadWindow : Form
    {
        public LoadWindow()
        {
            InitializeComponent();
        }

        public void Message(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { Message(text); }));
                return;
            }
            lblInfo.Text = text;
        }
    }
}
