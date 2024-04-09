using Microsoft.AspNetCore.Mvc;
using UdemyWebApp8.Model.Entity;
namespace MvcWebApp.Controllers
{
    public class SongController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
