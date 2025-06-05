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
using System.Security.Principal;
using System.Management;

namespace SystemMonitorApp
{
    public partial class UsersForm : Form
    {
        //WTSAPI32 imports
        [DllImport("Wtsapi32.dll")]
        private static extern bool WTSEnumerateSessions(
            IntPtr hServer,
            int Reserved,
            int Version,
            ref IntPtr ppSessionInfo,
            ref int pCount);

        [DllImport("Wtsapi32.dll")]
        private static extern void WTSFreeMemory(IntPtr pMemory);

        [DllImport("Wtsapi32.dll")]
        private static extern bool WTSQuerySessionInformation(
            IntPtr hServer,
            int sessionId,
            WTS_INFO_CLASS WTSInfoClass,
            out IntPtr ppBuffer,
            out int pBytesReturned);

        private enum WTS_INFO_CLASS
        {
            WTSUserName = 5,
            WTSDomainName = 7,
            WTSConnectState = 8
        }

        private enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,
            WTSConnected,
            WTSConnectQuery,
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
            public string pWinStationName;
            public WTS_CONNECTSTATE_CLASS State;
        }
        public UsersForm()
        {
            InitializeComponent();


        }


        private void UsersForm_Load(object sender, EventArgs e)
        {
            SetupDataGridView();

            LoadRemoteUsers();
        }
        private void SetupDataGridView()
        {
            dgvUsers.Columns.Clear();
            dgvUsers.Columns.Add("UserName", "User Name");
            dgvUsers.Columns.Add("LoggedIn", "Logged In");
            dgvUsers.Columns.Add("SessionId", "Session ID");
            dgvUsers.Columns.Add("InRDGroup", "Remote Desktop Group");
        }

        private void LoadRemoteUsers()
        {
            dgvUsers.Rows.Clear();
            IntPtr server = IntPtr.Zero;
            IntPtr sessionInfo = IntPtr.Zero;
            int sessionCount = 0;

            try
            {
                // Enumerate sessions
                bool success = WTSEnumerateSessions(IntPtr.Zero, 0, 1, ref sessionInfo, ref sessionCount);
                if (!success)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                int dataSize = Marshal.SizeOf(typeof(WTS_SESSION_INFO));
                IntPtr currentSession = sessionInfo;

                // Get all users in Remote Desktop Users group
                var rdUsers = GetRemoteDesktopUsers();

                for (int i = 0; i < sessionCount; i++)
                {
                    WTS_SESSION_INFO si = (WTS_SESSION_INFO)Marshal.PtrToStructure(currentSession, typeof(WTS_SESSION_INFO));
                    currentSession = (IntPtr)(currentSession.ToInt64() + dataSize);

                    // Get username for session
                    IntPtr buffer;
                    int bytesReturned;
                    string userName = string.Empty;
                    if (WTSQuerySessionInformation(IntPtr.Zero, si.SessionId, WTS_INFO_CLASS.WTSUserName, out buffer, out bytesReturned))
                    {
                        userName = Marshal.PtrToStringUni(buffer);
                        WTSFreeMemory(buffer);
                    }

                    if (!string.IsNullOrEmpty(userName))
                    {
                        bool isLoggedIn = si.State == WTS_CONNECTSTATE_CLASS.WTSActive || si.State == WTS_CONNECTSTATE_CLASS.WTSConnected;
                        string sessionId = isLoggedIn ? si.SessionId.ToString() : "N/A";
                        bool isInRDGroup = rdUsers.Contains(userName.ToLower());

                        dgvUsers.Rows.Add(
                            userName,
                            isLoggedIn ? "Yes" : "No",
                            sessionId,
                            isInRDGroup ? "Yes" : "No"
                        );
                    }
                }
            }
            finally
            {
                if (sessionInfo != IntPtr.Zero)
                    WTSFreeMemory(sessionInfo);
            }
        }

        private List<string> GetRemoteDesktopUsers()
        {
            List<string> rdUsers = new List<string>();
            try
            {
                using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(context, "Remote Desktop Users");
                    if (group != null)
                    {
                        foreach (Principal p in group.GetMembers())
                        {
                            rdUsers.Add(p.SamAccountName.ToLower());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving Remote Desktop Users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return rdUsers;
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (AddUserForm addUserForm = new AddUserForm())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRemoteUsers();                }
            }
        }
    }


}

