using Helpers.Enums;
using Helpers.Interfaces;
using Helpers.UIElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;

namespace Helpers.Drivers.Mobile
{
    public class MobileDriverManager : IDriverManager
    {
        private AppiumDriver<AppiumWebElement> _driver;

        public MobileDriverManager()
        {
            switch (BaseConfiguration.DeviceCloudProvider)
            {
                case DeviceCloudProvider.Browserstack:
                    _driver = BrowserstackDriverBuilder.GetDriver();
                    return;
                default:
                    break;
            }

            switch (BaseConfiguration.PlatformName)
            {
                case PlatformName.Android:
                    _driver = AndroidDriverBuilder.GetDriver();
                    return;
                case PlatformName.iOS:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException("Driver for given platform is not supported.");
            }
        }

        public void Close()
        {
            _driver.CloseApp();
            _driver.Quit();
        }

        public byte[] TakeScreenshot()
        {
            return _driver.GetScreenshot().AsByteArray;
        }

        public MobileElement GetElement(ElementType elementType, FindsBy findsBy, string locator)
        {
            AppiumWebElement appiumElement = FindElement(findsBy, locator);
            switch (elementType)
            {
                case ElementType.Button:
                    return new Button(appiumElement);
                case ElementType.TextField:
                    return new TextField(appiumElement);
                case ElementType.Text:
                    return new Text(appiumElement);
                default:
                    throw new NotSupportedException($"Element type \"{elementType}\" not supported.");
            }
        }

        private AppiumWebElement FindElement(FindsBy findsBy, string locator)
        {
            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(BaseConfiguration.ExplicitTimeout));

            switch (findsBy)
            {
                case FindsBy.XPath:
                    return wait.Until(driver => _driver.FindElementByXPath(locator));
                case FindsBy.Id:
                    return wait.Until(driver => _driver.FindElementById(locator));
                case FindsBy.AccesibilityId:
                    return wait.Until(driver => _driver.FindElementByAccessibilityId(locator));
                default:
                    throw new NotSupportedException($"Locator type \"{findsBy}\" not supported");
            }
        }
    }
}
