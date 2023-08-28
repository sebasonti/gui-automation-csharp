using Helpers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class Button : Text, IButton
    {
        public Button(AppiumWebElement element) : base(element) { }

        public void Click()
        {
            if (_element.Displayed && _element.Enabled)
            {
                _element.Click();
            }
            else
            {
                throw new ElementNotInteractableException("Could not click on button.");
            }
        }
    }
}
