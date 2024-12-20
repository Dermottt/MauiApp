using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace SleepSure.Page
{
    public partial class CameraPage : ContentPage
    {
        public ObservableCollection<Camera> Cameras { get; set; }
        private bool areAllEnabled = true;

        public CameraPage()
        {
            InitializeComponent();
            Cameras = new ObservableCollection<Camera>();
            BindingContext = this;
        }

        private void OnAddCameraClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CameraNameEntry.Text) && !string.IsNullOrWhiteSpace(CameraIPEntry.Text))
            {
                Cameras.Add(new Camera
                {
                    Name = CameraNameEntry.Text,
                    IPAddress = CameraIPEntry.Text,
                    IsEnabled = true // Cameras are enabled by default when added
                });

                CameraNameEntry.Text = string.Empty;
                CameraIPEntry.Text = string.Empty;
            }
        }

        private void OnDeleteCameraClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var camera = button?.CommandParameter as Camera;
            if (camera != null)
            {
                Cameras.Remove(camera);
            }
        }

        private void OnMasterToggleClicked(object sender, EventArgs e)
        {
            areAllEnabled = !areAllEnabled;

            foreach (var camera in Cameras)
            {
                camera.IsEnabled = areAllEnabled;
            }

            MasterToggleButton.Text = areAllEnabled ? "Disable All" : "Enable All";
        }
    }

    public class Camera : BindableObject
    {
        private bool isEnabled;

        public string Name { get; set; }
        public string IPAddress { get; set; }

        public bool IsEnabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }
    }

    public class BooleanToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isEnabled)
            {
                return isEnabled ? "Enabled" : "Disabled";
            }
            return "Disabled";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
