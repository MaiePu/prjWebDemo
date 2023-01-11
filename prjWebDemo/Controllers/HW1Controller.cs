using Microsoft.AspNetCore.Mvc;

namespace prjWebDemo.Controllers
{
    public class HW1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
