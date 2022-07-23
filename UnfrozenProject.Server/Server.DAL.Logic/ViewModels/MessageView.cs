namespace Server.DAL.Logic.ViewModels;

public class MessageView
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public UserView FromUser { get; set; }
    public UserView ToUser { get; set; }
    public DateTime DateTime { get; set; }
}
