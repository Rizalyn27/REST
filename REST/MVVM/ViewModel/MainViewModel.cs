using System.Collections.ObjectModel;
using System.Threading.Tasks;
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
            _ = LoadAsync(); // auto-load on creation
        }

        private async Task LoadAsync()
        {
            Sessions.Clear();
            var list = await _api.GetAllAsync();
            foreach (var s in list)
                Sessions.Add(s);
        }
    }
}