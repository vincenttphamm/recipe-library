using Microsoft.EntityFrameworkCore;
using RecipeLibrary.Api.Entities;

namespace RecipeLibrary.Api;

public class RecipeLibraryContext(DbContextOptions<RecipeLibraryContext> options)
    : DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();

    public DbSet<Cuisine> Cuisines => Set<Cuisine>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cuisine>().HasData(
            new { Id = 1, Name = "Italian" },
            new { Id = 2, Name = "Thai" },
            new { Id = 3, Name = "Indian" },
            new { Id = 4, Name = "Mexican" }
        );
    }
}
