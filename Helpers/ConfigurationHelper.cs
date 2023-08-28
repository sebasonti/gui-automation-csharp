using Microsoft.Extensions.Configuration;

namespace Helpers
{
    internal static class ConfigurationHelper
    {
        public static readonly IConfigurationRoot Builder = new ConfigurationBuilder()
            .AddJsonFile("configuration.json")
            .Build();

        public static string GetString(string section, string key)
        {
            string envVar = Environment.GetEnvironmentVariable(key);
            if (envVar != null)
            {
                return envVar;
            }

            string value = Builder[$"{section}:{key}"];
            if (value == null)
            {
                throw new NullReferenceException($"Key {key} is not available on configuration.json");
            }
            return Builder[$"{section}:{key}"];
        }

        public static int GetInt(string section, string key)
        {
            return int.Parse(GetString(section, key));
        }
    }
}
