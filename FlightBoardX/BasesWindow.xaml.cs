using FlightBoardX.Database;
using FlightBoardX.Models;
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

namespace FlightBoardX
{
    /// <summary>
    /// Interaction logic for BasesWindow.xaml
    /// </summary>
    public partial class BasesWindow : Window
    {
        private System.Windows.Data.CollectionViewSource boardJobViewSource;

        public BasesWindow()
        {
            InitializeComponent();
        }

        private void load_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                boardJobViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("baseViewSource")));
                boardJobViewSource.Source = new Base().GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myBase = new Base() { ICAO = IcaoTextBox.Text };
                myBase.Insert();

                boardJobViewSource.Source = myBase.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = BasesDataGrid.SelectedItem;
                if (item != null)
                {
                    var myBase = (Base)item;
                    if (MessageBox.Show("Delete selected base " + myBase.ICAO + " ?", "Delete?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        myBase.Delete();
                        boardJobViewSource.Source = myBase.GetAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
