using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace SleepSure.Page.SensorPages
{
    public partial class windowDoorPage : ContentPage
    {
        public ObservableCollection<Sensor> Sensors { get; set; }

        public windowDoorPage()
        {
            InitializeComponent();
            Sensors = new ObservableCollection<Sensor>();
            SensorsCollectionView.ItemsSource = Sensors;
        }

        private void OnAddSensorClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SensorNameEntry.Text) || string.IsNullOrWhiteSpace(SensorIPEntry.Text) || SensorTypePicker.SelectedItem == null)
            {
                DisplayAlert("Input Error", "Please enter all fields before adding a sensor.", "OK");
                return;
            }

            var newSensor = new Sensor
            {
                Name = SensorNameEntry.Text,
                IPAddress = SensorIPEntry.Text,
                Type = SensorTypePicker.SelectedItem.ToString()
            };

            Sensors.Add(newSensor);

            // Clear entries after adding
            SensorNameEntry.Text = string.Empty;
            SensorIPEntry.Text = string.Empty;
            SensorTypePicker.SelectedItem = null;
        }

        private void OnDeleteSensorClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var sensor = button?.CommandParameter as Sensor;
            if (sensor != null && Sensors.Contains(sensor))
            {
                Sensors.Remove(sensor);
            }
        }
    }

    public class Sensor
    {
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Type { get; set; }
    }
}
