using ConfigurationProject.ConfigHandler;
using ConfigurationProject.Model;
using ConfigurationProject.Services;
using ConfigurationProject.Util;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IConfigurateServices, ConfigurateServices>();

var configService = builder.Configuration.GetSection("Service");
builder.Services.Configure<ConfigService>(configService);

var secretMessage = builder.Configuration["secretMessage:echo"];
secretMessage.Log();

var isDevelopmentLog =  builder.Configuration.GetValue<bool>("IsDevelopLoggin");
new ConfigReader(builder.Configuration);

builder.Services.AddControllers();
var app = builder.Build();

var isDeveloplog = app.Configuration["IsDevelopLogging"];
isDeveloplog?.Log();

//ConfigModel? configModel = app.Configuration.GetValue<ConfigModel?>("TimeOut",new ConfigModel("default value",12) );

//ConfigModel? configModel = app.Configuration.GetSection("TimeOut").Get<ConfigModel>();
ConfigModel? configModel = new ConfigModel();
app.Configuration.GetSection("TimeOut").Bind(configModel);

configModel.ToString().Log();

//configModel?.ToString().Log();

var nestedConfigTest = app.Configuration["NestedConfig:ChildValue:Test"];
nestedConfigTest?.Log();

app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run();
