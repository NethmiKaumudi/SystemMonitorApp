using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemMonitorApp
{
    public partial class ServicesForm : Form
    {
        public ServicesForm()
        {
            InitializeComponent();
            LoadServices();
            dgvServices.SelectionChanged += DgvServices_SelectionChanged;
        }
        private void LoadServices()
        {
            var services = ServiceController.GetServices()
                .Select(s => new
                {
                    s.ServiceName,
                    s.DisplayName,
                    Status = s.Status.ToString()
                })
                .ToList();
            dgvServices.DataSource = services;
        }

        private void DgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvServices.SelectedRows[0];
                string status = selectedRow.Cells["Status"].Value.ToString();
                btnStart.Enabled = status != "Running";
                btnStop.Enabled = status == "Running";
            }
            else
            {
                btnStart.Enabled = false;
                btnStop.Enabled = false;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceName = dgvServices.SelectedRows[0].Cells["ServiceName"].Value.ToString();
                try
                {
                    using (var service = new ServiceController(serviceName))
                    {
                        if (service.Status != ServiceControllerStatus.Running)
                        {
                            service.Start();
                            service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                            MessageBox.Show("Service started successfully.");
                            LoadServices();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting service: {ex.Message}");
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceName = dgvServices.SelectedRows[0].Cells["ServiceName"].Value.ToString();
                try
                {
                    using (var service = new ServiceController(serviceName))
                    {
                        if (service.Status == ServiceControllerStatus.Running)
                        {
                            service.Stop();
                            service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
                            MessageBox.Show("Service stopped successfully.");
                            LoadServices();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error stopping service: {ex.Message}");
                }
            }
        
    }
    }
}
