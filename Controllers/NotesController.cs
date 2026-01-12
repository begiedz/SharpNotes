using Microsoft.AspNetCore.Mvc;
using SharpNotes.Contracts;
using SharpNotes.Interfaces;

namespace SharpNotes.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotes(CancellationToken ct)
    {
        var response = await _noteService.GetAllAsync(ct);
        return Ok(response);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id, CancellationToken ct)
    {
        var note = await _noteService.GetByIdAsync(id, ct);
        return note is null ? NotFound() : Ok(note);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNote([FromForm] CreateNoteRequest req, CancellationToken ct)
    {
        var note = await _noteService.CreateAsync(req, ct);

        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }
}
