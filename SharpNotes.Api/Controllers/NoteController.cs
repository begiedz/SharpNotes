using SharpNotes.Domain.Entities;
using SharpNotes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SharpNotes.Api.Controllers;

[ApiController]
[Route("[controller]/all")]
public class NoteController : ControllerBase
{
    public NoteController()
    {
    }

    [HttpGet]
    public ActionResult<List<Note>> GetAll() =>
    NoteService.GetAll();
}
