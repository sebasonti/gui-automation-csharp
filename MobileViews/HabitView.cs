using Helpers.Enums;
using Helpers.Interfaces;

namespace MobileViews
{
    public class HabitView : BaseView
    {
        public HabitView(IDriverManager driver) : base(driver) { }

        public IText HabitQuestion => (IText)_driver.GetElement(ElementType.Text, FindsBy.Id, "org.isoron.uhabits:id/questionLabel");
    }
}
