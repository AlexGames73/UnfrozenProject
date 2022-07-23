using TriaStudios.NetworkLib.Core.Attributes;

namespace Answers
{
    [PackagePack((short)PackageType.AuthUserAns)]
    public class AuthUserAns
    {
        public string UserId { get; set; }
        public string Error { get; set; }
    }
}
