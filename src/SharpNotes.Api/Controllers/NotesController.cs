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
        return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Note note)
    {
        if (id != note.Id)
            return BadRequest();

        var existingNote = NoteService.Get(id);
        if (existingNote is null)
            return NotFound();

        NoteService.Update(note);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var note = NoteService.Get(id);

        if (note is null)
            return NotFound();

        NoteService.Delete(id);

        return NoContent();
    }
}
