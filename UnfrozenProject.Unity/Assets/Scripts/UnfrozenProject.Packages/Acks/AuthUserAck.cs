using TriaStudios.NetworkLib.Core.Attributes;

namespace Acks
{
    [PackagePack((short)PackageType.AuthUserAck)]
    public class AuthUserAck
    {
        public string Username { get; set; }
        public int Color { get; set; }
        public int TimeZoneMinutesOffset { get; set; }
    }
}
