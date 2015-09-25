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
    /// Interaction logic for JobRuning.xaml
    /// </summary>
    public partial class JobRuning : Window
    {
        private DateTime _start;
        
        private BoardJob _job;

        public JobRuning(BoardJob job)
        {
            InitializeComponent();
            _job = job;
        }

        private void FinnishButton_Click(object sender, RoutedEventArgs e)
        {
            var diff = DateTime.Now.Subtract(_start);

            var time = diff.ToString(@"hh\hmm\mss\s");

            var result = MessageBox.Show(this, "This flight really ended with " + time + "?", "Flight finnish", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                DialogResult = true;
        }

        private void JobRuning_OnLoaded(object sender, RoutedEventArgs e)
        {
            _start = DateTime.Now;
            StartLabel.Content = "The flight from " + _job.Departure + " to " + _job.Arrival + " was started at: " + _start.ToString(@"HH\:mm");

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var diff = DateTime.Now.Subtract(_start);

            var time = diff.ToString(@"hh\:mm\:ss");

            TimeLabel.Content = time;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
