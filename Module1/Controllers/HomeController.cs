using Microsoft.AspNetCore.Mvc;

namespace Module1.Controllers;

// Custom route [Route("myhome")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
