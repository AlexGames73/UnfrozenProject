namespace Server.DAL.Logic.BindingModels;

public class MessageBinding
{
    public Guid? Id { get; set; }
    public string Content { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
}
