using Microsoft.EntityFrameworkCore;
using SharpNotes.Data;
using SharpNotes.Models;

namespace SharpNotes.Services;

public class NoteService(AppDbContext context) : INoteService
{
    private readonly AppDbContext _context = context;

    public async Task<List<Note>> GetAllAsync()
    {
        var notes = await _context.Notes.AsNoTracking().ToListAsync();
        return notes;
    }
    public async Task<Note?> GetByIdAsync(int id)
    {
        var note = await _context.Notes.FindAsync(id);
        return note;
    }
}
