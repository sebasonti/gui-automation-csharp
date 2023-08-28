using Helpers.Interfaces;
using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class Text : MobileElement, IText
    {
        public Text(AppiumWebElement element) : base(element) { }

        string IText.Text => _element.Text;
    }
}
