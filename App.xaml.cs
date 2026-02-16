using Microsoft.Extensions.DependencyInjection;

namespace shephjl_WellnessApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		// Create ViewModel manually for the initial page
		var viewModel = new ViewModels.MainPageViewModel();
		return new Window(new NavigationPage(new Views.InputPage(viewModel)));
	}
}