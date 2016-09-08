using cc.legacy.Commands;
using cc.legacy.Interfaces;
using cc.legacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy {
    public class Terminal {
        public List<TerminalLog> TerminalLogs;

        public void GetTerminalLog(ITerminal Terminal) {
            TerminalLogs.AddRange(new TerminalLogs().Collect(Terminal));
        }
    }
}
