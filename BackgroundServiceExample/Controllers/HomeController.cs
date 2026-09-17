// home page controller
// handles requests to the home page, loads data from the database, and passes it to the view for rendering

using BackgroundServiceExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BackgroundServiceExample.Data;

namespace BackgroundServiceExample.Controllers;

// The background service updates the same Persons table in the database. 
// Then this controller reads the updated records and shows them on the page.
public class HomeController : Controller
{
    private readonly PeopleContext _context; // Dependency injection


    public HomeController(PeopleContext context)
    {
        _context = context;
    }

    // the index page
    public IActionResult Index()
    {
        var persons = _context.Persons.ToList();

        return View(persons);
    }

    // privacy page
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() // error page
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
