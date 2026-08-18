using Microsoft.EntityFrameworkCore;
using DemoWebAPi.Models;

namespace DemoWebAPi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Producto> Productos { get; set; }
}
