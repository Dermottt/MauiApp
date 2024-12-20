using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace SleepSure.Page.SensorPages
{
    public partial class waterPage : ContentPage
    {
        public ObservableCollection<WaterSensor> Sensors { get; set; }

        public waterPage()
        {
            InitializeComponent();
            Sensors = new ObservableCollection<WaterSensor>();
            SensorsCollectionView.ItemsSource = Sensors;
        }

        private void OnAddSensorClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SensorLocationEntry.Text) || string.IsNullOrWhiteSpace(SensorIPEntry.Text))
            {
                DisplayAlert("Input Error", "Please enter both the location and IP address for the sensor.", "OK");
                return;
            }

            var newSensor = new WaterSensor
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
            var sensor = button?.CommandParameter as WaterSensor;
            if (sensor != null && Sensors.Contains(sensor))
            {
                Sensors.Remove(sensor);
            }
        }
    }

    public class WaterSensor
    {
        public string Location { get; set; }
        public string IPAddress { get; set; }
    }
}
