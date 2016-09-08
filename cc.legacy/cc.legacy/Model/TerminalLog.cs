using cc.legacy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Model {
    public class TerminalLog : ILog {
        public String PersonNumber { get; set; }
        public DateTime SwipeTime { get; set; }
    }
}
