using cc.legacy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cc.legacy.Functions {
    public static class ByteConvertors {
        
        public static String ToString(this Byte[] Byte, Int32 Pointer, Int32 Length, Boolean Encoded) {
            int _xCount = 0;
            byte[] _Reply = new byte[Length];

            while (_xCount < Length) {
                _Reply[_xCount] = Byte[Pointer + _xCount];
                _xCount = _xCount + 1;
            }

            if (Encoded == true) {
                System.Text.Encoding encoding = System.Text.Encoding.ASCII;
                return encoding.GetString(_Reply);
            } else {
                return BitConverter.ToString(_Reply);
            }
        }

        public static String ToStringDateTime(this Byte[] Reply, Int32 Pointer) {
            var unformattedDateTime = Reply.ToString().ToCharArray();

            return String.Format("{0}{1}-{2}{3}-{4}{5} {6}{7}:{8}{9}:{10}{11}",
                unformattedDateTime[0],
                unformattedDateTime[1],
                unformattedDateTime[2],
                unformattedDateTime[3],
                unformattedDateTime[4],
                unformattedDateTime[5],
                unformattedDateTime[6],
                unformattedDateTime[7],
                unformattedDateTime[8],
                unformattedDateTime[9],
                unformattedDateTime[10],
                unformattedDateTime[11]);
        }

        public static DateTime ToDateTime(this Byte[] Reply, Int32 Pointer) { 
            DateTime parsedDateTime;

            if (DateTime.TryParse(Reply.ToStringDateTime(Pointer + 6), out parsedDateTime)) {
                return DateTime.Parse(Reply.ToStringDateTime(Pointer + 6));
            }

            return DateTime.Parse("1900-01-01 00:00:00");
        }

        public static String ToEmployeeNumber(this Byte[] Reply, Int32 Pointer) {
            if (Reply.IsDateTimeValid(Pointer)) {
                return Reply.ToString(24 + Pointer, 12, true).Replace("\0", "");
            }

            return Reply.ToString(35 + Pointer, 12, true).Replace("\0", "");
        }

        public static TerminalLog ToTerminalLog(this Byte[] Reply, Int32 Pointer) {
            TerminalLog terminalLog = new TerminalLog();
            terminalLog.PersonNumber = Reply.ToEmployeeNumber(Pointer);
            terminalLog.SwipeTime = Reply.ToDateTime(Pointer);

            return terminalLog;
        }
    }
}
