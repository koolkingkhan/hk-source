using System.Windows;

namespace WebLoader
{
    /// <summary>
    ///     Interaction logic for MainWindow4.xaml
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