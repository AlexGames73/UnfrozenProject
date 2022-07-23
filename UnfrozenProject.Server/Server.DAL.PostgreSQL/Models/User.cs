using Server.Database.Abstracts;

namespace Server.Database.Models;

public class User : EntityBase
{
    public string Username { get; set; }
    public int Color { get; set; }
}
