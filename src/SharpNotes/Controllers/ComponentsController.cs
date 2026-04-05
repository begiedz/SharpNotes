using Microsoft.AspNetCore.Mvc;

namespace SharpNotes.Controllers;

public class ComponentsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

