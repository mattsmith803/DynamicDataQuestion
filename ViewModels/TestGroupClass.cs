using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace DynamicDataQuestion.ViewModels
{
    public class TestGroupClass : ReactiveObject
    {
        public string Name { get; set; }
        [Reactive] public bool IsSelected { get; set; }
        public SourceList<TestClass> TestClassesSource { get; set; }

        public TestGroupClass(string name, bool isSelected, List<TestClass> testClassList)
        {
            Name = name;
            IsSelected = isSelected;

            TestClassesSource = new SourceList<TestClass>();

            TestClassesSource.Edit(list =>
            {
                list.AddRange(testClassList);
            });
        }
    }
}
