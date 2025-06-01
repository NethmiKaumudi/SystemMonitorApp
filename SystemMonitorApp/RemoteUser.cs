using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitorApp
{
    internal class RemoteUser
    {
        public string Username { get; set; }
        public int SessionId { get; set; }
        public string SessionState { get; set; }
    }
}
