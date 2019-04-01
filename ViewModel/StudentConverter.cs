using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Model;

namespace ViewModel
{
    public class StudentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            StudentModel student = new StudentModel();
            student.Identity = int.Parse(values[0].ToString());
            student.FullName = values[1].ToString();
            student.BirthDate = values[2].ToString();
            return student;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
