using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;

namespace SystemMonitorApp
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
        }

        private void UsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern bool WTSEnumerateSessions(
       IntPtr hServer,
       int Reserved,
       int Version,
       ref IntPtr ppSessionInfo,
       ref int pCount);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            int sessionId,
            WTS_INFO_CLASS wtsInfoClass,
            out IntPtr ppBuffer,
            out int pBytesReturned);

        [DllImport("wtsapi32.dll", SetLastError = true)]
        private static extern bool WTSQueryUserToken(int SessionId, out IntPtr phToken);

        private enum WTS_INFO_CLASS
        {
            WTSUserName = 5,
            WTSWinStationName = 7,
            WTSState = 8
        }

        private enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
            WTSShadow,
            WTSDisconnected,
            WTSIdle,
            WTSListen,
            WTSReset,
            WTSDown,
            WTSInit
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WTS_SESSION_INFO
        {
            public int SessionId;
            public IntPtr pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }

        private void LoadUsers()
        {
            try
            {
                var allWindowsUsers = new List<RemoteUser>(); // For dgvWindowsUsers (all users)
                var remoteUsers = new List<RemoteUser>();     // For dgvUsers (active sessions only)
                var activeSessions = new Dictionary<int, string>(); // Map session ID to username

                // Step 1: Get all active sessions to determine logged-in users
                IntPtr pSessionInfo = IntPtr.Zero;
                int count = 0;
                bool success = WTSEnumerateSessions(IntPtr.Zero, 0, 1, ref pSessionInfo, ref count);
                if (!success)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                try
                {
                    IntPtr current = pSessionInfo;
                    for (int i = 0; i < count; i++)
                    {
                        WTS_SESSION_INFO sessionInfo = (WTS_SESSION_INFO)Marshal.PtrToStructure(current, typeof(WTS_SESSION_INFO));
                        current = IntPtr.Add(current, Marshal.SizeOf(typeof(WTS_SESSION_INFO)));

                        if (sessionInfo.SessionId == 0) continue;

                        IntPtr pUserName = IntPtr.Zero;
                        int bytesReturned;
                        string username = "";
                        if (WTSQuerySessionInformation(IntPtr.Zero, sessionInfo.SessionId, WTS_INFO_CLASS.WTSUserName, out pUserName, out bytesReturned))
                        {
                            username = Marshal.PtrToStringUni(pUserName);
                            WTSFreeMemory(pUserName);
                        }

                        if (!string.IsNullOrEmpty(username))
                        {
                            activeSessions[sessionInfo.SessionId] = username;

                            // Add to remoteUsers list (for dgvUsers)
                            string state = sessionInfo.State.ToString();
                            string remoteAccess = IsUserInRemoteDesktopUsers(username) ? "Yes" : "No";

                            remoteUsers.Add(new RemoteUser
                            {
                                Username = username,
                                SessionId = sessionInfo.SessionId,
                                SessionState = state == "WTSActive" ? "Active" : "Disconnected",
                                RemoteAccess = remoteAccess
                            });
                        }
                    }
                }
                finally
                {
                    WTSFreeMemory(pSessionInfo);
                }

                // Step 2: Get all local users (for dgvWindowsUsers)
                try
                {
                    using (var context = new PrincipalContext(ContextType.Machine))
                    using (var userPrincipal = new UserPrincipal(context))
                    using (var searcher = new PrincipalSearcher(userPrincipal))
                    {
                        foreach (var result in searcher.FindAll())
                        {
                            var user = result as UserPrincipal;
                            if (user != null)
                            {
                                string username = user.SamAccountName;
                                bool isLoggedIn = activeSessions.Values.Contains(username);
                                int? sessionId = isLoggedIn ? activeSessions.FirstOrDefault(x => x.Value == username).Key : (int?)null;
                                string sessionState = isLoggedIn ? "Active" : "Disconnected";
                                string remoteAccess = IsUserInRemoteDesktopUsers(username) ? "Yes" : "No";

                                allWindowsUsers.Add(new RemoteUser
                                {
                                    Username = username,
                                    SessionId = sessionId,
                                    SessionState = sessionState,
                                    RemoteAccess = remoteAccess
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to retrieve local users.", ex);
                }

                // Step 3: Bind data to DataGridViews
                // Bind all Windows users to dgvWindowsUsers
                dgvWindowsUsers.DataSource = null;
                dgvWindowsUsers.DataSource = allWindowsUsers;
                if (dgvWindowsUsers.Columns["SessionId"] != null)
                {
                    dgvWindowsUsers.Columns["SessionId"].Visible = true;
                    dgvWindowsUsers.Columns["SessionId"].HeaderText = "Session ID";
                    foreach (DataGridViewRow row in dgvWindowsUsers.Rows)
                    {
                        if (row.Cells["SessionState"].Value?.ToString() != "Active")
                        {
                            row.Cells["SessionId"].Value = DBNull.Value;
                        }
                    }
                }

                // Bind remote users (active sessions) to dgvUsers
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = remoteUsers;
                if (dgvUsers.Columns["SessionId"] != null)
                {
                    dgvUsers.Columns["SessionId"].Visible = true;
                    dgvUsers.Columns["SessionId"].HeaderText = "Session ID";
                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {
                        if (row.Cells["SessionState"].Value?.ToString() != "Active")
                        {
                            row.Cells["SessionId"].Value = DBNull.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvWindowsUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                try
                {
                    DataGridViewRow row = dgvWindowsUsers.Rows[e.RowIndex];
                    string username = row.Cells["Username"].Value?.ToString();
                    string currentRemoteAccess = row.Cells["RemoteAccess"].Value?.ToString();

                    if (string.IsNullOrEmpty(username))
                    {
                        MessageBox.Show("Invalid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool hasRemoteAccess = currentRemoteAccess == "Yes";
                    bool newRemoteAccess = !hasRemoteAccess; // Toggle the access

                    using (var context = new PrincipalContext(ContextType.Machine))
                    {
                        using (var user = UserPrincipal.FindByIdentity(context, username))
                        {
                            if (user == null)
                            {
                                MessageBox.Show($"User '{username}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            using (var rdpGroup = GroupPrincipal.FindByIdentity(context, "Remote Desktop Users"))
                            {
                                if (rdpGroup == null)
                                {
                                    MessageBox.Show("Remote Desktop Users group not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (newRemoteAccess)
                                {
                                    rdpGroup.Members.Add(user);
                                    MessageBox.Show($"Remote access granted to '{username}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    rdpGroup.Members.Remove(user);
                                    MessageBox.Show($"Remote access revoked for '{username}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                rdpGroup.Save();
                            }
                        }
                    }

                    // Refresh the tables to reflect the change
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error toggling remote access: {ex.Message}\nInner Exception: {ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        private bool IsUserInRemoteDesktopUsers(string username)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-Command \"(Get-LocalGroupMember -Group 'Remote Desktop Users' | Where-Object {{ $_.Name -eq '{Environment.MachineName}\\{username}' }}).Name -ne $null\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                    string output = process.StandardOutput.ReadToEnd().Trim();
                    string error = process.StandardError.ReadToEnd();
                    if (process.ExitCode != 0)
                    {
                        throw new Exception($"PowerShell error: {error}");
                    }
                    return !string.IsNullOrEmpty(output);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking remote access for {username}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public (int loggedIn, int loggedOut) GetUserStats()
        {
            int loggedIn = 0, loggedOut = 0;
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                if (row.Cells["SessionState"].Value?.ToString() == "Active")
                    loggedIn++;
                else
                    loggedOut++;
            }
            return (loggedIn, loggedOut);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click_1(object sender, EventArgs e)
        {
                using (AddUserForm addUserForm = new AddUserForm())
                {
                    if (addUserForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
            }
    }


}

