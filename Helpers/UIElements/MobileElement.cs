using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class MobileElement
    {
        public AppiumElement Element { get; private set; }
        protected MobileElement(AppiumElement element)
        {
            Element = element;
        }
    }
}
