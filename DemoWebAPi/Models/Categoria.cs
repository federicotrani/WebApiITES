using System.ComponentModel.DataAnnotations;

namespace DemoWebAPi.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    public string? Nombre { get; set; }
}
