namespace SleepSure
{
    public partial class AppShell : Shell
    {
        // Define the IsLoggedIn property
        public bool IsLoggedIn { get; set; } = false;

        public AppShell()
        {
            InitializeComponent();
            UpdateFlyoutBehavior();  // Update flyout behavior based on login status
        }

        public void UpdateFlyoutBehavior()
        {
            // Set FlyoutBehavior based on IsLoggedIn property
            FlyoutBehavior = IsLoggedIn ? FlyoutBehavior.Flyout : FlyoutBehavior.Disabled;
        }
    }
}
