namespace RubberDev.Domain.Entities;

public class Pull
{
    public Guid PullId { get; set; }
    public Guid CharacterId { get; set; }
    public DateTimeOffset PulledAt { get; set; }

    public Pull(Guid characterId)
    {
        PullId = Guid.NewGuid();
        CharacterId = characterId;
        PulledAt = DateTimeOffset.UtcNow;
    }

    public Pull()
    {
    }
}