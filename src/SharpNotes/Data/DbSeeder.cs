using SharpNotes.Models;

namespace SharpNotes.Data;

public class DbSeeder
{
    public static void Seed(AppDbContext dbContext)
    {
        if (dbContext.Notes.Any())
            return;

        dbContext.Notes.AddRange(
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
        dbContext.SaveChanges();
    }
}
