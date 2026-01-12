using SharpNotes.Models;
using SharpNotes.Data;
using SharpNotes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SharpNotes.Services;

public class NoteService: INoteService
{
    private readonly AppDbContext _db;
    public NoteService(AppDbContext db) => _db = db;

    public Task<List<Note>> GetAllAsync(CancellationToken ct) =>
        _db.Notes
            .OrderByDescending(note => note.CreatedAt)
            .ToListAsync(ct);

    public Task<Note?> GetByIdAsync(ulong id, CancellationToken ct) =>
        _db.Notes.FirstOrDefaultAsync(note => note.Id == id, ct);

    public async Task<Note> CreateAsync(string title, string content, CancellationToken ct)
    {
        var note = new Note(title, content);

        _db.Notes.Add(note);
        await _db.SaveChangesAsync(ct);
        return note;
    }
}
