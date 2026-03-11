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
        note.Updated = DateTime.UtcNow;

        await _context.Notes.AddAsync(note);
        await _context.SaveChangesAsync();

        return note;
    }
}
