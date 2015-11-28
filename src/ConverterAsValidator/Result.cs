namespace ConverterAsValidator
{
    public class Result
    {
        public Result(bool valid, string errorMessage = "")
        {
            Valid = valid;
            ErrorMessage = errorMessage;
        }

        public bool Valid { get; private set; }
        public string ErrorMessage { get; private set; }
    }
}