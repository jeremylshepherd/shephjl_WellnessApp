using shephjl_WellnessApp.ViewModels;

namespace shephjl_WellnessApp.Views
{
    public partial class RecommendationPage : ContentPage
    {
        public RecommendationPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void OnBackToResultsClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnBackToInputsClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}