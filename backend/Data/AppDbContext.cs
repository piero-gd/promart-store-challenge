using Microsoft.EntityFrameworkCore;
using PromartStore.API.Models;

namespace PromartStore.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductRating> ProductRatings => Set<ProductRating>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Rating)
            .WithOne()
            .HasForeignKey<ProductRating>(r => r.ProductId);
    }
}
