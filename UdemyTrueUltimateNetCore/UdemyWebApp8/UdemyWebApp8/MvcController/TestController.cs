using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UdemyWebApp8.MvcController
{
    public class TestController : Controller
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            List<string> errorList = new List<string>();
            var ModelState = context.ModelState;
            Console.WriteLine(ModelState);
            foreach (var model in ModelState.Values)
            {
                foreach (var error in model.Errors)
                {
                    errorList.Add(error.ErrorMessage);
                }
            }
            Console.WriteLine(errorList);
            if (errorList.Count != 0)
            {
                context.Result = BadRequest(errorList);
            }
            else
            {
                await next.Invoke();
            }
            return;
        }
    }
}
