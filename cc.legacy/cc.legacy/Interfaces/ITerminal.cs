using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Interfaces {
    public interface ITerminal {
        String TerminalName { get; set; }
        IPAddress TerminalAddress { get; set; }
        Int16 TerminalPort { get; set; }
        int TerminalDatabaseSize { get; set; }
    }
}
