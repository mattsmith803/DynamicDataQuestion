using DynamicDataQuestion.ViewModels;

namespace DynamicDataQuestion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = this.BindingContext = new MainPageViewModel();
        }
    }
}
