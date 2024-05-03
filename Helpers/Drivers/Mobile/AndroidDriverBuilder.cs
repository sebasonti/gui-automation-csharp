using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Helpers.Drivers.Mobile
{
    public static class AndroidDriverBuilder
    {
        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            return new AndroidDriver<AppiumWebElement>(new Uri(BaseConfiguration.AppiumServer), GetCapabilities());
        }

        private static AppiumOptions GetCapabilities()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability("platformName", BaseConfiguration.PlatformName);
            driverOptions.AddAdditionalCapability("appium:appPackage", BaseConfiguration.AppPackage);
            driverOptions.AddAdditionalCapability("appium:appActivity", BaseConfiguration.AppActivity);
            //driverOptions.AddAdditionalCapability("appium:app", "<apk directory>");
            driverOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");

            return driverOptions;
        }
    }
}
