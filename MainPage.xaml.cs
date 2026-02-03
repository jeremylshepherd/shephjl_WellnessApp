using shephjl_WellnessApp.ViewModels;

namespace shephjl_WellnessApp;

public partial class MainPage : ContentPage
{
	
	
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
