using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Functions {
    public static class DateTimeFormatters {
        
        public static Boolean IsDateTimeValid(this Byte[] Reply, Int32 Pointer) {
            if (Reply.ToStringDateTime(Pointer) == "\0\0/\0\0/\0\0 \0\0:\0\0:\0\0") {
                return false;
            }
            return true;
        }

        public static Boolean ReplyIsLongFormat(this Byte[] Reply, Int32 Pointer) {
            if (Reply.ToString(Pointer.LongSwipePointer(), 1, true) == "*") {
                return true;
            }

            return false;
        }

        private static Int32 DateTimePointer(this Int32 Pointer) {
            return Pointer + 6;
        }

        private static Int32 LongSwipePointer(this Int32 Pointer) {
            return Pointer + 18;
        }
    }
}
