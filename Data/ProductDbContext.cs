namespace CrudAPINet8.Data;

using Microsoft.EntityFrameworkCore;
using CrudAPINet8.Models;

public class ProductDbContext(DbContextOptions<ProductDbContext> options) : DbContext(options)
{
    public DbSet<Product> Product { get; set; } = default!;
}
