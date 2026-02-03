namespace shephjl_WellnessApp.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    private string _title = "Wellness App";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}