namespace ValidationBox
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;
    using System.Xaml;

    [MarkupExtensionReturnType(typeof(BindingExpression))]
    public class FirstValidationErrorForExtension : MarkupExtension
    {
        private static readonly PropertyPath ErrorCountPath = new PropertyPath("(Validation.Errors).Count");

        public FirstValidationErrorForExtension()
        {
        }

        public FirstValidationErrorForExtension(string elementName)
        {
            this.ElementName = elementName;
        }

        public string ElementName { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var resolver = (IXamlNameResolver)serviceProvider.GetService(typeof(IXamlNameResolver));
            if (resolver == null)
            {
                return null;
            }

            var source = resolver.Resolve(this.ElementName);
            if (source == null)
            {
                throw new ArgumentException("Could not reolve an element named " + this.ElementName);
            }

            var binding = new Binding
            {
                Path = ErrorCountPath,
                Converter = FirsteErrorConverter.Default,
                ConverterParameter = source,
                Source = source
            };
            return binding.ProvideValue(serviceProvider);
        }

        private class FirsteErrorConverter : IValueConverter
        {
            public static readonly FirsteErrorConverter Default = new FirsteErrorConverter();

            private FirsteErrorConverter()
            {
            }

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var element = (UIElement)parameter;
                var errors = Validation.GetErrors(element);
                if ((errors?.Count ?? 0) == 0)
                {
                    return string.Empty;
                }

                var first = errors[0];
                var result = first.ErrorContent as ValidationResult;
                if (result != null)
                {
                    return result;
                }

                return first.ErrorContent;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
