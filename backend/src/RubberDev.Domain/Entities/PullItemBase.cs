namespace RubberDev.Domain.Entities;

public abstract class PullItemBase
{
    public Guid PullItemId { get; set; }
    public Guid PullBatchId { get; set; }
    public Guid CharacterId { get; set; }
}