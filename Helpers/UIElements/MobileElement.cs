using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class MobileElement
    {
        protected AppiumWebElement _element;

        public AppiumWebElement Element { get { return _element; } }
        protected MobileElement(AppiumWebElement element)
        {
            _element = element;
        }
    }
}
