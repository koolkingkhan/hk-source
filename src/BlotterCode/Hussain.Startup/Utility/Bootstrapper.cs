using System.Windows;
using Hussain.Infra.Events;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;

namespace Hussain.Startup.Utility
{
    public class Bootstrapper : UnityBootstrapper
    {
        private IEventAggregator _eventAgg;

        protected override void InitializeShell()
        {
            _eventAgg = Container.Resolve<IEventAggregator>();
            _eventAgg.GetEvent<ExitEvent>().Subscribe(args => { Application.Current.Dispatcher.InvokeShutdown(); });
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Title = "Trade Blotter v.1.0";
            Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog {ModulePath = @"./Modules"};
        }
    }
}