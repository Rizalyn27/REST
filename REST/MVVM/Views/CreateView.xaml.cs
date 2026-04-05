namespace REST.MVVM.Views;
using REST.MVVM.ViewModel;


public partial class CreateView : ContentPage
{
    public CreateView()
    {
        InitializeComponent();
        BindingContext = new CreateViewModel();
    }

    private async void Close_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainView());
    }

    
}