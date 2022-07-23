using TriaStudios.NetworkLib.Core.Abstract;

namespace Server.BFF;

public class GameSession : NetworkSession
{
    public Guid? UserId { get; set; }
    public int TimeZoneMinutesOffset { get; set; }
}
