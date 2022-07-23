using TriaStudios.NetworkLib.Core.Attributes;

namespace Structs
{
    [PackagePack]
    public class Message
    {
        public int FromColor { get; set; }
        public string FromUsername { get; set; }
        public string Content { get; set; }
        public string DateTime { get; set; }
        public bool IsOnline { get; set; }
    }
}
