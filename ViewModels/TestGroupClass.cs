using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DynamicDataQuestion.ViewModels
{
    public class TestGroupClass : ReactiveObject
    {
        public string Name { get; set; }
        [Reactive] public bool IsSelected { get; set; }
        public List<TestClass> TestClassList { get; set; } = new List<TestClass>();

        public TestGroupClass(string name, bool isSelected, List<TestClass> testClassList)
        {
            Name = name;
            IsSelected = isSelected;
            TestClassList = testClassList;
        }
    }
}
