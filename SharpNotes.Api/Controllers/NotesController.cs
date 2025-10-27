using SharpNotes.Domain.Entities;
using SharpNotes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SharpNotes.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    public NotesController()
    {
    }

    [HttpGet]
    public ActionResult<List<Note>> GetAll() =>
    NoteService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Note> Get(int id)
    {
        var note = NoteService.Get(id);

        if (note == null)
            return NotFound();

        return note;
    }

    [HttpPost]
    public IActionResult Create(Note note) 
    {
        NoteService.Add(note);
        return CreatedAtAction(nameof(Get), new {id = note.Id}, note);
    }
}
