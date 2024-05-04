using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using Helpers.Drivers.Mobile;
using Helpers.Interfaces;
using MobileViews;
using NUnit.Framework.Interfaces;

namespace MobileTests
{
    [AllureNUnit]
    public class Tests
    {
        IDriverManager _driver;
        [SetUp]
        [AllureBefore("Start device and load app.")]
        public void Setup()
        {
            _driver = new MobileDriverManager();
            var welcomeView = new WelcomeView(_driver);
            welcomeView.Skip.Click();
        }

        [Test]
        public void CreateYesOrNoHabit()
        {
            try
            {
                var habitsView = new HabitsView(_driver);
                AllureApi.Step("Select Habit type: Yes or No", () =>
                {
                    habitsView.AddHabit.Click();
                    habitsView.SelectHabitType("Yes or No");
                }); 

                var createHabitView = new CreateHabitView(_driver);
                AllureApi.Step("Create new habit", () =>
                {
                    createHabitView.HabitName.SetText("Exercise");
                    createHabitView.HabitQuestion.SetText("Did you exercise today?");
                    createHabitView.Save.Click();
                }); 

                Assert.Multiple(() =>
                {
                    Assert.That(habitsView.NewHabitName.Text, Is.EqualTo("Exercise"), "The name of the new habit was not \"Exercise\"");

                    habitsView.NewHabitName.Click();
                    var habitView = new HabitView(_driver);
                    Assert.That(habitView.HabitQuestion.Text, Is.EqualTo("Did you exercise today?"), "The question of the new habit is not \"\"Did you exercise today?\"\"");
                });
            }
            catch (Exception)
            {
                byte[] screenshot = _driver.TakeScreenshot();
                AllureApi.AddAttachment(
                    $"Failed: {TestContext.CurrentContext.Test.Name}",
                    "image/png",
                    screenshot
                );
                throw;
            }
        }

        [TearDown]
        public void ScreenshotOnFailure()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome;
            if (testStatus.Equals(ResultState.Failure) ||
                testStatus.Equals(ResultState.Warning) ||
                testStatus.Equals(ResultState.Error))
            {
                byte[] screenshot = _driver.TakeScreenshot();
                AllureApi.AddAttachment(
                    $"Failed: {TestContext.CurrentContext.Test.Name}",
                    "image/png",
                    screenshot
                );
            }
        }

        [TearDown]
        [AllureAfter("Stop appium session.")]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}