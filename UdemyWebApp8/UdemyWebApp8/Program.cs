var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var value = new List<string>() { 
    "hello", "World", "My", "Friend"
};

app.MapGet("/", () =>
{
    return "hello world";
});
app.MapGet("/item", () =>
{
    return value;
});

app.Run();
