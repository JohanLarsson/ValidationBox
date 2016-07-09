namespace ValidationBox
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
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

            var validationError = error as ValidationError;
            if (validationError != null)
            {
                var result = validationError.ErrorContent as ValidationResult;
                if (result != null)
                {
                    return result;
                }

                return validationError.ErrorContent;
            }

            return error;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
