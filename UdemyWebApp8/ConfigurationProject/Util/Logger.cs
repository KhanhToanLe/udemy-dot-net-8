using ConfigurationProject.ConfigHandler;

namespace ConfigurationProject.Util
{
    public static class Logger
    {
        public static string Log(this string logMessage)
        {
            if (ConfigReader.isDevelopLog && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                Console.WriteLine(logMessage);
            return logMessage;
        }
    }
}
