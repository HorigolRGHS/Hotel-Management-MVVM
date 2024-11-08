using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assigment2_HotelManagement.AdminView
{
    /// <summary>
    /// Interaction logic for RoomManagement.xaml
    /// </summary>
    public partial class RoomManagement : Page
    {
        public RoomManagement()
        {
            this.Resources.Add("ByteToBooleanConverter", new ByteToBooleanConverter());
            InitializeComponent();
          
        }

        public class ByteToBooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is byte byteValue)
                {
                    return byteValue != 0; // Chuyển đổi byte thành bool
                }
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? (byte)1 : (byte)0; // Chuyển đổi bool về byte
            }
        }



    }
}
