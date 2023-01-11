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

       

        public IActionResult CheckAccount(string name)
        {
            //
            var exists = _contxt.Members.Any(m => m.Name == name);

            return Content(exists.ToString(), "text/palin");
        }

        public IActionResult Register(Member member, IFormFile photo)
        {

            string fileName = photo.FileName;
            string filePath = Path.Combine(_host.WebRootPath, "uploads", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }


            member.FileName = fileName;

            byte[]? imgByte = null;
            using (var memoryStream = new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileData = imgByte;


            _contxt.Members.Add(member);
            _contxt.SaveChanges();



            return Content($"{filePath}");



        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}