using Microsoft.EntityFrameworkCore;
using SharpNotes.Data;
using SharpNotes.Models;

namespace SharpNotes.Services;

public class NoteService(AppDbContext context) : INoteService
{
    private readonly AppDbContext _context = context;

    public async Task<List<Note>> GetAllAsync()
    {
        var notes = await _context.Notes.AsNoTracking().OrderDescending().ToListAsync();
        return notes;
    }

    public async Task<Note?> GetByIdAsync(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        return note;
    }

    public async Task<Note> CreateAsync(Note note)
    {
        note.Created = DateTime.UtcNow;

        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();

        return note;
    }

    public async Task<Note?> UpdateAsync(int id, Note updatedNote)
    {
        var existingNote = await GetByIdAsync(id);

        if (existingNote is null)
            return null;

        existingNote.Title = updatedNote.Title;
        existingNote.Content = updatedNote.Content;
        existingNote.Updated = DateTime.UtcNow;

        // no need for _context.Notes.Update(existingNote) due to entity is tracked by EF Core
        await _context.SaveChangesAsync();
        return existingNote;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var note = await GetByIdAsync(id);

        if (note is null)
            return false;

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();

        return true;
    }
}
