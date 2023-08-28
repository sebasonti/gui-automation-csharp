using Helpers.Enums;
using Helpers.Interfaces;

namespace MobileViews
{
    public class CreateHabitView : BaseView
    {
        public CreateHabitView(IDriverManager driver) : base(driver) { }

        public ITextField HabitName => (ITextField)_driver.GetElement(ElementType.TextField, FindsBy.Id, "org.isoron.uhabits:id/nameInput");
        public ITextField HabitQuestion => (ITextField)_driver.GetElement(ElementType.TextField, FindsBy.Id, "org.isoron.uhabits:id/questionInput");
        public IButton Save => (IButton)_driver.GetElement(ElementType.Button, FindsBy.Id, "org.isoron.uhabits:id/buttonSave");
    }
}
