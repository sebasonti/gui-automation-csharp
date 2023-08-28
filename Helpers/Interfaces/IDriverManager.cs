using Helpers.Enums;
using Helpers.UIElements;

namespace Helpers.Interfaces
{
    public interface IDriverManager
    {
        void Close();
        byte[] TakeScreenshot();

        MobileElement GetElement(ElementType elementType, FindsBy findsBy, string locator);
    }
}
