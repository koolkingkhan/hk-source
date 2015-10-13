using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DataTemplateSample
{
    class CustomTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null )
            {
                string filePath = item as string;
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
