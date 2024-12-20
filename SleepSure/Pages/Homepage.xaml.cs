using Microsoft.Maui.Controls;
using System;

namespace SleepSure.Page
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnConfigureMotion(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Motion Sensors", "Open settings for Motion Sensors.", "OK");
        }

        private async void OnConfigureCamera(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Cameras", "Open settings for Cameras.", "OK");
        }

        private async void OnConfigureDoorWindow(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Door and Window Sensors", "Open settings for Door and Window Sensors.", "OK");
        }

        private async void OnConfigureTempHumid(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Temperature and Humidity Sensors", "Open settings for Temperature and Humidity Sensors.", "OK");
        }

        private async void OnConfigureVibration(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Vibration Sensors", "Open settings for Vibration Sensors.", "OK");
        }

        private async void OnConfigureWaterLeak(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Water Leak Sensors", "Open settings for Water Leak Sensors.", "OK");
        }

        private async void OnConfigureLights(object sender, EventArgs e)
        {
            await DisplayAlert("Configure Lights", "Open settings for Lights.", "OK");
        }

        private async void OnViewCamerasClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//CameraPage");
        }

        private async void OnCheckSensorsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//UniqueSensorPage");
        }


        private async void OnAdjustLightsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LightPage");
        }

        private async void OnOpenProfileClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProfilePage");
        }

    }
}
