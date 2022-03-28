using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TonyUI.Helpers
{
    public class ButtonHelper
    {
        static ButtonHelper()
        {
            EventManager.RegisterClassHandler(typeof(Button), Button.MouseEnterEvent, new RoutedEventHandler(OnMouseEnter));
            EventManager.RegisterClassHandler(typeof(Button), Button.MouseLeaveEvent, new RoutedEventHandler(OnMouseLeave));
        }

        private static void OnMouseLeave(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            //通过Tag获取原始的背景色
            var toColor = button.Tag as SolidColorBrush;

            AnimationHelper.StartColorAnimation(button, "Background.Color", null, toColor?.Color);
        }

        private static void OnMouseEnter(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var fromColor = button.GetValue(Button.BackgroundProperty) as SolidColorBrush;
            //记录Button的开始背景色
            button.Tag =button.Tag?? fromColor;

            var toColor = button.TryFindResource("Basic.AccentColor") as SolidColorBrush;

            if (toColor != null)
            {
                AnimationHelper.StartColorAnimation(button, "Background.Color",fromColor?.Color,toColor?.Color);
            }

        }

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

        public static CornerRadius GetCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(CornerRadiusProperty, value);
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonHelper), new PropertyMetadata(new CornerRadius(0)));


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
    }
}
