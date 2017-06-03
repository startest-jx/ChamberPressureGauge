using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChamberPressureGauge.UI
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void CheckIP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal)
            {
                int pos = ((MaskedTextBox)sender).SelectionStart;
                int max = (((MaskedTextBox)sender).MaskedTextProvider.Length - ((MaskedTextBox)sender).MaskedTextProvider.EditPositionCount);
                int nextField = 0;

                for (int i = 0; i < ((MaskedTextBox)sender).MaskedTextProvider.Length; i++)
                {
                    if (!((MaskedTextBox)sender).MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                        nextField = i;
                }
                nextField += 1;

                // We're done, enable the TabStop property again     


                ((MaskedTextBox)sender).SelectionStart = nextField;

            }
        }
    }
}
