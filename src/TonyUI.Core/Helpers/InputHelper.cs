using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Helpers
{
    public static class InputHelper
    {
        #region Input Properties

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(InputHelper),
                new PropertyMetadata(string.Empty));

        public static string GetPlaceholder(Control element) => (string)element.GetValue(PlaceholderProperty);
        public static void SetPlaceholder(Control element, string value) => element.SetValue(PlaceholderProperty, value);

        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached(
                "HasError",
                typeof(bool),
                typeof(InputHelper),
                new PropertyMetadata(false));

        public static bool GetHasError(Control element) => (bool)element.GetValue(HasErrorProperty);
        public static void SetHasError(Control element, bool value) => element.SetValue(HasErrorProperty, value);

        #endregion
    }
}