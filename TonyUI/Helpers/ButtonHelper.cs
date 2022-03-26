using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TonyUI.Helpers
{
    public class ButtonHelper
    {
        public static ButtonStyle GetButtonStyle(DependencyObject obj)
        {
            return (ButtonStyle)obj.GetValue(ButtonStyleProperty);
        }

        public static void SetButtonStyle(DependencyObject obj, ButtonStyle value)
        {
            obj.SetValue(ButtonStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for ButtonStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonStyleProperty =
            DependencyProperty.RegisterAttached("ButtonStyle", typeof(ButtonStyle), typeof(ButtonHelper), new PropertyMetadata(ButtonStyle.Default));




        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(ButtonHelper), new PropertyMetadata(null));


    }
    public enum ButtonStyle
    {
        /// <summary>
        /// Defalut button
        /// </summary>
        Default,
        /// <summary>
        /// Link button style,not show icon
        /// </summary>
        Link,
        /// <summary>
        /// Just show icon
        /// </summary>
        OnlyIcon
    }
}
