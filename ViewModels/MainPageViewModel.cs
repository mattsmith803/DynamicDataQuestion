using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace DynamicDataQuestion.ViewModels
{
    public class MainPageViewModel
    {
        public ReadOnlyObservableCollection<TestGroupClass> TestGroupClasses => _testGroupClasses;
        private readonly ReadOnlyObservableCollection<TestGroupClass> _testGroupClasses;

        public ReadOnlyObservableCollection<TestClass> TestClasses => _testClasses;
        private ReadOnlyObservableCollection<TestClass> _testClasses;
        private SourceList<TestGroupClass> TestGroupClassesSource { get; set; } = new SourceList<TestGroupClass>();

        public MainPageViewModel()
        {
            TestGroupClassesSource.Edit(list =>
            {
                List<TestGroupClass> tests = new List<TestGroupClass>();

                var numTestGroups = 5;
                var numbTestItems = 5;
                for (var i = 0; i < numTestGroups; i++)
                {
                    List<TestClass> testClasses = new List<TestClass>();
                    for (var j = 0; j < numbTestItems; j++)
                    {
                        TestClass testClass = new TestClass($"TestClass{i}-{j}", j == 0);
                        testClasses.Add(testClass);
                    }

                    TestGroupClass group = new TestGroupClass($"TestGroupClass{i}", i == 0, testClasses);
                    tests.Add(group);
                }

                list.AddRange(tests);
            });

            TestGroupClassesSource.Connect()
                .Bind(out _testGroupClasses)
                .Subscribe();

            TestGroupClassesSource.Connect()
                .WhenPropertyChanged(x => x.IsSelected)
                .Select(x => x.Sender)
                .Where(x => x.IsSelected)
                .ToObservableChangeSet()
                .Filter(x => x.IsSelected)
                .TransformMany(x => x.TestClassesSource)
                .Bind(out _testClasses)
                .Subscribe();

            //TestGroupClassesSource.Connect()
            //    .WhenPropertyChanged(x => x.IsSelected)
            //    .Select(x => x.Sender)
            //    .Where(x => x.IsSelected)
            //    .ObserveOn(RxApp.MainThreadScheduler)
            //    .Subscribe(x =>
            //    {
            //        x.TestClassesSource.Connect()
            //            .Bind(out _testClasses)
            //            .Subscribe();
            //    });

            //TestGroupClassesSource.Connect()
            //    .WhenPropertyChanged(x => x.IsSelected)
            //    .Select(x => x.Sender)
            //    .Where(x => x.IsSelected)
            //    .ToObservableChangeSet()
            //    .TransformMany(x => x.TestClassesSource)
            //    .Bind(out _testClasses)
            //    .Subscribe();
        }
    }
}
