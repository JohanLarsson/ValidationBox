namespace ValidationBox
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;

    public class FirstErrorOrDefaultConverter : IValueConverter
    {
        public static readonly FirstErrorOrDefaultConverter Default = new FirstErrorOrDefaultConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumerable = value as IEnumerable;
            var error = enumerable?.Cast<object>().FirstOrDefault();
            if (error == null)
            {
                return "";
            }

            return ErrorContentConverter.Default.Convert(error, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
