using Assigment2_HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assigment2_HotelManagement.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        private Customer customer;
        public Customer Customer
        {
            get => customer;
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<BookingReservation> bookingReservations;
        public ObservableCollection<BookingReservation> BookingReservations
        {
            get => bookingReservations;
            set
            {
                bookingReservations = value;
                OnPropertyChanged();
            }
        }

        public HistoryViewModel()
        {
         
            Customer = Application.Current.Properties["LoggedInCustomer"] as Customer;
            LoadCustomerBookings();
        }

        private void LoadCustomerBookings()
        {
            using (var context = new FuminiHotelManagementContext())
            {

                var bookings = context.BookingReservations
                                      .Where(b => b.CustomerId == Customer.CustomerId)
                                      .ToList();

                BookingReservations = new ObservableCollection<BookingReservation>(bookings);
            }
        }
    }
}
