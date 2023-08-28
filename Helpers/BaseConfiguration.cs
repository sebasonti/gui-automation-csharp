namespace Helpers
{
    public static class BaseConfiguration
    {
        public static string PlatformName = ConfigurationHelper.GetString("settings", "platformName");
        public static string AppiumServer = ConfigurationHelper.GetString("settings", "appiumServer");
        public static string AppPackage = ConfigurationHelper.GetString("aut", "appPackage");
        public static string AppActivity = ConfigurationHelper.GetString("aut", "appActivity");
    }
}