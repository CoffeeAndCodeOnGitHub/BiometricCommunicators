using cc.legacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Functions {
    public static class LogRecordSelectors {
        public static Int32 MoveToNextRecord(this Int32 Pointer){
            return Pointer + 64;
        } 
    }
}
