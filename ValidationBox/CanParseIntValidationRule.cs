namespace ValidationBox
{
    using System.Globalization;
    using System.Windows.Controls;

    public class CanParseIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var text = value as string;
            if (string.IsNullOrEmpty(text))
            {
                return new ValidationResult(false, "can't parse");
            }

            int temp;
            if (int.TryParse(text, out temp))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "can't parse");
        }
    }
}
