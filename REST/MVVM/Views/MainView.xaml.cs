using REST.MVVM.ViewModel;
using REST.MVVM.Models;


namespace REST.MVVM.Views;

public partial class MainView : ContentPage
{
    public MainView()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    // Logout / close — application exit
    private void Closed_Click(object sender, EventArgs e)
    {
        Application.Current?.Quit();
    }

    private async void Create_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateView());
    }

    private async void Update_Clicked(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        var session = frame?.BindingContext as Session;
        if (session == null) return;

        await Shell.Current.GoToAsync($"{nameof(UpdateView)}?id={session.Id}");
    }
}