using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using FlightBoardX.Enum;
using FlightBoardX.Models;

namespace FlightBoardX
{
    /// <summary>
    /// Interaction logic for MyPlanes.xaml
    /// </summary>
    public partial class MyPlanes : Window
    {
        private System.Windows.Data.CollectionViewSource planeViewSource;

        public MyPlanes()
        {
            InitializeComponent();
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {

            planeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            planeViewSource.Source = new Plane().GetAll();

            CountryComboBox.ItemsSource = System.Enum.GetValues(typeof(Countries)).Cast<Countries>();
            ModelComboBox.ItemsSource = new PlaneModel().GetAll();
            ModelComboBox.DisplayMemberPath = "Name";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PlaneModel selPlaneModel = (PlaneModel)ModelComboBox.SelectedValue;
            var myPlane = new Plane() { Companny = CompannyTextBox.Text, Country = CountryComboBox.SelectedValue.ToString(), Model = selPlaneModel}; // , Model = ModelComboBox.SelectedValue.ToString() };
            myPlane.Insert();

            planeViewSource.Source = myPlane.GetAll();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = MyPlanessDataGrid.SelectedItem;
            if (item != null)
            {
                var plane = (Plane)item;
                if (MessageBox.Show("Delete selected plane " + plane.Companny + " ?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    plane.Delete();
                    planeViewSource.Source = plane.GetAll();
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ModelsButton_Click(object sender, RoutedEventArgs e)
        {
            new PlaneModels().ShowDialog();
            ModelComboBox.ItemsSource = new PlaneModel().GetAll();
            ModelComboBox.DisplayMemberPath = "Name";
        }
    }
}
