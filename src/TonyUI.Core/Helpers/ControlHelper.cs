using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Helpers
{
    public static class ControlHelper
    {
        #region Button Properties
        
        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.RegisterAttached(
                "Variant",
                typeof(ButtonVariant),
                typeof(ControlHelper),
                new PropertyMetadata(ButtonVariant.Primary));

        public static ButtonVariant GetVariant(Button element) => (ButtonVariant)element.GetValue(VariantProperty);
        public static void SetVariant(Button element, ButtonVariant value) => element.SetValue(VariantProperty, value);

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached(
                "Size",
                typeof(ButtonSize),
                typeof(ControlHelper),
                new PropertyMetadata(ButtonSize.Default));

        public static ButtonSize GetSize(Button element) => (ButtonSize)element.GetValue(SizeProperty);
        public static void SetSize(Button element, ButtonSize value) => element.SetValue(SizeProperty, value);

        #endregion

        #region Input Properties

        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(ControlHelper),
                new PropertyMetadata(string.Empty));

        public static string GetPlaceholder(Control element) => (string)element.GetValue(PlaceholderProperty);
        public static void SetPlaceholder(Control element, string value) => element.SetValue(PlaceholderProperty, value);

        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached(
                "HasError",
                typeof(bool),
                typeof(ControlHelper),
                new PropertyMetadata(false));

        public static bool GetHasError(Control element) => (bool)element.GetValue(HasErrorProperty);
        public static void SetHasError(Control element, bool value) => element.SetValue(HasErrorProperty, value);

        #endregion

        #region Card Properties

        public static readonly DependencyProperty ElevationProperty =
            DependencyProperty.RegisterAttached(
                "Elevation",
                typeof(int),
                typeof(ControlHelper),
                new PropertyMetadata(1));

        public static int GetElevation(Border element) => (int)element.GetValue(ElevationProperty);
        public static void SetElevation(Border element, int value) => element.SetValue(ElevationProperty, value);

        #endregion
    }

    public enum ButtonVariant
    {
        Primary,
        Secondary,
        Destructive,
        Outline,
        Ghost,
        Link
    }

    public enum ButtonSize
    {
        Small,
        Default,
        Large
    }
}