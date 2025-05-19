namespace RubberDev.Domain.ValueObjects;

public static class PullOdds
{
    // expressed as decimals (sum must equal 1.0)
    // Common (rarity 1–2): 70%
    public const double Common = 0.70;

    // Rare (rarity 3): 20%
    public const double Rare = 0.20;

    // Epic (rarity 4): 8%
    public const double Epic = 0.08;

    // Legendary (rarity 5): 2%
    public const double Legendary = 0.02;
}