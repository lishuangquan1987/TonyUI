using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TonyUI.Demo.ViewModels
{
    public partial class TreeNode : ObservableObject
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;  // 对应的组件类别
        public ObservableCollection<TreeNode> Children { get; set; } = new ObservableCollection<TreeNode>();
        public bool HasChildren => Children.Count > 0;
    }
}