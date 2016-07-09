namespace ValidationBox
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    public class FirstErrorForElementMultiValueConverter : IMultiValueConverter
    {
        public static readonly FirstErrorForElementMultiValueConverter Default = new FirstErrorForElementMultiValueConverter();

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var errors = Validation.GetErrors((DependencyObject)values[0]);
            return FirstErrorOrDefaultConverter.Default.Convert(errors, null, null, null);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}