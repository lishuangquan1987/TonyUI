using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Demo.Components
{
    /// &lt;summary&gt;
    /// Interaction logic for InputComponent.xaml
    /// &lt;/summary&gt;
    public partial class InputComponent : UserControl
    {
        public InputComponent()
        {
            InitializeComponent();
        }

        private void ShowDialogBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a sample dialog message!", "Sample Dialog", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}