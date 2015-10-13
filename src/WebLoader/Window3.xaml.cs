using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WebLoader
{
    /// <summary>
    /// Interaction logic for MainWindow4.xaml
    /// </summary>
    public partial class MainWindow4 : Window
    {
        public MainWindow4()
        {
            InitializeComponent();
            webBrowser.Navigate("http://www.google.co.uk");
        }
    }
}
