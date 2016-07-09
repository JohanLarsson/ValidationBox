namespace ValidationBox
{
    using System.Globalization;
    using System.Windows.Controls;

    public class LessThanValidationRule : ValidationRule
    {
        public int Value { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return ValidationResult.ValidResult;
            }

            int intValue;
            var text = value as string;
            if (text != null)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return ValidationResult.ValidResult;
                }

                if (!int.TryParse(text, out intValue))
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                intValue = (int)value;
            }

            if (intValue < this.Value)
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "greater than");
        }
    }
}