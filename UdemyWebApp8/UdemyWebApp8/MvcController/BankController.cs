using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using System.IO;

namespace UdemyWebApp8.MvcController
{
    [Route("bank")]
    public class BankController : Controller
    {
        private object _bankAccount = new
        {
            accountNumber = 1001,
            accountHolderName = "Le Khanh Toan",
            currentBanlance = 500
        };

        public IActionResult Index()
        {
            return new ContentResult()
            {
                Content = "Welcome to the Best Bank",
                StatusCode = StatusCodes.Status200OK
            };
        }

        [Route("account-detail")]
        public IActionResult GetAccountDetail()
        {
            return new JsonResult(_bankAccount)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }

        [Route("account-statement")]
        public IActionResult GetAccountStatement()
        {
            var filePath = "MyStaticFiles/dummy.pdf";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return new FileContentResult(fileBytes, "application/pdf");
        }

        //[HttpGet("get-model-binding/{nameValue:maxlength(20)}")]
        [Route("get-model-binding/{nameValue}")]
        public IActionResult GetModelBinding1([FromRoute]string nameValue, [FromQuery]int? ageValue)
        {
            if (!ageValue.HasValue)
            {
                return BadRequest();
            }
            return new ContentResult()
            {
                Content = nameValue + ageValue.ToString(),
                ContentType = "text/plain",
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}
