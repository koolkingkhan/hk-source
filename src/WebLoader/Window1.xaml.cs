using System.Windows;

namespace WebLoader
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();

            webBrowser.Navigate("http://www.google.co.uk");
        }
    }
}