using Microsoft.Maui.Controls;

namespace SleepSure.Page
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = "Test@tester.ie";
            string password = "1234";

            if (EmailEntry.Text == email && PasswordEntry.Text == password)
            {
                // Access IsLoggedIn through AppShell and update behavior
                var appShell = (AppShell)App.Current.MainPage;
                appShell.IsLoggedIn = true;
                appShell.UpdateFlyoutBehavior();

                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid email or password", "OK");
            }
        }


        private async void OnSkipLoginClicked(object sender, EventArgs e)
        {
            var appShell = (AppShell)App.Current.MainPage;
            appShell.IsLoggedIn = true;  // Set login status to true
            appShell.UpdateFlyoutBehavior();

            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }


        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Register", "Registration functionality not implemented yet", "OK");
        }
    }
}
