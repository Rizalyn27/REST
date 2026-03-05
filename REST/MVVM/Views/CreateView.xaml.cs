namespace REST.MVVM.Views;

public partial class CreateView : ContentPage
{
	public CreateView()
	{
		InitializeComponent();
	}

    private async void Close_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainView());
    }

    
}