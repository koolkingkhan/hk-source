namespace sre.ui.Converter
{
    public class Rules
    {
        public static Result IsNonNumericString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new Result(false, "Value Required!");
            }

            double parsedVal;
            bool status = double.TryParse(value, out parsedVal);
            return status ? new Result(false, "Please enter a value without Numerics!") : new Result(true);
        }

        public static Result IsValidNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new Result(false, "Value Required!");
            }

            double parsedVal;
            bool status = double.TryParse(value, out parsedVal);
            return !status ? new Result(false, "Numeric value required!") : new Result(true);
        }

        public static Result InRange(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new Result(false, "Value Required!");
            }

            double parsedVal;
            bool status = double.TryParse(value, out parsedVal);

            if (!status)
            {
                return new Result(false, "Numeric value required!");
            }

            int min = 0;
            int max = 1000;

            if (parsedVal < min)
            {
                return new Result(false, string.Format("Value entered must be greater than {0}!", min));
            }

            if (parsedVal > max)
            {
                return new Result(false, string.Format("Value entered must be less than {0}!", max));
            }

            return new Result(true);
        }
    }
}