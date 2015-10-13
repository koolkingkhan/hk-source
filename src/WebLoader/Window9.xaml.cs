using System;
using System.Collections.Generic;
using System.Windows;
using System.Globalization;

namespace WebLoader
{
    /// <summary>
    /// Interaction logic for Window9.xaml
    /// </summary>
    public partial class Window9 : Window
    {
        private readonly List<string> _myCollection = new List<string>();

        public Window9()
        {
            InitializeComponent();
            SetUpDataCollection();
        }

        private void SetUpDataCollection()
        {
            string[] names = new string[]{"Peter", "Paul", "John", "Sam", "Claire", "Mark"};
            string[] dept = new string[] { "Sales", "Marketing", "R&D", "Development", "QA", "IT" };

            Random randSalary = new Random(2000);
            Random randNames = new Random(names.Length - 1);
            Random randDept = new Random(dept.Length-1);

            for (int i = 0; i < 10000; i++)
            {
                string data = string.Format("{0}:{1},{2}", 
                                            names[randNames.Next(names.Length-1)], 
                                            randSalary.Next(2000), 
                                            dept[randDept.Next(dept.Length-1)]);
                _myCollection.Add(data);
            }

            myListBox.DataContext = _myCollection;
        }

        private void OnUpdateClick(object sender, RoutedEventArgs e)
        {
            if (_myCollection.Count == 0)
                return;

            _myCollection.RemoveAll(x => x.Length >= 0);
        }
    }
}
