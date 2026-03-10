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
                Title = "Welcome to SharpNotes",
                Content = "This is your very first note in the SharpNotes application. You can use notes to save ideas, tasks, reminders, meeting summaries, or anything else you want to keep in one place. Start building your own knowledge base step by step.",
                Created = DateTime.Today.AddDays(-5),
                Updated = DateTime.Today.AddDays(-5)
            },
            new Note
            {
                Id = 2,
                Title = "Sunday Pancake Morning",
                Content = "A calm Sunday morning is perfect for homemade pancakes. I need flour, eggs, milk, a little sugar, and a bit of butter. I can serve them with fresh fruit, honey, or maple syrup. The most important thing is to keep the batter smooth and let the pancakes cook slowly.",
                Created = DateTime.Today.AddDays(-4),
                Updated = DateTime.Today.AddDays(-3)
            },
            new Note
            {
                Id = 3,
                Title = "Chicken and Rice Prep",
                Content = "Chicken and rice is one of the easiest meals to prepare for a busy week. I can season the chicken with paprika, garlic powder, black pepper, and a small amount of salt. Cooked rice with roasted vegetables on the side makes the meal simple, balanced, and easy to store in containers.",
                Created = DateTime.Today.AddDays(-3),
                Updated = DateTime.Today.AddDays(-2)
            },
            new Note
            {
                Id = 4,
                Title = "Vegetable Soup Idea",
                Content = "A warm vegetable soup is a good option when I want something light but filling. I can use carrots, potatoes, celery, onion, and a little parsley for extra freshness. If I let it simmer long enough, the flavors will become deeper and more comforting. It is also great for the next day.",
                Created = DateTime.Today.AddDays(-2),
                Updated = DateTime.Today.AddDays(-1)
            },
            new Note
            {
                Id = 5,
                Title = "Baking Chocolate Muffins",
                Content = "Chocolate muffins are a good choice when I want to bake something quick and enjoyable. I need cocoa powder, flour, eggs, milk, sugar, and a bit of oil or butter. Adding small chocolate pieces inside the batter makes them even better. I should not bake them too long, so they stay soft.",
                Created = DateTime.Today.AddDays(-1),
                Updated = DateTime.UtcNow
            }
        );
        dbContext.SaveChanges();
    }
}
