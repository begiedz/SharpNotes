using Microsoft.EntityFrameworkCore;
using SmallJoys.Domain.Entities;

namespace SmallJoys.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Joy> Joys => Set<Joy>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Joy>(entity =>
        {
            entity.ToTable("joys");
            entity.HasKey(joy => joy.Id);
            entity.Property(joy => joy.Title).HasMaxLength(200).IsRequired();
            entity.Property(joy => joy.Content).IsRequired();
            entity.Property(joy => joy.CreatedAt).HasDefaultValueSql("now() at time zone 'utc'");
        });
    }
}
