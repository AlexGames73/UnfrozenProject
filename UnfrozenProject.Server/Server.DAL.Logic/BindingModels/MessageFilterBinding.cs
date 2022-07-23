namespace Server.DAL.Logic.BindingModels;

public class MessageFilterBinding
{
    public string? Query { get; set; }
    public IList<Guid> FromUserIds { get; set; } = new List<Guid>();
    public IList<Guid> ToUserIds { get; set; } = new List<Guid>();
}
