using Helpers.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace Helpers.UIElements
{
    public class Button : Text, IButton
    {
        public Button(AppiumElement element) : base(element) { }

        public void Click()
        {
            if (Element.Displayed && Element.Enabled)
            {
                Element.Click();
            }
            else
            {
                throw new ElementNotInteractableException("Could not click on button.");
            }
        }
    }
}
