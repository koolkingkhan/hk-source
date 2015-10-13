using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using sre.ui.Model;

namespace sre.ui.Converter
{
    public class ConfigToDynamicGridViewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var config = value as ColumnConfig;
            if (config != null)
            {
                var grdiView = new GridView();
                foreach (var column in config.Columns)
                {
                    var binding = new Binding(column.DataField);
                    var gridViewColumn = 
                        column.CanEdit ?
                        new GridViewColumn { Header = column.Header, Width = 200, CellTemplate = GetDataTemplate(column.DataField) } :
                        new GridViewColumn { Header = column.Header, DisplayMemberBinding = binding };

                    grdiView.Columns.Add(gridViewColumn);
                }
                return grdiView;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        private static DataTemplate GetDataTemplate(string dataField)
        {
            DataTemplate template = new DataTemplate();
            FrameworkElementFactory factory = new FrameworkElementFactory(typeof(TextBox));
            factory.SetValue(TextBox.TextAlignmentProperty, TextAlignment.Right);
            factory.SetBinding(TextBox.TextProperty, new Binding(dataField));
            template.VisualTree = factory;

            return template;
        }
    }
}
