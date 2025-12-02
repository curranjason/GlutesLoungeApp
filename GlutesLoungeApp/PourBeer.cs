using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlutesLoungeApp
{
    public partial class PourBeer : Form
    {
        public PourBeer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Show owner (main form) if set, otherwise try to find Form1 in open forms
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
            else
            {
                var main = Application.OpenForms.OfType<GlutesForm>().FirstOrDefault();
                main?.Show();
            }

            this.Close();
        }
    }
}