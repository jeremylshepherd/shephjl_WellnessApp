using shephjl_WellnessApp.ViewModels;
using shephjl_WellnessApp.Models;

namespace shephjl_WellnessApp.Views
{
    public partial class InputPage : ContentPage
    {
        private MainPageViewModel ViewModel => (MainPageViewModel)BindingContext;

        public InputPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnMaleTapped(object sender, EventArgs e)
        {
            ViewModel.SelectedGender = Gender.Male;
        }

        private void OnFemaleTapped(object sender, EventArgs e)
        {
            ViewModel.SelectedGender = Gender.Female;
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResultPage(ViewModel));
        }
    }
}