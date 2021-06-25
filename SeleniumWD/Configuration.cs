using System.Configuration;

namespace SeleniumWebDriver
{
    public class Configuration
    {
        public static string GetEnvironmentVar(string var, string defaultValue)
        {
            return ConfigurationManager.AppSettings[var] ?? defaultValue;
        }

        public static string ElementTimeout => GetEnvironmentVar("ElementTimeout", "30");
        public static string Browser => GetEnvironmentVar("Browser", "Firefox");
        public static string StartUrl => GetEnvironmentVar("StartUrl", "https://yandex.by/");
    }
}