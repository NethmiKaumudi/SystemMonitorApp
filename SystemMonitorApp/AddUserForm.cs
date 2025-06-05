using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SystemMonitorApp
{
    public partial class AddUserForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool EnableRemoteAccess { get; private set; }
        public AddUserForm()
        {
            InitializeComponent();
           
        }
     
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.Text.Length < 8 || !txtPassword.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Username = txtUserName.Text;
            Password = txtPassword.Text;
            EnableRemoteAccess = chkRemoteAccess.Checked;

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                // Create local user
                psi.Arguments = $"-Command \"New-LocalUser -Name '{Username}' -Password (ConvertTo-SecureString '{Password}' -AsPlainText -Force) -FullName '{Username}' -Description 'Created via App'\"";
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        string error = process.StandardError.ReadToEnd();
                        throw new Exception($"User creation failed: {error}");
                    }
                }

                // Add to Users group (normal user group)
                psi.Arguments = $"-Command \"Add-LocalGroupMember -Group 'Users' -Member '{Username}'\"";
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                    {
                        string error = process.StandardError.ReadToEnd();
                        throw new Exception($"Adding to Users group failed: {error}");
                    }
                }

                // Add to Remote Desktop Users group if enabled
                if (EnableRemoteAccess)
                {
                    psi.Arguments = $"-Command \"Add-LocalGroupMember -Group 'Remote Desktop Users' -Member '{Username}'\"";
                    using (Process process = Process.Start(psi))
                    {
                        process.WaitForExit();
                        if (process.ExitCode != 0)
                        {
                            string error = process.StandardError.ReadToEnd();
                            throw new Exception($"Adding to Remote Desktop Users group failed: {error}");
                        }
                    }
                }

                // Success message and close
                MessageBox.Show($"User '{Username}' created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
