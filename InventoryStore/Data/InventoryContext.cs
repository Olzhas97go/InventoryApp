using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data;
public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}