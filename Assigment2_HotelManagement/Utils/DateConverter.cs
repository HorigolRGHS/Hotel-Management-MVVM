using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2_HotelManagement.Utils
{
    class DateConverter
    {
        public static DateTime? ToDateTime(DateOnly? date)
        {
            return date.HasValue ? date.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null;
        }

        public static DateOnly? ToDateOnly(DateTime? dateTime)
        {
            return dateTime.HasValue ? DateOnly.FromDateTime(dateTime.Value) : (DateOnly?)null;
        }
    }
}
