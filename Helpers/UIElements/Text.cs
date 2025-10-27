using Helpers.Interfaces;
using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class Text : MobileElement, IText
    {
        public Text(AppiumElement element) : base(element) { }

        string IText.Text => Element.Text;
    }
}
