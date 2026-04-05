using System.Threading.Tasks;
using System.Windows.Input;
using REST.MVVM.Models;
using REST.MVVM.Services;
using Microsoft.Maui.Controls;

namespace REST.MVVM.ViewModel
{
    public class UpdateViewModel : BindableObject
    {
        private readonly ApiService _api = new ApiService();

        public Session CurrentSession { get; set; } = new Session();

        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public UpdateViewModel()
        {
            UpdateCommand = new Command(async () => await UpdateAsync());
            DeleteCommand = new Command(async () => await DeleteAsync());
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