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

namespace Assigment2_HotelManagement.AdminView
{
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new CustomerManagement();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new RoomManagement();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new BookingReservationManagement();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Properties["LoggedInCustomer"] = null;
                WindowLogin windowLogin = new WindowLogin();
                windowLogin.Show();
                this.Close();
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            frAdmin.Content = new Report();
        }
    }
}
