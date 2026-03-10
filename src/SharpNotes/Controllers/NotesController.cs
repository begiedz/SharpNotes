using Microsoft.AspNetCore.Mvc;
using SharpNotes.Services;

namespace SharpNotes.Controllers
{
    [Route("notes")]
    public class NotesController(INoteService noteService) : Controller
    {
        private readonly INoteService _noteService = noteService;

        public async Task<IActionResult> Index()
        {
            var notes = await _noteService.GetAllAsync();
            return View(notes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var note = await _noteService.GetByIdAsync(id);

            if (note == null)
                return NotFound();

            return View(note);
        }
    }
}
