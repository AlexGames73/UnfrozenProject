using TriaStudios.NetworkLib.Core.Abstract;

namespace Network
{
    public class GameSession : NetworkSession
    {
        public string UserId { get; set; }
        public string LogInError { get; set; }
    }
}
