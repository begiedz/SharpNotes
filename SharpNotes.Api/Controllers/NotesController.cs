using SharpNotes.Domain.Entities;
using SharpNotes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SharpNotes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    public NotesController()
    {
    }

    [HttpGet]
    public ActionResult<List<Note>> GetAll() =>
    NoteService.GetAll();
}
