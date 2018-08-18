using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Shiritore.GameSystem;

namespace Shiritore.UI.Converter
{
    public class ProblemsToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is IEnumerable<Problem>)) throw new ArgumentException("value must be IEnumerable<Problem>.");
            var cval = (IEnumerable<Problem>) value;
            var retstr = "";
            cval.ToList().ForEach(i => retstr += i.ProblemText.Value);
            return retstr;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}