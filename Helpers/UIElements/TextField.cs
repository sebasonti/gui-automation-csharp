using Helpers.Interfaces;
using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class TextField : MobileElement, ITextField
    {
        public TextField(AppiumWebElement element) : base(element) { }

        public void SetText(string text)
        {
            Element.SendKeys(text);
        }
        string ITextField.Text => Element.Text;
    }
}
