using System.Windows;
using System.Windows.Controls;
using Hussain.Infra.Model;

namespace Hussain.Blotters.TemplateSelectors
{
    public class PriceColourSelector : DataTemplateSelector
    {
        public DataTemplate BelowTemplate { get; set; }
        public DataTemplate AboveTemplate { get; set; }
        public DataTemplate SameTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            dynamic data;
            DataTemplate rv = null;
            if (item is IBlotterData)
            {
                data = item as IBlotterData;
            }
            else
            {
                data = item as IBlotterDataLatestPrices;
            }
            var element = container as FrameworkElement;

            if (element != null && data != null)
            {
                if (data.TickerPrice == data.TickerPreviousPrice)
                {
                    return element.FindResource("SameTemplate") as DataTemplate;
                }
                if (data.TickerPrice > data.TickerPreviousPrice)
                {
                    return element.FindResource("AboveTemplate") as DataTemplate;
                }
                if (data.TickerPrice < data.TickerPreviousPrice)
                {
                    return element.FindResource("BelowTemplate") as DataTemplate;
                }
            }
            return null;

            // If we set templates in XAML
            /*

           if ( data != null)
           {

               if (data.TickerPrice == data.TickerPreviousPrice)
               {
                   return SameTemplate;
               }
               if (data.TickerPrice > data.TickerPreviousPrice)
               {                   
                   return AboveTemplate;
               }
               if (data.TickerPrice < data.TickerPreviousPrice)
               {
                
                return BelowTemplate;
               }
           }
            */
            return null;
        }
    }
}