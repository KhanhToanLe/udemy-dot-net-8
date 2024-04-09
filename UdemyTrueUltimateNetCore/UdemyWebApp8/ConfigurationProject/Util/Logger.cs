using ConfigurationProject.ConfigHandler;
using ConfigurationProject.Services;

namespace ConfigurationProject.Util
{
    public static class Logger
    {
        private static IConfigurateServices _configService { get; set; }
        public static string Log(this string logMessage)
        {
            if (ConfigReader.isDevelopLog && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                Console.WriteLine(logMessage);
            return logMessage;
        }
        public static void Inject(IConfigurateServices test)
        {
            _configService = test;
        }
    }
}
