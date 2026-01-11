namespace SharpNotes.Models;

public class Note
{
    public uint Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Note(uint id, string title, string content, DateTime? createdAt = null) 
    {
        Id = id;
        Title = title;
        Content = content;
        CreatedAt = createdAt ?? DateTime.UtcNow;
    }
}
