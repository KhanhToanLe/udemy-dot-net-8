using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using UdemyWebApp8.CustomBinder;
using UdemyWebApp8.CustomRouteConstraints;

WebApplicationOptions webApplicationOptions = new WebApplicationOptions
{
    WebRootPath = "MyWebRoot", //Setting the WebRootPath as MyWebRoot
    Args = args, //Setting the Command Line Arguments in Args
    EnvironmentName = "Development", //Changing to Production
};

var builder = WebApplication.CreateBuilder(webApplicationOptions);
builder.Services.AddRouting(option =>
{
    option.ConstraintMap.Add("nameRouteConstraint", typeof(NameRouteConstraint));
});

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews(options =>
{
    options.ModelBinderProviders.Insert(0, new ListOfIntegerCustomBinderProvider());
});

var app = builder.Build();

//app.UseExceptionHandler(c => c.Run(async context =>
//{
//    var exception = context.Features
//        .Get<IExceptionHandlerPathFeature>()
//        .Error;
//    var response = new { error = exception.Message };
//    await context.Response.WriteAsJsonAsync(response);
//}));

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles",
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", $"public,max-age={(60 * 60 * 24 * 7).ToString()}");
    }
});

app.MapControllers();


//var value = new List<string>() { 
//    "hello", "World", "My", "Friend"
//};
//app.MapGet("/item/{id=0}/{extra-message}/{optional-value?}", async (HttpContext context) =>
//{
//    int idValue;
//    var extraMessage = context.Request.RouteValues["extra-message"];
//    var optionalValue = context.Request.RouteValues["optional-value"];
//    bool isSuccess = int.TryParse((string?)context.Request.RouteValues["id"], out idValue);
//    if (isSuccess)
//    {
//        await context.Response.WriteAsync(value[idValue]);
//        await context.Response.WriteAsync(extraMessage.ToString());
//        await context.Response.WriteAsync(optionalValue == null ? "" : optionalValue.ToString()!);
//    }
//    else
//        await context.Response.WriteAsync("get item false, check input value again");
//});

//app.MapGet("/views/{id:long}", async (context) =>
//{
//var isContainKeyId = context.Request.RouteValues.ContainsKey("id");
//if (isContainKeyId)
//{
//    Console.WriteLine(context.Request.RouteValues["id"]);
//    return;
//}
//Console.WriteLine("there is no specific key id to show");

//DateTime idDateTime = DateTime.Parse(context.Request.RouteValues["id"].ToString());
//context.Response.WriteAsync(idDateTime.ToString());
//var idValue = context.Request.RouteValues["id"];

//var isSuccess = float.TryParse(idValue?.ToString(), out float idFloatValue);
//if (isSuccess)
//    await context.Response.WriteAsync(idFloatValue.ToString());
//else
//    await context.Response.WriteAsync(idFloatValue.ToString());

//    long idLong = long.Parse(context.Request.RouteValues["id"].ToString());
//    await context.Response.WriteAsync(idLong.ToString());
//});

//app.MapGet("/cities/{name:minlength(20)}", async (context) =>
//{
//    var routeName = context.Request.RouteValues["name"];
//    await context.Response.WriteAsync("minlength" + routeName.ToString());
//});

//app.MapGet("/cities/{name:maxlength(19)}", async (context) =>
//{
//    var routeName = context.Request.RouteValues["name"];
//    await context.Response.WriteAsync("maxlength" + routeName.ToString());
//});

//app.MapGet("/market/{city:length(12,20)}", async (context) =>
//{
//    context.Response.WriteAsync(context.Request.RouteValues["city"].ToString());
//});

//app.MapGet("/custom-route-constraint/{name:nameRouteConstraint}", async (context) =>
//{
//    context.Response.WriteAsync("Custom Route Constraint");
//});

app.Run();
