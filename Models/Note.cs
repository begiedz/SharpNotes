namespace SharpNotes.Models;

public class Note
{
    public ulong Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Note( string title, string content)
    {
        Title = title;
        Content = content; 
    }
}
