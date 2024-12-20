using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SleepSure.Page
{
    public partial class LightPage : ContentPage
    {
        public ObservableCollection<Light> Lights { get; set; }

        public LightPage()
        {
            InitializeComponent();
            Lights = new ObservableCollection<Light>();
            LightsCollectionView.ItemsSource = Lights;
        }

        // Method to handle Add Light button click
        private async void OnAddLightClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LightNameEntry.Text) && !string.IsNullOrWhiteSpace(LightIPEntry.Text))
            {
                Lights.Add(new Light
                {
                    Name = LightNameEntry.Text,
                    IpAddress = LightIPEntry.Text,
                    Brightness = 50 // Set default brightness to 50%
                });

                // Clear the input fields after adding the light
                LightNameEntry.Text = string.Empty;
                LightIPEntry.Text = string.Empty;
            }
        }


        // Method to handle Turn Off All Lights button click
        private void OnTurnOffAllLightsClicked(object sender, EventArgs e)
        {
            foreach (var light in Lights)
            {
                light.Brightness = 0;
            }
            // Refresh the collection view to reflect the updated brightness
            LightsCollectionView.ItemsSource = null;
            LightsCollectionView.ItemsSource = Lights;
        }

        // Method to handle Delete Light button click
        private void OnDeleteLightClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var light = button?.CommandParameter as Light;
            if (light != null && Lights.Contains(light))
            {
                Lights.Remove(light);
            }
        }
    }

    // Light model class with Name, IP Address, and Brightness properties
    public class Light : INotifyPropertyChanged
    {
        private string _name;
        private string _ipAddress;
        private double _brightness;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string IpAddress
        {
            get => _ipAddress;
            set
            {
                if (_ipAddress != value)
                {
                    _ipAddress = value;
                    OnPropertyChanged(nameof(IpAddress));
                }
            }
        }

        public double Brightness
        {
            get => _brightness;
            set
            {
                if (_brightness != value)
                {
                    _brightness = value;
                    OnPropertyChanged(nameof(Brightness));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
