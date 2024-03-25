using Microsoft.AspNetCore.Mvc;

namespace UdemyWebApp8.MvcController
{
    [Route("company")]
    public class CompanyController : Controller
    {
        [Route("building")]
        public IActionResult Index()
        {
            Console.WriteLine("go here");
            return View("Views/Home/Home.cshtml");
        }

        [Route("binding")]
        public IActionResult BindProperty()
        {
            return new ContentResult();
        }
    }
}
