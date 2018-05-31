using System;
using System.Windows;
using System.Windows.Controls;

namespace MenuTreeComponent
{
    public class ResolverPresenter : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            try {
                //получаем вызывающий контейнер
                FrameworkElement element = container as FrameworkElement;

                if (item is TextResolver)
                {
                    return element.FindResource("TextResolverTemplate") as DataTemplate;
                }
                else if (item is ImageResolver)
                {
                    return element.FindResource("ImageResolverTemplate") as DataTemplate;
                }
                return null;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"SelectTemplate exception: {ex}");
                return null;
            }
        }
    }
}
