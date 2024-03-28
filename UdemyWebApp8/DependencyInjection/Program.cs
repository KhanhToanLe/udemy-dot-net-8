using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyInjection.Controllers;
using DependencyInjection.Services.IService;
using DependencyInjection.Services.Service;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// AutoFac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<SongService>().As<ISongService>().InstancePerDependency();
});

// IoC Registraction
//builder.Services.Add(
//    new ServiceDescriptor(typeof(ISongService), typeof(SongService),ServiceLifetime.Scoped)
//);

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
