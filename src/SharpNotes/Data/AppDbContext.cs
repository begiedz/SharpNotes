using Microsoft.EntityFrameworkCore;
using SharpNotes.Models;

namespace SharpNotes.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "sharp-notes");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>().HasData(
            new Note
            {
                Id = 1,
                Title = "Welcome",
                Content = "First note",
                Created = DateTime.Today.AddDays(-1),
                Updated = DateTime.UtcNow
            },

            new Note
            {
                Id = 2,
                Title = "Second note",
                Content = "Another note",
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow

            }
        );
    }
}
