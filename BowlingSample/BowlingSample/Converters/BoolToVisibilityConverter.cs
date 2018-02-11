using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace BowlingSample.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; }

        public Visibility FalseValue { get; set; }

        public BoolToVisibilityConverter()
        {
            // set defaults
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;
            return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            if (Equals(value, TrueValue))
                return true;
            if (Equals(value, FalseValue))
                return false;
            return null;
        }
    }

    //[ValueConversion(typeof(bool), typeof(bool))]
    //public sealed class BoolToBoolConverter : IValueConverter
    //{
    //    public bool TrueValue { get; set; }

    //    public bool FalseValue { get; set; }

    //    public BoolToBoolConverter()
    //    {
    //        // set defaults
    //        TrueValue = true;
    //        FalseValue = false;
    //    }

    //    public object Convert(object value, Type targetType,
    //        object parameter, CultureInfo culture)
    //    {
    //        if (!(value is bool))
    //            return null;
    //        return (bool)value ? TrueValue : FalseValue;
    //    }

    //    public object ConvertBack(object value, Type targetType,
    //        object parameter, CultureInfo culture)
    //    {
    //        if (Equals(value, TrueValue))
    //            return true;
    //        if (Equals(value, FalseValue))
    //            return false;
    //        return null;
    //    }
    //}
}

