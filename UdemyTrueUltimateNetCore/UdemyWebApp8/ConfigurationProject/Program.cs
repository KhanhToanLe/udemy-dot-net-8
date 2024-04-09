using ConfigurationProject.ConfigHandler;
using ConfigurationProject.Model;
using ConfigurationProject.Services;
using ConfigurationProject.Util;

var builder = WebApplication.CreateBuilder(args);
// register service
builder.Services.AddTransient<IConfigurateServices, ConfigurateServices>();
// add custom json files
builder.Configuration.AddJsonFile("CustomConfigJsonFiles/MyConfig.json",
        optional: true,
        reloadOnChange: true);
// add custom json files (afternative)
builder.Host.ConfigureAppConfiguration((hostingcontext, config) =>
{
    config.AddJsonFile("CustomConfigJsonFiles/MyConfig.json",
        optional: true,
        reloadOnChange: true);
});

// get conf
var configService = builder.Configuration.GetSection("Service");
// add config as service
builder.Services.Configure<ConfigService>(configService);

// get config from secret.json
var secretMessage = builder.Configuration["secretMessage:echo"];
secretMessage.Log();

// get registered service
var configServiceInstance = builder.Services.BuildServiceProvider().GetRequiredService<IConfigurateServices>();
Logger.Inject(configServiceInstance);


var isDevelopmentLog =  builder.Configuration.GetValue<bool>("IsDevelopLoggin");
new ConfigReader(builder.Configuration);

builder.Services.AddControllers();
var app = builder.Build();

//using (var scoped = app.Services.CreateScope())
//{
//    // get registed service
//    var test2 = scoped.ServiceProvider.GetService<IConfigurateServices>();
//    test2.GetConfiguration();
//}

var test2 = app.Services.GetService<IConfigurateServices>();
test2.GetConfiguration();

var isDeveloplog = app.Configuration["IsDevelopLogging"];
isDeveloplog?.Log();

//ConfigModel? configModel = app.Configuration.GetValue<ConfigModel?>("TimeOut",new ConfigModel("default value",12) );

//ConfigModel? configModel = app.Configuration.GetSection("TimeOut").Get<ConfigModel>();

// bind config to existed object
ConfigModel? configModel = new ConfigModel();
app.Configuration.GetSection("TimeOut").Bind(configModel);

configModel.ToString().Log();

// get config with nested json
var nestedConfigTest = app.Configuration["NestedConfig:ChildValue:Test"];
nestedConfigTest?.Log();

var customFileConfig = app.Configuration["DummyConfig"];
customFileConfig.Log();

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run();
