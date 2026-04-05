using REST.MVVM.ViewModel;

namespace REST.MVVM.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
    private async void Closed_Click(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainView());
    }

    private async void Create_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CreateView));
    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UpdateView());
    }
}