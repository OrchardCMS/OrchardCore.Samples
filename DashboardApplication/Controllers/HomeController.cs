using Microsoft.AspNetCore.Mvc;

namespace DashboardApplication.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
