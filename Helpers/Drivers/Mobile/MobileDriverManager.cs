using Helpers.Enums;
using Helpers.Interfaces;
using OpenQA.Selenium.Appium;

namespace Helpers.Drivers.Mobile
{
    public class MobileDriverManager : IDriverManager
    {
        private AppiumDriver<AppiumWebElement> _driver;

        public MobileDriverManager()
        {
            switch (BaseConfiguration.PlatformName)
            {
                case PlatformName.Android:
                    _driver = AndroidDriverBuilder.GetDriver();
                    break;
                case PlatformName.iOS:
                    throw new NotImplementedException();
                case PlatformName.None:
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
    }
}
