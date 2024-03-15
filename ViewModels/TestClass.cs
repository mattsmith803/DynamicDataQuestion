using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DynamicDataQuestion.ViewModels
{
    public class TestClass : ReactiveObject
    {
        public string Name { get; set; }
        [Reactive] public bool IsSelected { get; set; }

        public TestClass(string name, bool isSelected)
        {
            Name = name;
            IsSelected = isSelected;
        }
    }
}
