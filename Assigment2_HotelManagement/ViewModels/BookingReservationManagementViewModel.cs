using Assigment2_HotelManagement.AdminView;
using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    public class BookingReservationManagementViewModel : BaseViewModel
    {


        public ObservableCollection<BookingReservation> Reservations { get; set; }
        public ICommand ViewDetailsCommand { get; set; }

        public BookingReservationManagementViewModel()
        {
            LoadReservations();
            ViewDetailsCommand = new RelayCommand(OpenBookingDetails);
        }

        private void LoadReservations()
        {
            using (var context = new FuminiHotelManagementContext())
            {
                var reservationsList = context.BookingReservations
                    .Include(r => r.Customer)
                    .ToList();
                Reservations = new ObservableCollection<BookingReservation>(reservationsList);
            }
        }

        private void OpenBookingDetails(object bookingReservationId)
        {
            if (bookingReservationId is int reservationId)
            {
                using (var context = new FuminiHotelManagementContext())
                {

                    var bookingDetailsList = context.BookingDetails
                        .Where(bd => bd.BookingReservationId == reservationId)
                        .ToList();


                    ObservableCollection<BookingDetail> bookingDetails = new ObservableCollection<BookingDetail>(bookingDetailsList);


                    BookingDetailsWindow detailsWindow = new BookingDetailsWindow
                    {
                        DataContext = new BookingDetailsViewModel(bookingDetails)
                    };
                    detailsWindow.ShowDialog();
                }
            }
        }

    }

}
