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

                return PlatformName.None;
            }
        }
        public static string AppiumServer = ConfigurationHelper.GetString("settings", "appiumServer");
        public static int ExplicitTimeout = ConfigurationHelper.GetInt("settings", "explicitTimeout");
        public static string AppPackage = ConfigurationHelper.GetString("aut", "appPackage");
        public static string AppActivity = ConfigurationHelper.GetString("aut", "appActivity");
    }
}