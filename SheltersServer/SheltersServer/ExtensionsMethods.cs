using Google.Protobuf.WellKnownTypes;

namespace SheltersServer
{
    public static class ExtensionsMethods
    {
        public static Timestamp FromDateOnlyToStamp(this DateOnly date)
        {
            return DateTime.SpecifyKind(date.ToDateTime(new TimeOnly()), DateTimeKind.Utc).ToTimestamp();
        }
    }
}
