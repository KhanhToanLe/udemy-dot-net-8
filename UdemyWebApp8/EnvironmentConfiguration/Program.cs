var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("running in development");
}
else if (app.Environment.IsStaging())
{
    Console.WriteLine("running in Staging");
}
else if (app.Environment.IsProduction())
{
    Console.WriteLine("running in Producting");
}

app.MapGet("/", () => "Hello World!");
    
app.UseRouting();
app.MapControllers();
app.Run();
