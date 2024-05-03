using Helpers.Enums;
using Microsoft.Extensions.Configuration;
using PlatformType = Helpers.Enums.PlatformType;

namespace Helpers
{
    internal static class ConfigurationHelper
    {
        public static readonly IConfigurationRoot Builder = new ConfigurationBuilder()
            .AddJsonFile("configuration.json")
            .Build();

        public static string GetString(string section, string key)
        {
            string? envVar = Environment.GetEnvironmentVariable(key);
            if (envVar != null)
            {
                return envVar;
            }

            string? value = Builder[$"{section}:{key}"];
            if (value == null)
            {
                throw new NullReferenceException($"Key {key} is not available on configuration.json");
            }
            return value;
        }

        public static int GetInt(string section, string key)
        {
            return int.Parse(GetString(section, key));
        }

        public static bool GetBool(string section, string key)
        {
            return bool.Parse(GetString(section, key));
        }

        public static PlatformType GetPlatformType(string section, string key)
        {
            bool supportedPlatform = Enum.TryParse(GetString(section, key), out PlatformType platformName);

            if (supportedPlatform)
            {
                return platformName;
            }

            throw new ArgumentException("Invalid platformName passed.");
        }

        public static DeviceCloudProvider GetDeviceCloudProvider(string section, string key)
        {
            bool supportedCloudProvider = Enum.TryParse(GetString(section, key), out DeviceCloudProvider deviceCloudProvider);

            if (supportedCloudProvider)
            {
                return deviceCloudProvider;
            }

            throw new ArgumentException("Invalid deviceCloudProvider passed.");
        }
    }
}
