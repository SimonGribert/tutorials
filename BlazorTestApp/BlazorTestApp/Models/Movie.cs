using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorTestApp.Models;

public class Movie
{
    public int ID { get; set; }
    
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }
    public DateOnly ReleasedDate { get; set; }
    
    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z()\s-]*$")]
    public string? Genre { get; set; }

    [Range(0, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(5)]
    [RegularExpression("^(G|PG|PG-13|R|NC-17)$")]
    public string? Rating { get; set; }
}