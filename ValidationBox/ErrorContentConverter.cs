namespace ValidationBox
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;
    using System.Windows.Data;

    public class ErrorContentConverter : IValueConverter
    {
        public static readonly ErrorContentConverter Default = new ErrorContentConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var validationError = value as ValidationError;
            if (validationError != null)
            {
                var result = validationError.ErrorContent as ValidationResult;
                if (result != null)
                {
                    return result.ErrorContent.ToString();
                }

                return validationError.ErrorContent.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}