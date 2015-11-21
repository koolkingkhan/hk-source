namespace Hussain.Infra.Utility
{
    public class Anonymous
    {
        public static T Cast<T>(object obj, T type)
        {
            return (T) obj;
        }
    }
}