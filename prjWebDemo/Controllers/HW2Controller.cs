using Microsoft.AspNetCore.Mvc;
using prjWebDemo.Models;
using System.Text;

namespace prjWebDemo.Controllers
{
    public class HW2Controller : Controller
    {
        private readonly DemoContext _context;

        public HW2Controller(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult check(string name)
        {
            var p = from emp in _context.Members
                    select emp.Name;

            foreach (var q in p)
            {
                if (name == q)
                {
                    return Content("名稱重複", "text/plain", Encoding.UTF8);
                }
            }
            return Content("無重複名稱", "text/plain", Encoding.UTF8);
        }
    }
}
