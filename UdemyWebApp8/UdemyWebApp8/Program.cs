var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var value = new List<string>() { 
    "hello", "World", "My", "Friend"
};



//app.MapGet("/", (HttpContext context) =>
//{
//    Console.WriteLine(context.GetEndpoint()?.DisplayName);
//    return "hello world";

//});
app.Use(async (context, next) =>
{
    Console.WriteLine(context.GetEndpoint()?.DisplayName);
    Console.WriteLine("go here 1");
    await next.Invoke();
});

app.UseRouting();
app.Run(async (context) =>
{
     await context.Response.WriteAsync("go to end of pipeline");
});

app.Run();
