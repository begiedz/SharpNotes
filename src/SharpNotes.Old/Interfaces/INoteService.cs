using SharpNotes.Contracts;
using SharpNotes.Models;

namespace SharpNotes.Interfaces;

public interface INoteService
{
    Task<List<Note>> GetAllAsync(CancellationToken ct);
    Task<Note?> GetByIdAsync(long id, CancellationToken ct);
    Task<Note> CreateAsync(CreateNoteRequest req, CancellationToken ct);
}
