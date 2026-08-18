using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebAPi.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string? Nombre { get; set; }
    [Precision(18,2)]
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool Activo { get; set; }
    [ForeignKey("Categoria")]
    public int? CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
}
