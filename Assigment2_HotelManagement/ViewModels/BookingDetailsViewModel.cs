using Assigment2_HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2_HotelManagement.ViewModels
{
    public class BookingDetailsViewModel : BaseViewModel
    {
        public ObservableCollection<BookingDetail> BookingDetails { get; set; }

        public BookingDetailsViewModel(ObservableCollection<BookingDetail> bookingDetails)
        {
            BookingDetails = new ObservableCollection<BookingDetail>(bookingDetails);
        }
    }
}
