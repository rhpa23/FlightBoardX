using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightBoardX.Database;
using FlightBoardX.Models;
using FlightBoardX.Util;

namespace FlightBoardX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Data.CollectionViewSource boardJobViewSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                boardJobViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("boardJobViewSource")));
                // Load data by setting the CollectionViewSource.Source property:
                // boardJobViewSource.Source = [generic data source]

                var currentSituation = new Situation().Get();
                Base currentBase = AirportDatabaseFile.FindAirportInfo(currentSituation.CurrentLocation);


                MoneyLabel.Content = "Your companny cash is: " + currentSituation.CompanyCash.ToString("C", CultureInfo.GetCultureInfo("en-US"));
                CurrentLocationLabel.Content = "You are in: " + currentBase.AirportName + " (" + currentBase.ICAO + ") - " + currentBase.Country;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private IList<BoardJob> GenerateBoardJobs(string departure)
        {
            IList<BoardJob> listBoardJobs = new List<BoardJob>();
            
            try
            {
                var dep = AirportDatabaseFile.FindAirportInfo(departure);

                var depCoord = new GeoCoordinate(dep.Latitude, dep.Longitude);
                var randomPob = new Random();
                var randomCargo = new Random();

                var plane = new Plane() { Country = dep.Country };
                var planes = plane.GetPlanesByCountry();

                foreach (var arrival in new Base().GetAll())
                {
                    var arrCoord = new GeoCoordinate(arrival.Latitude, arrival.Longitude);
                    var distMeters = depCoord.GetDistanceTo(arrCoord);
                    var distMiles = (int)DataConversion.ConvertMetersToMiles(distMeters);
                    int pob = randomPob.Next(95, 135);  // TODO:
                    int cargo = randomCargo.Next(500, 3500); // TODO:

                    long profit = (pob + cargo) * distMiles;

                    string planeName = "A320";
                    if (planes.Count > 0)
                    {
                        planeName = planes.First().ModelName + " " + planes.First().Companny;
                    }

                    listBoardJobs.Add(new BoardJob()
                    {
                        Plane = planeName,
                        Departure = departure,
                        Arrival = arrival.ICAO,
                        Dist = distMiles,
                        Eobt = 127, // TODO:
                        Pob = pob,
                        Cargo = cargo,
                        Profit = profit
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return listBoardJobs;
        }

        private void BasesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new BasesWindow().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void PlanesButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                new MyPlanes().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new PlaneModels().ShowDialog();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReGenJobsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentSituation = new Situation().Get();
                if (currentSituation == null || string.IsNullOrEmpty(currentSituation.CurrentLocation))
                {
                    var dialog = new MyDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        var newSituation = new Situation() { CurrentLocation = dialog.ResponseText };
                        newSituation.Insert();
                        Base currentBase = AirportDatabaseFile.FindAirportInfo(newSituation.CurrentLocation);
                        CurrentLocationLabel.Content = "You are in: " + currentBase.AirportName + " (" + currentBase.ICAO + ") - " + currentBase.Country;
                    }
                }
                else
                {
                    boardJobViewSource.Source = GenerateBoardJobs(currentSituation.CurrentLocation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RunJoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var job = (BoardJob)boardJobDataGrid.SelectedItem;

                if (new JobRuning(job).ShowDialog() == true)
                {
                    var currentSituation = new Situation().Get();
                    currentSituation.CurrentLocation = job.Arrival;
                    currentSituation.CompanyCash += job.Profit;
                    currentSituation.Update();
                    boardJobViewSource.Source = GenerateBoardJobs(currentSituation.CurrentLocation);

                    var currentBase = AirportDatabaseFile.FindAirportInfo(currentSituation.CurrentLocation);
                    MoneyLabel.Content = "Your companny cash is: " + currentSituation.CompanyCash.ToString("C", CultureInfo.GetCultureInfo("en-US"));
                    CurrentLocationLabel.Content = "You are in: " + currentBase.AirportName + " (" + currentBase.ICAO + ") - " + currentBase.Country;

                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChangeLocationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new MyDialog();
                if (dialog.ShowDialog() == true)
                {
                    var currentSituation = new Situation().Get();
                    currentSituation.CurrentLocation = dialog.ResponseText;
                    currentSituation.Update();
                    boardJobViewSource.Source = GenerateBoardJobs(currentSituation.CurrentLocation);
                    var currentBase = AirportDatabaseFile.FindAirportInfo(currentSituation.CurrentLocation);
                    CurrentLocationLabel.Content = "You are in: " + currentBase.AirportName + " (" + currentBase.ICAO + ") - " + currentBase.Country;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

    }
}
