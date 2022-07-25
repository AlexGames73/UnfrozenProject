using TriaStudios.NetworkLib.Core.Attributes;

namespace Structs
{
    [PackagePack]
    public class User
    {
        public string UserId { get; set; }
        public int Color { get; set; }
        public string Username { get; set; }
        public bool IsOnline { get; set; }
    }
}
