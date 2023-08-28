using Helpers.Enums;

namespace Helpers
{
    internal static class BaseConfiguration
    {
        public static PlatformName PlatformName
        {
            get
            {
                string configuration = ConfigurationHelper.GetString("settings", "platformName");
                bool supportedPlatform = Enum.TryParse(configuration, out PlatformName platformName);

                if (supportedPlatform)
                {
                    return platformName;
                }

                throw new ArgumentException("Invalid platformName passed.");
            }
        }
        public static string AppiumServer = ConfigurationHelper.GetString("settings", "appiumServer");
        public static string RemoteAppiumServer = ConfigurationHelper.GetString("settings", "remoteAppiumServer");
        public static int ExplicitTimeout = ConfigurationHelper.GetInt("settings", "explicitTimeout");
        public static string AppPackage = ConfigurationHelper.GetString("aut", "appPackage");
        public static string AppActivity = ConfigurationHelper.GetString("aut", "appActivity");
        public static string DeviceName = ConfigurationHelper.GetString("settings", "deviceName");
        public static string PlatformVersion = ConfigurationHelper.GetString("settings", "platformVersion");
        public static string BrowserstackUsername = ConfigurationHelper.GetString("browserstack", "user");
        public static string BrowserstackAccessKey = ConfigurationHelper.GetString("browserstack", "accessKey");
        public static string App = ConfigurationHelper.GetString("settings", "app");

        public static DeviceCloudProvider DeviceCloudProvider
        {
            get
            {
                string configuration = ConfigurationHelper.GetString("settings", "deviceCloudProvider");
                bool supportedCloudProvider = Enum.TryParse(configuration, out DeviceCloudProvider deviceCloudProvider);

                if (supportedCloudProvider)
                {
                    return deviceCloudProvider;
                }

                throw new ArgumentException("Invalid deviceCloudProvider passed.");
            }
        }
    }
}