using cc.legacy.Functions;
using cc.legacy.Interfaces;
using cc.legacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Commands {
    public class TerminalLogs : TerminalConnect {
        internal Byte[] RequestByte;
        internal Byte[] ReplyByte;
        internal Int32 Pointer;

        public List<TerminalLog> Logs;

        private void InitaliseBytes() {
            RequestByte = new Byte[8];
            ReplyByte = new Byte[15000];
        }

        private void InitaliseRequestPacket() {
            RequestByte[0] = 0x5B;
            
            RequestByte[1] = 0x05;
            RequestByte[2] = 0; 
            
            RequestByte[3] = 0;
            RequestByte[4] = 0;
            RequestByte[5] = 0;
            RequestByte[6] = 0x90;
            RequestByte[7] = 0;
        }

        private void ProcessRequest() {
            TerminalSocket.Send(RequestByte);
            TerminalSocket.Receive(ReplyByte);
        }

        private void InitaliseTerminalLogs() {
            Pointer = 0;
            Logs = new List<TerminalLog>();
        }

        private void FormatBytes() {
            InitaliseTerminalLogs();

            while (Pointer < (200 * 64)) {
                Logs.Add(ReplyByte.ToTerminalLog(Pointer));
                Pointer = Pointer.MoveToNextRecord();
            }
        }

        public List<TerminalLog> Collect(ITerminal Terminal) {
            ConnectToTerminal(Terminal);
            InitaliseBytes();
            InitaliseRequestPacket();

            if (TerminalSocket.Connected) {
                ProcessRequest();
                FormatBytes();        
            }

            return Logs;
        }
    }
}
