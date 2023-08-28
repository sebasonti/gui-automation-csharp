using Helpers.Interfaces;

namespace MobileViews
{
    public abstract class BaseView
    {
        protected IDriverManager _driver;
        protected BaseView(IDriverManager driver)
        {
            _driver = driver;
        }
    }
}
