namespace RubberDev.Domain.Entities;

public class PullBatch
{
    public Guid PullBatchId { get; set; }
    public DateTimeOffset PulledAt { get; set; }
    public List<PullItem> Items { get; set; } = new();
}