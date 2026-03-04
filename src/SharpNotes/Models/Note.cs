using System.ComponentModel.DataAnnotations;

namespace SharpNotes.Models;

public class Note
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = default!;
    [Required]
    public string Content { get; set; } = default!;

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
