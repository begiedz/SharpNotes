namespace SharpNotes.Domain.Entities;

public class Note
{
    public Guid ID { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Content { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
