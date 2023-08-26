using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;

namespace Helpers.Drivers.Mobile
{
    public static class AndroidDriverBuilder
    {
        public static AppiumDriver<AppiumWebElement> GetDriver()
        {
            var driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability("appium:appPackage", "org.isoron.uhabits");
            driverOptions.AddAdditionalCapability("appium:appActivity", ".MainActivity");
            driverOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");

            return new AndroidDriver<AppiumWebElement>(new Uri("http://localhost:4723"), driverOptions);
        }
    }
}
