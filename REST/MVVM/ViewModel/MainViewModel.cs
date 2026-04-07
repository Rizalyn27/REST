using System.Collections.ObjectModel;
using System.Windows.Input;
using REST.MVVM.Models;
using REST.MVVM.Services;
using Microsoft.Maui.Controls;

namespace REST.MVVM.ViewModel
{
    public class MainViewModel : BindableObject
    {
        private readonly ApiService _api = new ApiService();

        public ObservableCollection<Session> Sessions { get; } = new();
        public ICommand LoadCommand { get; }

        public MainViewModel()
        {
            LoadCommand = new Command(async () => await LoadAsync());
            _ = LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                Sessions.Clear();
                var list = await _api.GetAllAsync();
                foreach (var s in list)
                    Sessions.Add(s);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}