using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AiWebGymTracker.Controllers;

public class FoodController(ILogger<FoodController> logger) : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Home()
    {
        return RedirectToAction("Index", "Home");
    }
}