using System.Windows.Controls;
using Hussain.Blotters.ViewModels;
using Hussain.Infra.Core;

namespace Hussain.Blotters.Views
{
    /// <summary>
    ///     Interaction logic for ViewBlotter.xaml
    /// </summary>
    public partial class ViewBlotter : UserControl, IView
    {
        public ViewBlotter(IViewBlotterViewModel model)
        {
            InitializeComponent();
            ViewModel = model;
            ((IView) LatestPrices).ViewModel = model;
        }

        public IViewModel ViewModel
        {
            get { return (IViewBlotterViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}