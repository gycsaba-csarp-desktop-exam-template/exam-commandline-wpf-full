using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace KretaDesktop.Converter
{
    public class BoolToSortIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is bool)
                {
                    bool isAscending = (bool)value;
                    if (isAscending)
                        return "/Resources/icons/sort-alpha-down.png";
                    else
                        return "/Resources/icons/sort-alpha-up-alt.png";
                }
            }
            return "/Resources/icons/sort-alpha-down.png";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
