using SharpNotes.Models;

namespace SharpNotes.Services;

public interface INoteService
{
    public Task<List<Note>> GetNotesAsync();
}
