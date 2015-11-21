using System.Windows;
using Hussain.Startup.Utility;

namespace Hussain.Startup
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var b = new Bootstrapper();
            b.Run();
        }
    }
}