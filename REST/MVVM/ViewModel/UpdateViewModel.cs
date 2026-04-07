using System.Threading.Tasks;
using System.Windows.Input;
using REST.MVVM.Models;
using REST.MVVM.Services;
using Microsoft.Maui.Controls;

namespace REST.MVVM.ViewModel
{
    public class UpdateViewModel : BindableObject, IQueryAttributable
    {
        private readonly ApiService _api = new ApiService();

        private Session _currentSession = new Session();
        public Session CurrentSession
        {
            get => _currentSession;
            set
            {
                _currentSession = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public UpdateViewModel()
        {
            UpdateCommand = new Command(async () => await UpdateAsync());
            DeleteCommand = new Command(async () => await DeleteAsync());
        }

        // Called automatically by Shell when navigating with query parameters
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("id", out var id))
                _ = LoadSessionAsync(id.ToString());
        }

        private async Task LoadSessionAsync(string id)
        {
            try
            {
                var session = await _api.GetByIdAsync(id);
                CurrentSession = session;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task UpdateAsync()
        {
            await _api.UpdateAsync(CurrentSession);
            await Shell.Current.GoToAsync("..");
        }

        private async Task DeleteAsync()
        {
            bool confirm = await Shell.Current.DisplayAlert(
                "Hard Delete",
                "This action is permanent. Are you sure?",
                "Delete", "Cancel");

            if (confirm)
            {
                await _api.DeleteAsync(CurrentSession.Id);
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}