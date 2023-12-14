using Microsoft.AspNetCore.Mvc;

namespace DashboardApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Blazor()
        {
            return View("_Host");
        }
    }
}
