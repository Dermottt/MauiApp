using SleepSure.Page;

namespace SleepSure
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Ensure Flyout is initially disabled if not logged in
            ((AppShell)MainPage).UpdateFlyoutBehavior();
        }
    }
}

