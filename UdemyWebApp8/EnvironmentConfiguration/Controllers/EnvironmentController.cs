using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Security.Claims;

namespace EnvironmentConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EnvironmentController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        
        

        [HttpGet]
        public IActionResult GetEnvironment()
        {
            var envName = _webHostEnvironment.EnvironmentName;
            return new ContentResult()
            {
                Content = envName
            };
        }

        
    }
}
