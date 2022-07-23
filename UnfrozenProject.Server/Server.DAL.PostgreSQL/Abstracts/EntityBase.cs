namespace Server.Database.Abstracts;

public abstract class EntityBase
{
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public bool Deleted { get; set; }
}
