using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharpNotes.Models;
using SharpNotes.Services;

namespace SharpNotes.Controllers
{
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
