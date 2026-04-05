using System.Threading.Tasks;
using System.Windows.Input;
using REST.MVVM.Models;
using REST.MVVM.Services;
using Microsoft.Maui.Controls;

namespace REST.MVVM.ViewModel
{
    public class CreateViewModel : BindableObject
    {
        private readonly ApiService _api = new ApiService();

        public string StudentName { get; set; }
        public string CounselorName { get; set; }
        public string SessionDate { get; set; }
        public string Notes { get; set; }

        public ICommand SaveCommand { get; }

        public CreateViewModel()
        {
            SaveCommand = new Command(async () => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            var session = new Session
            {
                StudentName = StudentName,
                CounselorName = CounselorName,
                SessionDate = SessionDate,
                Notes = Notes
            };

            await _api.CreateAsync(session);
            await Shell.Current.GoToAsync("..");  // go back after save
        }
    }
}