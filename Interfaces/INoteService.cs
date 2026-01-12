using SharpNotes.Models;

namespace SharpNotes.Interfaces;

public interface INoteService
{
    Task<List<Note>> GetAllAsync(CancellationToken ct);
    Task<Note?> GetByIdAsync(ulong id, CancellationToken ct);
    Task<Note> CreateAsync(string title, string content, CancellationToken ct);
}
