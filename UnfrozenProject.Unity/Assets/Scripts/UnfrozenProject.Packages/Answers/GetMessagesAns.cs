using System.Collections.Generic;
using Structs;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Answers
{
    [PackagePack((short)PackageType.GetMessagesAns)]
    public class GetMessagesAns
    {
        public List<Message> Messages { get; set; }
    }
}
