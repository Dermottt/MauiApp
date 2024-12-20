using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace SleepSure.Page.SensorPages
{
    public partial class vibrationPage : ContentPage
    {
        public ObservableCollection<VibrationSensor> Sensors { get; set; }

        public vibrationPage()
        {
            InitializeComponent();
            Sensors = new ObservableCollection<VibrationSensor>();
            SensorsCollectionView.ItemsSource = Sensors;
        }

        private void OnAddSensorClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SensorLocationEntry.Text) || string.IsNullOrWhiteSpace(SensorIPEntry.Text))
            {
                DisplayAlert("Input Error", "Please enter both the location and IP address for the sensor.", "OK");
                return;
            }

            var newSensor = new VibrationSensor
            {
                Location = SensorLocationEntry.Text,
                IPAddress = SensorIPEntry.Text
            };

            Sensors.Add(newSensor);

            // Clear entries after adding
            SensorLocationEntry.Text = string.Empty;
            SensorIPEntry.Text = string.Empty;
        }

        private void OnDeleteSensorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var sensor = button?.CommandParameter as VibrationSensor;
            if (sensor != null && Sensors.Contains(sensor))
            {
                Sensors.Remove(sensor);
            }
        }
    }

    public class VibrationSensor
    {
        public string Location { get; set; }
        public string IPAddress { get; set; }
    }
}
