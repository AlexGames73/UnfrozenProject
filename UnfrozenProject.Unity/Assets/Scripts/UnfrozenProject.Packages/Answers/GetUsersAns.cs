using System.Collections.Generic;
using Structs;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Answers
{
    [PackagePack((short)PackageType.GetUsersAns)]
    public class GetUsersAns
    {
        public List<User> Users { get; set; }
    }
}
