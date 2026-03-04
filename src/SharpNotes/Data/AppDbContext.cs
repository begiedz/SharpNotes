using Microsoft.EntityFrameworkCore;
using SharpNotes.Models;

namespace SharpNotes.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes => Set<Note>();
}
