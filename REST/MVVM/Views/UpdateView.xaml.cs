using REST.MVVM.ViewModel;

namespace REST.MVVM.Views;

public partial class UpdateView : ContentPage
{
    public UpdateView()
    {
        InitializeComponent();
        BindingContext = new UpdateViewModel();
    }

    private async void Back_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}