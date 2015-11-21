using Hussain.Infra.Core;
using Hussain.Statusbars.ViewModels;
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

namespace Hussain.Statusbars.Views
{
    /// <summary>
    /// Interaction logic for ViewStatusbar.xaml
    /// </summary>
    public partial class ViewStatusbar : UserControl, IView
    {
        public ViewStatusbar(IViewStatusbarViewModel model)
        {
            InitializeComponent();
            ViewModel = model;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewStatusbarViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
