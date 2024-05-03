using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class MobileElement
    {
        public AppiumWebElement Element { get; private set; }
        protected MobileElement(AppiumWebElement element)
        {
            Element = element;
        }
    }
}
