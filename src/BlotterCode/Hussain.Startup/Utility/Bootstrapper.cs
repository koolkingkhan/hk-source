using Microsoft.Practices.Unity;
using System.Windows;
using Hussain.Infra.Events;
using Prism.Events;
using Prism.Modularity;
using Prism.Unity;


namespace Hussain.Startup.Utility
{
    public class Bootstrapper:UnityBootstrapper
    {
        private IEventAggregator _eventAgg;
        protected override void InitializeShell()
        {
            
            _eventAgg=Container.Resolve<IEventAggregator>();
            _eventAgg.GetEvent<ExitEvent>().Subscribe(args => {
                App.Current.Dispatcher.InvokeShutdown();
            });
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Title = "Trade Blotter v.1.0";
            App.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            App.Current.MainWindow.WindowState = WindowState.Maximized;
            App.Current.MainWindow.Show();
            
        }
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = @"./Modules" };
        }
    }
}
