using Helpers.Drivers.Mobile;
using Helpers.Interfaces;
using MobileViews;

namespace MobileTests
{
    public class Tests
    {
        IDriverManager _driver;
        [SetUp]
        public void Setup()
        {
            _driver = new MobileDriverManager();
            var welcomeView = new WelcomeView(_driver);
            welcomeView.Skip.Click();
        }

        [Test]
        public void CreateYesOrNoHabit()
        {
            var habitsView = new HabitsView(_driver);
            habitsView.AddHabit.Click();
            habitsView.SelectHabitType("Yes or No");

            var createHabitView = new CreateHabitView(_driver);
            createHabitView.HabitName.SetText("Exercise");
            createHabitView.HabitQuestion.SetText("Did you exercise today?");
            createHabitView.Save.Click();

            Assert.Multiple(() =>
            {
                Assert.That(habitsView.NewHabitName.Text, Is.EqualTo("Exercise"), "The name of the new habit was not \"Exercise\"");

                habitsView.NewHabitName.Click();
                var habitView = new HabitView(_driver);
                Assert.That(habitView.HabitQuestion.Text, Is.EqualTo("Did you exercise today?"), "The question of the new habit is not \"\"Did you exercise today?\"\"");
            });
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}