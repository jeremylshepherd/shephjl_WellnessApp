using shephjl_WellnessApp.ViewModels;

namespace shephjl_WellnessApp.Views
{
    public partial class ResultPage : ContentPage
    {
        private MainPageViewModel ViewModel { get; }

        public ResultPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            BindingContext = viewModel;
        }

        private async void OnRecommendationsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecommendationPage(ViewModel));
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}