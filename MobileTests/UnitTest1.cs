using Helpers.Drivers.Mobile;
using Helpers.Interfaces;

namespace MobileTests
{
    public class Tests
    {
        IDriverManager _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new MobileDriverManager();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}