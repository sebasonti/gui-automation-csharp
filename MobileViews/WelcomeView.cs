using Helpers.Enums;
using Helpers.Interfaces;

namespace MobileViews
{
    public class WelcomeView : BaseView
    {
        public WelcomeView(IDriverManager driver) : base(driver) { }

        public IButton Skip => (IButton)_driver.GetElement(ElementType.Button, FindsBy.AccesibilityId, "SKIP");
    }
}
