using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
        private const string COLOR_RESOURCE_KEY = "TonyUIColors";

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

            // 创建新的颜色资源字典
            var newColorResource = new ResourceDictionary
            {
                Source = new Uri($"/TonyUI;component/Themes/Colors/{GetThemeColorFileName(themeType)}.xaml", UriKind.Relative)
            };

            // 替换现有的颜色资源字典
            ReplaceResourceDictionary(COLOR_RESOURCE_KEY, newColorResource);

            // 触发主题变更事件
            OnThemeChanged?.Invoke(this, new ThemeChangedEventArgs(oldTheme, themeType));
        }

        private string GetThemeColorFileName(ThemeType themeType)
        {
            return themeType switch
            {
                ThemeType.Zinc => "Zinc",
                ThemeType.Slate => "Slate",  // 如果有的话
                ThemeType.Stone => "Stone",  // 如果有的话
                ThemeType.Gray => "Gray",    // 如果有的话
                ThemeType.Neutral => "Neutral", // 如果有的话
                ThemeType.Red => "Red",      // 如果有的话
                ThemeType.Rose => "Rose",    // 如果有的话
                ThemeType.Orange => "Orange", // 如果有的话
                ThemeType.Green => "Green",  // 如果有的话
                ThemeType.Blue => "Blue",    // 如果有的话
                ThemeType.Yellow => "Yellow", // 如果有的话
                ThemeType.Violet => "Violet", // 如果有的话
                _ => "Zinc"
            };
        }

        private void ReplaceResourceDictionary(string key, ResourceDictionary newDict)
        {
            // 移除旧的资源字典
            var dictsToRemove = Application.Current.Resources.MergedDictionaries
                .Where(rd => rd.Contains(key) || 
                             rd.Source?.OriginalString.Contains("/Colors/") == true)
                .ToList();

            foreach (var dict in dictsToRemove)
            {
                Application.Current.Resources.MergedDictionaries.Remove(dict);
            }

            // 添加新的资源字典
            newDict[key] = true; // 标记这个字典
            Application.Current.Resources.MergedDictionaries.Add(newDict);
        }

        public event EventHandler<ThemeChangedEventArgs>? OnThemeChanged;
    }
}