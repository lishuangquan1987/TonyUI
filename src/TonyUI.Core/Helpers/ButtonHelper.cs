using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Helpers
{
    public static class ButtonHelper
    {
        #region Button Properties
        
        public static readonly DependencyProperty VariantProperty =
            DependencyProperty.RegisterAttached(
                "Variant",
                typeof(ButtonVariant),
                typeof(ButtonHelper),
                new PropertyMetadata(ButtonVariant.Primary));

        public static ButtonVariant GetVariant(Button element) => (ButtonVariant)element.GetValue(VariantProperty);
        public static void SetVariant(Button element, ButtonVariant value) => element.SetValue(VariantProperty, value);

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.RegisterAttached(
                "Size",
                typeof(ButtonSize),
                typeof(ButtonHelper),
                new PropertyMetadata(ButtonSize.Default));

        public static ButtonSize GetSize(Button element) => (ButtonSize)element.GetValue(SizeProperty);
        public static void SetSize(Button element, ButtonSize value) => element.SetValue(SizeProperty, value);

        #endregion
    }
}