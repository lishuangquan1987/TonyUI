using System.Windows;
using System.Windows.Controls;

namespace TonyUI.Demo.Components;

public partial class FeedbackComponent : UserControl
{
    public FeedbackComponent()
    {
        InitializeComponent();
        SetupEventHandlers();
    }

    private void SetupEventHandlers()
    {
        showToastBtn.Click += ShowToastBtn_Click;
        showAlertDialogBtn.Click += ShowAlertDialogBtn_Click;
    }

    private void ShowToastBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("This is a toast notification!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ShowAlertDialogBtn_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("This is an alert dialog!", "Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}