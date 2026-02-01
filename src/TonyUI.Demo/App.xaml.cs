using System.Configuration;
using System.Data;
using System.Windows;

namespace TonyUI.Demo;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Initialize the theme manager to apply the default theme
        Managers.ThemeManager.Instance.Initialize();
    }
}

