using REST.MVVM.Views;

namespace REST
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CreateView), typeof(CreateView));
            Routing.RegisterRoute(nameof(UpdateView), typeof(UpdateView));
        }
    }
}
