namespace RubberDev.Models;

public class CartoonCharacter
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Origin { get; set; }
    public string Abilities { get; set; }
    public int Rarity { get; set; }
    public string ImageUrl { get; set; }
}