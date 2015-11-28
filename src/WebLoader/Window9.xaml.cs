using System;
using System.Collections.Generic;
using System.Windows;

namespace WebLoader
{
    /// <summary>
    ///     Interaction logic for Window9.xaml
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
            string[] names = {"Peter", "Paul", "John", "Sam", "Claire", "Mark"};
            string[] dept = {"Sales", "Marketing", "R&D", "Development", "QA", "IT"};

            var randSalary = new Random(2000);
            var randNames = new Random(names.Length - 1);
            var randDept = new Random(dept.Length - 1);

            for (var i = 0; i < 10000; i++)
            {
                var data = string.Format("{0}:{1},{2}",
                    names[randNames.Next(names.Length - 1)],
                    randSalary.Next(2000),
                    dept[randDept.Next(dept.Length - 1)]);
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