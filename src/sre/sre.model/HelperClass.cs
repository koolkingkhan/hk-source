using System;
using System.Globalization;

namespace sre.model
{
    public class HelperClass
    {
        internal static bool ConvertToType<T>(string value, out T temp)
        {
            temp = default(T);
            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            try
            {
                if (typeof(T) == typeof(decimal))
                {
                    decimal retValue;
                    if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out retValue))
                    {
                        temp = (dynamic)retValue;
                    }
                }
                else
                {
                    temp = (T)Convert.ChangeType(value, typeof(T));
                }
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}