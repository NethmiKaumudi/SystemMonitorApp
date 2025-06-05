using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitorApp
{
    public partial class WelcomePage : Form
    {
        public WelcomePage()
        {
            InitializeComponent();
            StartTimer();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void StartTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 3000 }; // 3 seconds
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += (sender, args) => Application.Exit();
                mainForm.Show();
            };
            timer.Start();
        }
    }
}

