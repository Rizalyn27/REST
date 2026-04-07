using System.Windows.Input;
using REST.MVVM.Models;
using REST.MVVM.Services;
using Microsoft.Maui.Controls;

namespace REST.MVVM.ViewModel
{
    public class CreateViewModel : BindableObject
    {
        private readonly ApiService _api = new ApiService();

        private string _studentName;
        public string StudentName
        {
            get => _studentName;
            set { _studentName = value; OnPropertyChanged(); }
        }

        private string _counselorName;
        public string CounselorName
        {
            get => _counselorName;
            set { _counselorName = value; OnPropertyChanged(); }
        }

        private DateTime _sessionDate = DateTime.Today;
        public DateTime SessionDate
        {
            get => _sessionDate;
            set { _sessionDate = value; OnPropertyChanged(); }
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public CreateViewModel()
        {
            SaveCommand = new Command(async () => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            try
            {
                var session = new Session
                {
                    StudentName = StudentName,
                    CounselorName = CounselorName,
                    SessionDate = SessionDate.ToString("yyyy-MM-dd"),
                    Notes = Notes
                };

                await _api.CreateAsync(session);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}