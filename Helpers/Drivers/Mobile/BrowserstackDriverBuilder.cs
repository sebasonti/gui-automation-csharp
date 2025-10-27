using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using Helpers.Enums;

namespace Helpers.Drivers.Mobile
{
    public static class BrowserstackDriverBuilder
    {
        public static AppiumDriver GetDriver()
        {
            if (BaseConfiguration.PlatformName == PlatformType.Android)
            {
                return new AndroidDriver(new Uri(BaseConfiguration.RemoteAppiumServer), GetCapabilities());
            }
            return new IOSDriver(new Uri(BaseConfiguration.RemoteAppiumServer), GetCapabilities());
        }

        private static AppiumOptions GetCapabilities()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.PlatformName = BaseConfiguration.PlatformName.ToString();
            driverOptions.DeviceName = BaseConfiguration.DeviceName;
            driverOptions.PlatformVersion = BaseConfiguration.PlatformVersion;

            Dictionary<string, object> bstackOptions = new Dictionary<string, object>
            {
              { "userName", BaseConfiguration.BrowserstackUsername },
              { "accessKey", BaseConfiguration.BrowserstackAccessKey }
            };
            driverOptions.AddAdditionalAppiumOption("bstack:options", bstackOptions);
            driverOptions.App = BaseConfiguration.App;

            if (BaseConfiguration.PlatformName == PlatformType.Android)
            {
                driverOptions.AutomationName = "UiAutomator2";
            }
            else
            {
                driverOptions.AutomationName = "XCUITest";
            }

            return driverOptions;
        }
    }
}
