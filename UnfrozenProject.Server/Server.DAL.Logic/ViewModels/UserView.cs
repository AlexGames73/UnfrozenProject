using System.Drawing;

namespace Server.DAL.Logic.ViewModels;

public class UserView
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Color Color { get; set; }
}
