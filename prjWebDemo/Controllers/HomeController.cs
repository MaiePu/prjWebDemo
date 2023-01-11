using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjWebDemo.Models;
using System.Diagnostics;

namespace prjWebDemo.Controllers
{
    public class HomeController : Controller
    {

        private readonly DemoContext _contxt;
        private readonly IWebHostEnvironment _host;


        public HomeController( DemoContext contxt, IWebHostEnvironment host)
        {

            _contxt = contxt;
            _host = host;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult City()
        {
            var cities = _contxt.Addresses.Select(c => c.City).Distinct();
            return Json(cities);
        }

        public IActionResult Site(string city)
        {
            var sites = _contxt.Addresses.Where(s => s.City == city).Select(s => s.SiteId).Distinct();


            return Json(sites);

        }
        public IActionResult Road(string site)
        {
            var roads = _contxt.Addresses.Where(s => s.SiteId == site).Select(s => s.Road).Distinct();


            return Json(roads);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}