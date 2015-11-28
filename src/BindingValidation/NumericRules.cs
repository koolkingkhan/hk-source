using System.Globalization;
using System.Windows.Controls;

namespace BindingValidation
{
    public class NumericRules : ValidationRule
    {
        public int? Min { get; set; }
        public int? Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false, "Value required!");
            }

            double parsedVal;
            if (!double.TryParse(str, out parsedVal))
            {
                return new ValidationResult(false, "Numeric value required!");
            }

            if (Min.HasValue && parsedVal < Min.Value)
            {
                return new ValidationResult(false, string.Format("Value entered must be greater than {0}!", Min.Value));
            }

            if (Max.HasValue && parsedVal > Max.Value)
            {
                return new ValidationResult(false, string.Format("Value entered must be less than {0}!", Max.Value));
            }

            return new ValidationResult(true, null);
        }
    }
}