using System.ComponentModel.DataAnnotations;

namespace RubberDev.Models;

public class CartoonCharacter
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    [Required, MaxLength(100)]
    public string Origin { get; set; }

    [Required, MaxLength(500)]
    public string Abilities { get; set; }

    [Range(1, 5)]
    public int Rarity { get; set; }

    [Required, Url, MaxLength(200)]
    public string ImageUrl { get; set; }
}