using Microsoft.EntityFrameworkCore;
using SharpNotes.Models;

namespace SharpNotes.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("notes");
            entity.HasKey(note => note.Id);

            entity.Property(note => note.Id).ValueGeneratedOnAdd();
            entity.Property(note => note.Title).IsRequired().HasMaxLength(200);
            entity.Property(note => note.Content).IsRequired();
            entity.Property(note => note.CreatedAt).HasDefaultValueSql("now()");
        }
        );
    }
}
