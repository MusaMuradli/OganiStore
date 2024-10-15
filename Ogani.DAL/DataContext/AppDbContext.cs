using Microsoft.EntityFrameworkCore;
using Ogani.DAL.DataContext.Entities;

namespace Ogani.DAL.DataContext;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(new Category { Name = "Food", Id = 1,ImageUrl="Salam" });
        base.OnModelCreating(modelBuilder);
    }
}
