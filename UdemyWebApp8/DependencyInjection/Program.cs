using DependencyInjection.Services.IService;
using DependencyInjection.Services.Service;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.Add(
    new ServiceDescriptor(typeof(ISongService), typeof(SongService),ServiceLifetime.Scoped)
);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


app.Run();
