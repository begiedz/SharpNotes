using Microsoft.EntityFrameworkCore;
using SharpNotes.Data;
using SharpNotes.Models;

namespace SharpNotes.Services;

public class NoteService(AppDbContext context) : INoteService
{
    private readonly AppDbContext _context = context;

    public async Task<List<Note>> GetNotesAsync()
    {
        var notes = await _context.Notes.AsNoTracking().ToListAsync();
        return notes;
    }
}
