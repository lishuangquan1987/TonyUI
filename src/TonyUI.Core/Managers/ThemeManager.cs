using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace TonyUI.Managers
{
    public enum ThemeType
    {
        Zinc,
        Slate,
        Stone,
        Gray,
        Neutral,
        Red,
        Rose,
        Orange,
        Green,
        Blue,
        Yellow,
        Violet
    }

    public class ThemeChangedEventArgs : EventArgs
    {
        public ThemeType OldTheme { get; }
        public ThemeType NewTheme { get; }

        public ThemeChangedEventArgs(ThemeType oldTheme, ThemeType newTheme)
        {
            OldTheme = oldTheme;
            NewTheme = newTheme;
        }
    }

    public sealed class ThemeManager
    {
        private static readonly Lazy<ThemeManager> _instance = new(() => new ThemeManager());
        public static ThemeManager Instance => _instance.Value;

        private ThemeType _currentTheme = ThemeType.Zinc;

        private ThemeManager() { }

        public ThemeType CurrentTheme => _currentTheme;

        public void Initialize()
        {
            // 应用默认主题
            ApplyTheme(ThemeType.Zinc);
        }

        public void ApplyTheme(ThemeType themeType)
        {
            if (_currentTheme == themeType) return;

            var oldTheme = _currentTheme;
            _currentTheme = themeType;

            // Create a URI for the theme color resource dictionary
            var themeUri = new Uri($"pack://application:,,,/TonyUI;component/Themes/Colors/{GetThemeColorFileName(themeType)}.xaml");

            // Find and replace the theme color resource dictionary
            var existingDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source?.ToString().Contains("/Colors/") == true); // Identify by path containing /Colors/

            int insertIndex = 0;
            if (existingDict != null)
            {
                var index = Application.Current.Resources.MergedDictionaries.IndexOf(existingDict);
                Application.Current.Resources.MergedDictionaries.RemoveAt(index);
                insertIndex = index;
            }

            // Load the theme color dictionary that includes only color definitions
            var newDict = new ResourceDictionary { Source = themeUri };
            Application.Current.Resources.MergedDictionaries.Insert(insertIndex, newDict);

            // Trigger theme change event
            OnThemeChanged?.Invoke(this, new ThemeChangedEventArgs(oldTheme, themeType));
        }

        private string GetThemeColorFileName(ThemeType themeType)
        {
            return themeType switch
            {
                ThemeType.Zinc => "ZincTheme",
                ThemeType.Slate => "SlateTheme",
                ThemeType.Stone => "StoneTheme",  
                ThemeType.Gray => "GrayTheme",    
                ThemeType.Neutral => "NeutralTheme", 
                ThemeType.Red => "RedTheme",      
                ThemeType.Rose => "RoseTheme",    
                ThemeType.Orange => "OrangeTheme", 
                ThemeType.Green => "GreenTheme",  
                ThemeType.Blue => "BlueTheme",    
                ThemeType.Yellow => "YellowTheme", 
                ThemeType.Violet => "VioletTheme", 
                _ => "ZincTheme"
            };
        }

        public event EventHandler<ThemeChangedEventArgs>? OnThemeChanged;
    }
}