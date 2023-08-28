using Helpers.Enums;
using Helpers.Interfaces;

namespace MobileViews
{
    public class HabitsView : BaseView
    {
        public HabitsView(IDriverManager driver) : base(driver) { }

        public IButton AddHabit => (IButton)_driver.GetElement(ElementType.Button, FindsBy.AccesibilityId, "Add habit");
        public IButton NewHabitName => (IButton)_driver.GetElement(
            ElementType.Button,
            FindsBy.XPath,
            $"//androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout[last()]/android.widget.LinearLayout/android.widget.TextView");

        public void SelectHabitType(string habitType)
        {
            IButton habitTypeElement = (IButton)_driver.GetElement(ElementType.Button, FindsBy.XPath, $"//android.widget.TextView[@text='{habitType}']");
            habitTypeElement.Click();
        }
    }
}