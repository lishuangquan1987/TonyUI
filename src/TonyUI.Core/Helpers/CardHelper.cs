using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Helpers
{
    public static class CardHelper
    {
        #region Card Properties

        public static readonly DependencyProperty ElevationProperty =
            DependencyProperty.RegisterAttached(
                "Elevation",
                typeof(int),
                typeof(CardHelper),
                new PropertyMetadata(1));

        public static int GetElevation(Border element) => (int)element.GetValue(ElevationProperty);
        public static void SetElevation(Border element, int value) => element.SetValue(ElevationProperty, value);

        #endregion
    }
}