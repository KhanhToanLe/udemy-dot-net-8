using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace UdemyWebApp8.CustomBinder
{
    public class ListOfIntegerCustomBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var query = bindingContext.HttpContext.Request.Query;
            var IdsQuery = query["ids"].ToString();
            if(string.IsNullOrEmpty(IdsQuery))
                return Task.CompletedTask;
            var splitIntValue = IdsQuery.Split(",").Select(int.Parse).ToList();
            bindingContext.Result = ModelBindingResult.Success(splitIntValue);
            return Task.CompletedTask;
        }
    }

    public class ListOfIntegerCustomBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(List<int>))
            {
                return new ListOfIntegerCustomBinder();
            }
            return null;

        }
    }
}
