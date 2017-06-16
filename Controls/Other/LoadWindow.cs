using System;
using System.Windows.Forms;

namespace Controls.Other
{
    public partial class LoadWindow : Form
    {
        public event Action CancelFun;
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
            lblInfo.Top = (Height - lblInfo.Height) / 2;
            lblInfo.Left = (Width - lblInfo.Width) / 2;
            picLoading.Left = lblInfo.Left - picLoading.Width - 5;
            btnCancel.Hide();
            if (CancelFun == null) return;
            lblInfo.Top -= btnCancel.Height / 2;
            btnCancel.Show();
            //btnCancel.Visible = CancelFun != null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelFun?.Invoke();
        }
    }
}
