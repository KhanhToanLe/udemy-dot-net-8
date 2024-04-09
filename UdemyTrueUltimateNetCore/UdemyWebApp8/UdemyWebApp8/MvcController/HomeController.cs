using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using UdemyWebApp8.Model.Entity;
using Newtonsoft.Json;
using System.IO;

namespace UdemyWebApp8.MvcController
{
    [Route("home")]
    [Controller]
    public class HomeController : Controller
    {
        [Route("json")]
        public JsonResult Home()
        {
            Song newSong = new Song()
            {
                SongName = "In the Mornin'"
            };
            //return new JsonResult(newSong)
            //{
            //    StatusCode = 200,
            //    ContentType = "application/json"
            //};
            return Json(newSong);
        }
        [Route("content")]
        public ContentResult GetSongContent()
        {
            return new ContentResult()
            {
                Content = $"<h1>Hello World</h1> ",
                ContentType = "text/html",
                StatusCode = 200
            };
        }
        [Route("file")]
        public IActionResult GetSongFile()
        {
            //byte[] file = System.IO.File.ReadAllBytes("MyStaticFiles/ff.png");
            //Console.WriteLine(file);
            //return File(file, "image/png");

            //return File("myStaticFiles/ff.png","image/png");

            //return new ContentResult();

            //return new ConflictResult();
            return new RedirectResult("http://youtube.com");
        }

        [Route("company")]
        public IActionResult GoToCompany()
        {
            Console.WriteLine("Get Starting to go to the company");
            return new RedirectToActionResult("Index", "Company",new { Packages = 100},false);
        }
    }
}
