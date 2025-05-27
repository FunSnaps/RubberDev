namespace RubberDev.Domain.Entities;

public class PullItem : PullItemBase
{
    public new Guid PullItemId { get; set; }
    public new Guid PullBatchId { get; set; }
    public new Guid CharacterId { get; set; }
}