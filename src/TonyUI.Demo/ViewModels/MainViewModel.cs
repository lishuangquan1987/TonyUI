using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TonyUI.Managers;

namespace TonyUI.Demo.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _selectedComponent = string.Empty;

        [ObservableProperty]
        private string _selectedTheme;

        [ObservableProperty]
        private UserControl _selectedComponentContent;

        public ObservableCollection<TreeNode> NavigationTree { get; set; }
        public ObservableCollection<string> Themes { get; set; }

        public MainViewModel()
        {
            NavigationTree = new ObservableCollection<TreeNode>();
            Themes = new ObservableCollection<string> { "Zinc", "Slate", "Stone", "Gray", "Neutral", "Red", "Rose", "Orange", "Green", "Blue", "Yellow", "Violet" };
            
            InitializeNavigationTree();
            SelectedTheme = Themes[0];
            SelectedComponentContent = new Components.AllControlsComponent();
        }

        private void InitializeNavigationTree()
        {
            // 构建树形导航结构
            var basicControlsNode = new TreeNode { Name = "Basic Controls" };
            basicControlsNode.Children.Add(new TreeNode { Name = "Buttons", Category = "Buttons" });
            basicControlsNode.Children.Add(new TreeNode { Name = "TextBlocks", Category = "TextBlocks" });
            basicControlsNode.Children.Add(new TreeNode { Name = "Labels", Category = "Labels" });
            basicControlsNode.Children.Add(new TreeNode { Name = "Cards", Category = "Cards" });
            basicControlsNode.Children.Add(new TreeNode { Name = "Separators", Category = "Separators" });
            basicControlsNode.Children.Add(new TreeNode { Name = "Images", Category = "Images" });
            basicControlsNode.Children.Add(new TreeNode { Name = "Borders", Category = "Borders" });

            var inputControlsNode = new TreeNode { Name = "Input Controls" };
            inputControlsNode.Children.Add(new TreeNode { Name = "TextBoxes", Category = "TextBoxes" });
            inputControlsNode.Children.Add(new TreeNode { Name = "CheckBoxes", Category = "CheckBoxes" });
            inputControlsNode.Children.Add(new TreeNode { Name = "RadioButtons", Category = "RadioButtons" });
            inputControlsNode.Children.Add(new TreeNode { Name = "ComboBoxes", Category = "ComboBoxes" });
            inputControlsNode.Children.Add(new TreeNode { Name = "Sliders", Category = "Sliders" });
            inputControlsNode.Children.Add(new TreeNode { Name = "ProgressBar", Category = "ProgressBar" });
            inputControlsNode.Children.Add(new TreeNode { Name = "ToggleButtons", Category = "ToggleButtons" });

            var dataControlsNode = new TreeNode { Name = "Data Controls" };
            dataControlsNode.Children.Add(new TreeNode { Name = "ListBoxes", Category = "ListBoxes" });
            dataControlsNode.Children.Add(new TreeNode { Name = "ListViews", Category = "ListViews" });
            dataControlsNode.Children.Add(new TreeNode { Name = "TreeViews", Category = "TreeViews" });
            dataControlsNode.Children.Add(new TreeNode { Name = "DataGrids", Category = "DataGrids" });

            var navigationControlsNode = new TreeNode { Name = "Navigation Controls" };
            navigationControlsNode.Children.Add(new TreeNode { Name = "Menus", Category = "Menus" });
            navigationControlsNode.Children.Add(new TreeNode { Name = "Context Menus", Category = "ContextMenus" });
            navigationControlsNode.Children.Add(new TreeNode { Name = "TabControls", Category = "TabControls" });
            navigationControlsNode.Children.Add(new TreeNode { Name = "Expanders", Category = "Expanders" });

            var selectorsNode = new TreeNode { Name = "Selectors" };
            selectorsNode.Children.Add(new TreeNode { Name = "DatePickers", Category = "DatePickers" });
            selectorsNode.Children.Add(new TreeNode { Name = "Calendars", Category = "Calendars" });

            var feedbackNode = new TreeNode { Name = "Feedback Controls" };
            feedbackNode.Children.Add(new TreeNode { Name = "Dialogs", Category = "Dialogs" });
            feedbackNode.Children.Add(new TreeNode { Name = "ToolTips", Category = "ToolTips" });

            var layoutNode = new TreeNode { Name = "Layout Controls" };
            layoutNode.Children.Add(new TreeNode { Name = "GroupBoxes", Category = "GroupBoxes" });
            layoutNode.Children.Add(new TreeNode { Name = "ScrollBars", Category = "ScrollBars" });

            NavigationTree.Add(basicControlsNode);
            NavigationTree.Add(inputControlsNode);
            NavigationTree.Add(dataControlsNode);
            NavigationTree.Add(navigationControlsNode);
            NavigationTree.Add(selectorsNode);
            NavigationTree.Add(feedbackNode);
            NavigationTree.Add(layoutNode);
        }

        [RelayCommand]
        private void ChangeTheme()
        {
            if (SelectedTheme != null)
            {
                var themeType = SelectedTheme.ToLower() switch
                {
                    "zinc" => ThemeType.Zinc,
                    "slate" => ThemeType.Slate,
                    "stone" => ThemeType.Stone,
                    "gray" => ThemeType.Gray,
                    "neutral" => ThemeType.Neutral,
                    "red" => ThemeType.Red,
                    "rose" => ThemeType.Rose,
                    "orange" => ThemeType.Orange,
                    "green" => ThemeType.Green,
                    "blue" => ThemeType.Blue,
                    "yellow" => ThemeType.Yellow,
                    "violet" => ThemeType.Violet,
                    _ => ThemeType.Zinc
                };

                ThemeManager.Instance.ApplyTheme(themeType);
            }
        }

        [RelayCommand]
        private void SelectComponent(TreeNode node)
        {
            if (node != null && !node.HasChildren) // 只有葉節點才能選擇
            {
                SelectedComponent = node.Name;
                
                // 根據節點類別創建相應的控件實例
                SelectedComponentContent = node.Category switch
                {
                    "Buttons" => new Components.ButtonsComponent(),
                    "TextBlocks" => new Components.TypographyComponent(),
                    "Labels" => new Components.FormsComponent(),
                    "TextBoxes" => new Components.TextBoxesComponent(),
                    "CheckBoxes" => new Components.CheckBoxesComponent(),
                    "RadioButtons" => new Components.RadioButtonsComponent(),
                    "ComboBoxes" => new Components.ComboBoxesComponent(),
                    "ListBoxes" => new Components.ListComponent(),
                    "ListViews" => new Components.ListComponent(),
                    "TreeViews" => new Components.ListComponent(),
                    "Sliders" => new Components.SlidersComponent(),
                    "ProgressBar" => new Components.ProgressBarComponent(),
                    "Cards" => new Components.SurfacesComponent(),
                    "Separators" => new Components.SeparatorsComponent(),
                    "Dialogs" => new Components.FeedbackComponent(),
                    "DataGrids" => new Components.DataDisplayComponent(),
                    "Menus" => new Components.MenuComponent(),
                    "ContextMenus" => new Components.MenuComponent(),
                    "TabControls" => new Components.TabControlComponent(),
                    "Expanders" => new Components.SurfacesComponent(),
                    "GroupBoxes" => new Components.GroupBoxesComponent(),
                    "DatePickers" => new Components.SelectorsComponent(),
                    "Calendars" => new Components.SelectorsComponent(),
                    "ScrollBars" => new Components.ScrollBarsComponent(),
                    "ToolTips" => new Components.ToolTipsComponent(),
                    "ToggleButtons" => new Components.ToggleButtonsComponent(),
                    "Images" => new Components.ImagesComponent(),
                    "Borders" => new Components.BordersComponent(),
                    _ => new Components.AllControlsComponent()
                };
            }
        }
    }
}