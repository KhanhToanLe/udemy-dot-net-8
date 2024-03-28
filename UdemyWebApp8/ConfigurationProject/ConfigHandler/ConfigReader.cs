namespace ConfigurationProject.ConfigHandler
{
    public class ConfigReader
    {
        private static IConfiguration config{ get; set; }
        public static bool isDevelopLog { get; private set; }
        public ConfigReader(IConfiguration configuration)
        {
            config = configuration;
            GetIsDevelopLog();
        }
        public void GetIsDevelopLog()
        {
            isDevelopLog = config.GetValue<bool>("IsDevelopLogging");
        }

    }
}
