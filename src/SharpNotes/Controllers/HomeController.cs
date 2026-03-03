using Microsoft.AspNetCore.Mvc;
using SharpNotes.Models;
using SharpNotes.Services;
using System.Diagnostics;

namespace SharpNotes.Controllers;

public class HomeController(INoteService noteService) : Controller
{
    private readonly INoteService _noteService = noteService;

    public async Task<IActionResult> Index()
    {
        var notes = await _noteService.GetNotesAsync();
        return View(notes);
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
