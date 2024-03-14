
using System.Text.Json;

namespace WebApp.util
{
    public static class JsonHelper
    {
        public static void LogObject(this Object logObject)
        {
            var logString =  JsonSerializer.Serialize(logObject);
            Console.WriteLine(logString);
        }
    }
}
