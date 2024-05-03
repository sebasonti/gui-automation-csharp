using Helpers.Enums;

namespace Helpers
{
    internal static class BaseConfiguration
    {
        public static PlatformType PlatformName = ConfigurationHelper.GetPlatformType("settings", "platformName");
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
        public static DeviceCloudProvider DeviceCloudProvider = ConfigurationHelper.GetDeviceCloudProvider("settings", "deviceCloudProvider");
        public static bool RemoteRun = ConfigurationHelper.GetBool("settings", "remoteRun");
    }
}