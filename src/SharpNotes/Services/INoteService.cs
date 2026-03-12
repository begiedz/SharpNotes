using SharpNotes.Models;

namespace SharpNotes.Services;

public interface INoteService
{
    public Task<List<Note>> GetAllAsync();
    public Task<Note?> GetByIdAsync(int id);
    public Task<Note> CreateAsync(Note note);
    public Task<Note?> UpdateAsync(int id, Note updatedNote);
    public Task<bool> DeleteAsync(int id);

}
