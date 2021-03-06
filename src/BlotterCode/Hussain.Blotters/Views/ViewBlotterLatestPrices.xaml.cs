﻿using System.Windows.Controls;
using Hussain.Blotters.ViewModels;
using Hussain.Infra.Core;

namespace Hussain.Blotters.Views
{
    /// <summary>
    ///     Interaction logic for ViewBlotterLatestPrices.xaml
    /// </summary>
    public partial class ViewBlotterLatestPrices : UserControl, IView
    {
        public ViewBlotterLatestPrices()

        {
            InitializeComponent();
        }


        public IViewModel ViewModel
        {
            get { return (IViewBlotterViewModel) DataContext; }
            set { DataContext = (IViewBlotterViewModel) value; }
        }
    }
}