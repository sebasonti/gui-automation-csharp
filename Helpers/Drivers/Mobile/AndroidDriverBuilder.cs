using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Helpers.Drivers.Mobile
{
    public static class AndroidDriverBuilder
    {
        public static AppiumDriver GetDriver()
        {
            return new AndroidDriver(new Uri(BaseConfiguration.AppiumServer), GetCapabilities());
        }

        private static AppiumOptions GetCapabilities()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.PlatformName = BaseConfiguration.PlatformName.ToString();
            driverOptions.AddAdditionalOption("appium:appPackage", BaseConfiguration.AppPackage);
            driverOptions.AddAdditionalOption("appium:appActivity", BaseConfiguration.AppActivity);
            driverOptions.AutomationName = "UiAutomator2";

            return driverOptions;
        }
    }
}
