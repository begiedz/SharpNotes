using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharpNotes.Models;
using SharpNotes.Services;

namespace SharpNotes.Controllers
{
    public class NotesController(INoteService noteService) : Controller
    {
        private readonly INoteService _noteService = noteService;

        [HttpGet]
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

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Note());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Note note)
        {
            if (!ModelState.IsValid)
                return View(note);

            await _noteService.CreateAsync(note);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var note = await _noteService.GetByIdAsync(id);

            if (note is null)
                return NotFound();

            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Note note)
        {
            var updated = await _noteService.UpdateAsync(id, note);

            if (updated is null)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
