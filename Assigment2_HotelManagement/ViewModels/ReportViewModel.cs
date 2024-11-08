using Assigment2_HotelManagement.Models;
using Assigment2_HotelManagement.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assigment2_HotelManagement.ViewModels
{
    class ReportViewModel : BaseViewModel
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private ObservableCollection<BookingReservation> _filteredReports;

        public DateTime StartDate
        {
            get => _startDate;
            set { _startDate = value; OnPropertyChanged(nameof(StartDate)); }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set { _endDate = value; OnPropertyChanged(nameof(EndDate)); }
        }

        public ObservableCollection<BookingReservation> FilteredReports
        {
            get => _filteredReports;
            set { _filteredReports = value; OnPropertyChanged(nameof(FilteredReports)); }
        }

        public ICommand GenerateReportCommand { get; }

        public ReportViewModel()
        {
            FilteredReports = new ObservableCollection<BookingReservation>();
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
            GenerateReportCommand = new RelayCommand(LoadReports);
        }

        private void LoadReports(object param)
        {
            using var context = new FuminiHotelManagementContext();

            var start = DateOnly.FromDateTime(StartDate);
            var end = DateOnly.FromDateTime(EndDate);

            var reports = context.BookingReservations
               .Include(b => b.Customer)
           .Where(b => b.BookingDetails.Any(d =>
             d.StartDate >= start && d.EndDate <= end))
              .OrderByDescending(b => b.BookingDate)
              .ToList();

            FilteredReports.Clear();
            foreach (var report in reports)
            {
                FilteredReports.Add(report);
            }
        }
    }
}
