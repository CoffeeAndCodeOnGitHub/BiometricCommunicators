using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Interfaces {
    public interface ILog {
        DateTime SwipeTime { get; set; }
        string PersonNumber { get; set; }
    }
}
