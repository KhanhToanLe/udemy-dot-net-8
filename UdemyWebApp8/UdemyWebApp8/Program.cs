using System.Net.Security;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var value = new List<string>() { 
    "hello", "World", "My", "Friend"
};

app.MapGet("/", () =>
{
    return "hello world";
});
app.MapGet("/item", async (HttpContext context) =>
{
    const string value = "task";
    await context.Response.WriteAsync(value);
});

app.Run();
