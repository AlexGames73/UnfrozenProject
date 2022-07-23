using TriaStudios.NetworkLib.Core.Attributes;

namespace Acks
{
    [PackagePack((short)PackageType.SendMessageAck)]
    public class SendMessageAck
    {
        public string Content { get; set; }
    }
}
