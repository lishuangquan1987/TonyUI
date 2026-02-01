using System.Windows;
using System.Windows.Controls;
using TonyUI.Demo.Components;
using TonyUI.Demo.ViewModels;
using System.Windows.Input;

namespace TonyUI.Demo
{
    /// <summary>
    /// Interaction logic for NewMainWindow.xaml
    /// </summary>
    public partial class NewMainWindow : Window
    {
        public NewMainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 当主题改变时触发命令
            if (this.DataContext is MainViewModel viewModel)
            {
                viewModel.ChangeThemeCommand.Execute(null);
            }
        }

        private void NavigationTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is TreeNode node && !node.HasChildren)
            {
                if (this.DataContext is MainViewModel viewModel)
                {
                    viewModel.SelectComponentCommand.Execute(node);
                }
            }
        }
    }
}