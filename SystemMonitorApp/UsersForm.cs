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
                var users = new List<RemoteUser>();
                IntPtr pSessionInfo = IntPtr.Zero;
                int count = 0;

                // Enumerate sessions on the local machine (IntPtr.Zero for current server)
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

                        // Skip session ID 0 (system session)
                        if (sessionInfo.SessionId == 0) continue;

                        // Get username
                        IntPtr pUserName = IntPtr.Zero;
                        int bytesReturned;
                        string username = "";
                        if (WTSQuerySessionInformation(IntPtr.Zero, sessionInfo.SessionId, WTS_INFO_CLASS.WTSUserName, out pUserName, out bytesReturned))
                        {
                            username = Marshal.PtrToStringUni(pUserName);
                            WTSFreeMemory(pUserName);
                        }

                        // Skip if no username (e.g., system sessions)
                        if (string.IsNullOrEmpty(username)) continue;

                        // Get session state
                        string state = sessionInfo.State.ToString();

                        users.Add(new RemoteUser
                        {
                            Username = username,
                            SessionId = sessionInfo.SessionId,
                            SessionState = state
                        });
                    }
                }
                finally
                {
                    WTSFreeMemory(pSessionInfo);
                }

                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}");
            }
        }
    }

}

