using Hussain.Blotters.ViewModels;
using Hussain.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hussain.Blotters.Views
{
    /// <summary>
    /// Interaction logic for ViewBlotter.xaml
    /// </summary>
    public partial class ViewBlotter : UserControl, IView
    {
        public ViewBlotter(IViewBlotterViewModel model)
        {
            InitializeComponent();
            ViewModel = model;
            ((IView)LatestPrices).ViewModel = model;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewBlotterViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
