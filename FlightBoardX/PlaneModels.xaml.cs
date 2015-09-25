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
using FlightBoardX.Models;

namespace FlightBoardX
{
    /// <summary>
    /// Interaction logic for Models.xaml
    /// </summary>
    public partial class PlaneModels : Window
    {
        private System.Windows.Data.CollectionViewSource planeModelViewSource;

        public PlaneModels()
        {
            InitializeComponent();
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {

            planeModelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("planeModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            planeModelViewSource.Source = new PlaneModel().GetAll();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var planeModel = new PlaneModel() { Name = NameTextBox.Text, Cost = Convert.ToInt64(CostTextBox.Text), FuelConsumption = Convert.ToInt64(FuelTextBox.Text) }; // , Model = ModelComboBox.SelectedValue.ToString() };
            planeModel.Insert();

            planeModelViewSource.Source = planeModel.GetAll();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = ModelsDataGrid.SelectedItem;
            if (item != null)
            {
                var planeModel = (PlaneModel)item;
                if (MessageBox.Show("Delete selected model " + planeModel.Name + " ?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    planeModel.Delete();
                    planeModelViewSource.Source = planeModel.GetAll();
                }
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
