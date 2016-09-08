using cc.legacy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Commands {
    public class TerminalConnect {
        internal System.Net.Sockets.Socket TerminalSocket;

        public void ConnectToTerminal(ITerminal Terminal) {
            CreateNewSocket();
            BindConnection(Terminal.TerminalAddress, Terminal.TerminalPort);
            TestConnection();
        }

        private void CreateNewSocket(){
            TerminalSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        private Boolean BindConnection(IPAddress TerminalAddress, Int16 TerminalPort) {
            System.Net.IPEndPoint _remoteEndPoint = new System.Net.IPEndPoint(TerminalAddress, TerminalPort);
            IAsyncResult result = TerminalSocket.BeginConnect(TerminalAddress, TerminalPort, null, null);
            return result.AsyncWaitHandle.WaitOne(new TimeSpan(0, 0, 10), true);
        }

        private void TestConnection() {
            if (!TerminalSocket.Connected) {
                TerminalSocket.Close();
                throw new ApplicationException("Failed to connect terminal.");
            }
        }
    }
}
