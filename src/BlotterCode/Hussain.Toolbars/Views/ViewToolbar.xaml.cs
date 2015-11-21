using System.Windows.Controls;
using Hussain.Infra.Core;
using Hussain.Toolbars.ViewModels;

namespace Hussain.Toolbars.Views
{
    /// <summary>
    ///     Interaction logic for ViewToolbar.xaml
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
            get { return (IViewToolbarViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}