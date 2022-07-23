using System.Drawing;

namespace Server.DAL.Logic.BindingModels;

public class UserFilterBinding
{
    public IList<Guid> UserIds { get; set; } = new List<Guid>();
    public IList<string> Usernames { get; set; } = new List<string>();
    public IList<Color> Colors { get; set; } = new List<Color>();
    public bool IncludeDeleted { get; set; }
}
