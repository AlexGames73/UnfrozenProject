using Server.Database.Abstracts;

namespace Server.Database.Models;

public class Message : EntityBase
{
    public string Content { get; set; }
    public Guid FromId { get; set; }
    public Guid ToId { get; set; }

    public virtual User From { get; set; }
    public virtual User To { get; set; }
}
