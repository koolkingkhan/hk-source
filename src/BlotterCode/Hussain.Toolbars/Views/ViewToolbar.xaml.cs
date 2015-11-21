using Hussain.Infra.Core;
using Hussain.Toolbars.ViewModels;
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

namespace Hussain.Toolbars.Views
{
    /// <summary>
    /// Interaction logic for ViewToolbar.xaml
    /// </summary>
    public partial class ViewToolbar : UserControl, IView
    {
        public ViewToolbar(IViewToolbarViewModel model)
        {
            InitializeComponent();
            ViewModel = model;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewToolbarViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
