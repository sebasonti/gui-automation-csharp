namespace Helpers.Interfaces
{
    public interface IDriverManager
    {
        void Close();
        byte[] TakeScreenshot();
    }
}
