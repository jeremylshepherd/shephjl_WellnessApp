using shephjl_WellnessApp.ViewModels;
using shephjl_WellnessApp.Models;

namespace shephjl_WellnessApp
{
	public partial class MainPage : ContentPage
	{
		private MainPageViewModel ViewModel =>
			(MainPageViewModel)BindingContext;

		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}

		private void OnMaleTapped(object sender, EventArgs e)
		{
			Console.WriteLine("Male");
			ViewModel.SelectedGender = Gender.Male;
		}

		private void OnFemaleTapped(object sender, EventArgs e)
		{
			Console.WriteLine("Female");
			ViewModel.SelectedGender = Gender.Female;
		}
	}
}