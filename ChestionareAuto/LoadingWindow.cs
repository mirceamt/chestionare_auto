using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChestionareAuto
{
    public partial class LoadingWindow : Form
    {
        private int stp = 0;
        public LoadingWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            stp = 5 + creareChestionarProgressBar.Maximum / creareChestionarProgressBar.Step;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            creareChestionarProgressBar.Increment(creareChestionarProgressBar.Step);
            --stp;
            if (stp == 0)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
