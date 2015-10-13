namespace sre.ui.Converter
{
    public class Result
    {
        public bool Valid { get; private set; }
        public string ErrorMessage { get; private set; }

        public Result(bool valid, string errorMessage = "")
        {
            Valid = valid;
            ErrorMessage = errorMessage;
        }
    }
}