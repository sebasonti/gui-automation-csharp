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
        private AppiumDriver _driver;

        public MobileDriverManager()
        {
            if (BaseConfiguration.RemoteRun)
            {
                switch (BaseConfiguration.DeviceCloudProvider)  
                {
                    case DeviceCloudProvider.Browserstack:
                        _driver = BrowserstackDriverBuilder.GetDriver();
                        return;
                    case DeviceCloudProvider.None:
                    default:
                        throw new NotSupportedException("Device cloud provider is not supported.");
                }
            }
            switch (BaseConfiguration.PlatformName)
            {
                case Enums.PlatformType.Android:
                    _driver = AndroidDriverBuilder.GetDriver();
                    return;
                case Enums.PlatformType.iOS:
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException("Driver for given platform is not supported.");
            }
        }

        public void Close()
        {
            _driver.Quit();
        }

        public byte[] TakeScreenshot()
        {
            return _driver.GetScreenshot().AsByteArray;
        }

        public MobileElement GetElement(ElementType elementType, FindsBy findsBy, string locator)
        {
            AppiumElement appiumElement = FindElement(findsBy, locator);

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

        private AppiumElement FindElement(FindsBy findsBy, string locator)
        {
            IWait<IWebDriver> wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(BaseConfiguration.ExplicitTimeout));

            try
			{
				By by;
				switch (findsBy)
				{
					case FindsBy.XPath:
                        by = By.XPath(locator);
                        break;
					case FindsBy.Id:
                        by = By.Id(locator);
                        break;
                    case FindsBy.ContentDescription:
                        by = By.XPath($"//*[@content-desc=\"{locator}\"]");
                        break;
					default:
						throw new NotSupportedException($"Locator type \"{findsBy}\" not supported");
				}
                return wait.Until(driver => _driver.FindElement(by));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NoSuchElementException($"Element with locator {findsBy}: {locator} was not found.", ex);
            }
        }
    }
}
