using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TonyUI.Demo.Components;
using TonyUI.Managers;

namespace TonyUI.Demo;

public partial class MainWindow : Window
{
    private readonly Dictionary<string, UserControl> _components;
    private readonly Dictionary<string, Button> _navButtons;

    public MainWindow()
    {
        InitializeComponent();
        _components = new Dictionary<string, UserControl>();
        _navButtons = new Dictionary<string, Button>();
        InitializeComponents();
        BuildNavigation();
        SetupEventHandlers();
        SelectComponent("Buttons"); // 默认显示按钮组件
    }

    private void InitializeComponents()
    {
        // 注册所有组件UserControl
        _components.Add("Buttons", new ButtonsComponent());
        _components.Add("Inputs", new InputsComponent());
        _components.Add("Data Display", new DataDisplayComponent());
        _components.Add("Feedback", new FeedbackComponent());
        _components.Add("Navigation", new NavigationComponent());
        _components.Add("Surfaces", new SurfacesComponent());
        _components.Add("Typography", new TypographyComponent());
        _components.Add("Forms", new FormsComponent());
        _components.Add("Utilities", new UtilitiesComponent());
        _components.Add("Menu & Context", new MenuComponent());
        _components.Add("Lists", new ListComponent());
        _components.Add("Data Grid", new DataGridComponent());
        _components.Add("Tabs & Expand", new TabControlComponent());
        _components.Add("Selectors", new SelectorsComponent());
        _components.Add("Basic Controls", new BasicComponent());
        _components.Add("Input Controls", new InputComponent());
        _components.Add("Containers", new ContainerComponent());
    }

    private void BuildNavigation()
    {
        foreach (var componentName in _components.Keys)
        {
            var button = new Button
            {
                Content = componentName,
                Style = FindResource("NavButtonStyle") as Style,
                Tag = componentName,
                Margin = new Thickness(0, 0, 0, 4)
            };
            button.Click += NavButton_Click;
            _navButtons[componentName] = button;
            NavigationPanel.Children.Add(button);
        }
    }

    private void SetupEventHandlers()
    {
        // 主题切换事件处理
        if (ThemeSelector != null)
        {
            ThemeSelector.SelectionChanged += ThemeSelector_SelectionChanged;
        }
    }

    private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem)
        {
            var themeName = selectedItem.Content.ToString();
            
            var themeType = themeName switch
            {
                "Zinc" => ThemeType.Zinc,
                "Slate" => ThemeType.Slate,
                "Stone" => ThemeType.Stone,
                "Gray" => ThemeType.Gray,
                "Neutral" => ThemeType.Neutral,
                _ => ThemeType.Zinc
            };

            ThemeManager.Instance.ApplyTheme(themeType);
        }
    }

    private void NavButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string componentName)
        {
            SelectComponent(componentName);
        }
    }

    private void SelectComponent(string componentName)
    {
        // 更新导航按钮状态
        foreach (var navButton in _navButtons.Values)
        {
            navButton.Style = FindResource("NavButtonStyle") as Style;
        }

        if (_navButtons.ContainsKey(componentName))
        {
            _navButtons[componentName].Style = FindResource("ActiveNavButtonStyle") as Style;
        }

        // 更新内容
        CurrentComponentTitle.Text = componentName;
        if (_components.ContainsKey(componentName))
        {
            MainContentPresenter.Content = _components[componentName];
        }
    }
}