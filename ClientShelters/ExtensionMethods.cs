using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters
{
    public static class ExtensionMethods
    {
        public static Timestamp FromDateOnlyToStamp(this DateOnly date)
        {
            return DateTime.SpecifyKind(date.ToDateTime(new TimeOnly()), DateTimeKind.Utc).ToTimestamp();
        }
    }
}
