using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace SystemMonitorApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateHomePage();
            Timer timer = new Timer { Interval = 1000 };
            timer.Tick += (s, e) => UpdateHomePage();
            timer.Start();
        }
        private void UpdateHomePage()
        {
            lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy HH:mm:ss");
            lblIP.Text = $"IP Address: {GetLocalIPAddress()}";
            lblRDP.Text = $"Remote Desktop: {(IsRDPEnabled() ? "Running" : "Not Running")}";
            var (loggedIn, loggedOut) = GetUserStats();
            lblUserStats.Text = $"Logged In Users: {loggedIn}\nLogged Out Users: {loggedOut}";
            var (running, notRunning) = GetServiceStats();
            lblServices.Text = $"Running Services: {running}\nNot Running Services: {notRunning}";
        }
        private (int running, int notRunning) GetServiceStats()
        {
            try
            {
                var services = ServiceController.GetServices();
                int running = services.Count(s => s.Status == ServiceControllerStatus.Running);
                int notRunning = services.Length - running;
                return (running, notRunning);
            }
            catch
            {
                return (0, 0);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            btnHome.BackColor = Color.FromArgb(0, 170, 255);
            btnUsers.BackColor = btnServices.BackColor = Color.FromArgb(0, 120, 215);
            homePanel.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(homePanel);
            UpdateHomePage();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            btnServices.BackColor = Color.FromArgb(0, 170, 255);
            btnHome.BackColor = btnUsers.BackColor = Color.FromArgb(0, 120, 215);
            ServicesForm servicesForm = new ServicesForm();
            servicesForm.TopLevel = false;
            servicesForm.FormBorderStyle = FormBorderStyle.None;
            servicesForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(servicesForm);
            servicesForm.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            btnUsers.BackColor = Color.FromArgb(0, 170, 255);
            btnHome.BackColor = btnServices.BackColor = Color.FromArgb(0, 120, 215);
            UsersForm usersForm = new UsersForm();
            usersForm.TopLevel = false;
            usersForm.FormBorderStyle = FormBorderStyle.None;
            usersForm.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(usersForm);
            usersForm.Show();

        }
        private string GetLocalIPAddress()
        {
            try
            {
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }
            catch { }
            return "Unknown";
        }

        private bool IsRDPEnabled()
        {
            try
            {
                using (var process = new Process())
                {
                    process.StartInfo.FileName = "reg";
                    process.StartInfo.Arguments = "query \"HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\Terminal Server\" /v fDenyTSConnections";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return !output.Contains("0x0");
                }
            }
            catch { }
            return false;
        }

        private (int loggedIn, int loggedOut) GetUserStats()
        {
            // Placeholder, implemented in UsersForm
            return (0, 0);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblIP_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
