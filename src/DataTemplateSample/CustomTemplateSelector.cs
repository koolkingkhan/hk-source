using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DataTemplateSample
{
    internal class CustomTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;

            if (element != null)
            {
                var filePath = item as string;
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    return element.FindResource("imageTemplate") as DataTemplate;
                }

                return element.FindResource("stringTemplate") as DataTemplate;
            }

            return null;
        }
    }
}