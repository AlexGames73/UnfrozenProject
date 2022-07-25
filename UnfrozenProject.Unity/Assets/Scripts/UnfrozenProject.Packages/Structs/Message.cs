using TriaStudios.NetworkLib.Core.Attributes;

namespace Structs
{
    [PackagePack]
    public class Message
    {
        public User FromUser { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
    }
}
