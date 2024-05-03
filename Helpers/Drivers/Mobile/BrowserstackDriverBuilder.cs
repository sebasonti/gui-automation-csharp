using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using Helpers.Enums;

namespace Helpers.Drivers.Mobile
{
    public static class BrowserstackDriverBuilder
    {
        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            if (BaseConfiguration.PlatformName == PlatformType.Android)
            {
                return new AndroidDriver<AppiumWebElement>(new Uri(BaseConfiguration.RemoteAppiumServer), GetCapabilities());
            }
            return new IOSDriver<AppiumWebElement>(new Uri(BaseConfiguration.RemoteAppiumServer), GetCapabilities());
        }

        private static AppiumOptions GetCapabilities()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability("platformName", BaseConfiguration.PlatformName);
            driverOptions.AddAdditionalCapability("deviceName", BaseConfiguration.DeviceName);
            driverOptions.AddAdditionalCapability("platformVersion", BaseConfiguration.PlatformVersion);

            driverOptions.AddAdditionalCapability("browserstack.user", BaseConfiguration.BrowserstackUsername);
            driverOptions.AddAdditionalCapability("browserstack.key", BaseConfiguration.BrowserstackAccessKey);
            driverOptions.AddAdditionalCapability("app", BaseConfiguration.App);

            if (BaseConfiguration.PlatformName == PlatformType.Android)
            {
                driverOptions.AddAdditionalCapability("automationName", "UiAutomator2");
            }
            else
            {
                driverOptions.AddAdditionalCapability("automationName", "XCUITest");
            }

            return driverOptions;
        }
    }
}
