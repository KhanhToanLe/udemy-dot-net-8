using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        public List<Person> people = new List<Person>()
            {
                new Person(){
                    Name = "Le Khanh Toan",
                    Age = 21,
                    DateOfBirth = DateOnly.Parse("2002-04-02")
                },
                new Person(){
                    Name = "Toan Khanh Le",
                    Age = 12,
                    DateOfBirth = DateOnly.Parse("2002-04-01")
                },
                new Person(){
                    Name = "Khanh Le Toan",
                    Age = 23,
                    DateOfBirth = DateOnly.Parse("2005-09-12")
                },
                new Person(){
                    Name = "Khanh Toan Le",
                    Age = 32,
                    DateOfBirth = DateOnly.Parse("2001-01-01")
                },
            };
        public IActionResult Index()
        {
            ViewData["id"] = "1234567890";
           
            ViewData["people"] = people;
            ViewData["data"] = "this is what you came for";
            return View("Index",people);
        }

        [Route("{age:int}")]
        public IActionResult GetPersonDetail([FromRoute] int age) {
            var matchedPerson = people.Where(x => x.Age == age).FirstOrDefault();
            if (matchedPerson == null)
            {
                return new ContentResult()
                {
                    Content = "Person not found"
                };
            }
            else
            {
                return View("Detail", matchedPerson);
            }
        }
    }
}
