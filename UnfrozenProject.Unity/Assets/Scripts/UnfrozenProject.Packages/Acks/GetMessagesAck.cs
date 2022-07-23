using TriaStudios.NetworkLib.Core.Attributes;

namespace Acks
{
    [PackagePack((short)PackageType.GetMessagesAck)]
    public class GetMessagesAck
    {
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
