using Helpers.Drivers.Mobile;

namespace MobileTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var driver = AndroidDriverBuilder.GetDriver();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}