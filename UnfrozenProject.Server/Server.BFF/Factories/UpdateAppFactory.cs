using Answers;
using TriaStudios.NetworkLib.Core.Attributes;

namespace Server.BFF.Factories;

[Dependency]
public class UpdateAppFactory
{
    public void Send(params GameSession[] sessions)
    {
        foreach (var connectedSession in sessions)
        {
            connectedSession.Send(new UpdateAppAns());
        }
    }
}
