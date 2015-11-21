using System.Windows.Controls;
using Hussain.Infra.Core;
using Hussain.Statusbars.ViewModels;

namespace Hussain.Statusbars.Views
{
    /// <summary>
    ///     Interaction logic for ViewStatusbar.xaml
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
            get { return (IViewStatusbarViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}