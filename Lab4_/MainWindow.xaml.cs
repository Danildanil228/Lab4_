using System;
using System.Collections.Generic;
using System.Windows;

namespace AeroflotSort
{
    public partial class MainWindow : Window
    {
        private List<Aeroflot> aeroflots = new List<Aeroflot>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string destination = txtDestination.Text;
                int flightNumber = int.Parse(txtFlightNumber.Text);
                string aircraftType = txtAircraftType.Text;

                aeroflots.Add(new Aeroflot { pynkt = destination, num_r = flightNumber, type = aircraftType });
                UpdateFlightInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSortByFlightNumber_Click(object sender, RoutedEventArgs e)
        {
            aeroflots.Sort((a1, a2) => a1.num_r.CompareTo(a2.num_r));
            UpdateFlightInfo();
        }

        private void btnSortByAircraftType_Click(object sender, RoutedEventArgs e)
        {
            aeroflots.Sort(new AeroflotTypeComparer());
            UpdateFlightInfo();
        }
    private void UpdateFlightInfo()
        {
            txtFlightInfo.Text = "";
            foreach (var aeroflot in aeroflots)
            {
                txtFlightInfo.Text += $"{aeroflot.num_r} - {aeroflot.pynkt}, {aeroflot.type}\n";
            }
        }
    }
    struct Aeroflot
    {
        public string pynkt; 
        public int num_r;  
        public string type; 
    }
    class AeroflotTypeComparer : IComparer<Aeroflot>
    {
        public int Compare(Aeroflot x, Aeroflot y)
        {
            return x.type.CompareTo(y.type);
        }
    }
}
