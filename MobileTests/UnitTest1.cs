using Helpers.Drivers.Mobile;

namespace MobileTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var driver = AndroidDriverBuilder.GetDriver();
            driver.CloseApp();
            driver.Quit();
            Assert.Pass();
        }
    }
}