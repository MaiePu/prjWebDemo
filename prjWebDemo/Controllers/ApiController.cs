using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace prjWebDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name)
        {
            //System.Threading.Thread.Sleep(5000);

            if (string.IsNullOrEmpty(name))
            {
                name = "vick";
            }

            return Content($"Hello , {name}","text/plain",Encoding.UTF8);
        }
    }
}
