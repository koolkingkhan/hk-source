using System.Globalization;
using System.Windows.Controls;

namespace BindingValidation
{
    public class TextRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
            {
                return new ValidationResult(false,"Value required!");
            }

            return new ValidationResult(true, null);
        }
    }
}
