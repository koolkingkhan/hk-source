using Prism.Commands;

namespace Hussain.Infra.Utility
{
    public class GlobalCommands
    {
        public static CompositeCommand GlobalExitCommand = new CompositeCommand();
        public static CompositeCommand GlobalViewCommand = new CompositeCommand();
    }
}