using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace TonyUI.Demo.Components;

public partial class ButtonsComponent : UserControl
{
    public ButtonsComponent()
    {
        InitializeComponent();
        SetupLoadingButton();
    }

    private void SetupLoadingButton()
    {
        // 创建带加载动画的按钮内容
        var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
        
        var ellipse = new System.Windows.Shapes.Ellipse
        {
            Width = 12,
            Height = 12,
            Fill = (System.Windows.Media.Brush)FindResource("PrimaryForegroundBrush"),
            Margin = new Thickness(0, 0, 8, 0)
        };

        // 添加动画到椭圆
        var scaleTransform = new System.Windows.Media.ScaleTransform();
        ellipse.RenderTransform = scaleTransform;

        var scaleXAnim = new DoubleAnimation
        {
            From = 0.5,
            To = 1.5,
            Duration = TimeSpan.FromSeconds(0.6),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever
        };

        var scaleYAnim = new DoubleAnimation
        {
            From = 0.5,
            To = 1.5,
            Duration = TimeSpan.FromSeconds(0.6),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever
        };

        // 为缩放变换应用动画
        scaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, scaleXAnim);
        scaleTransform.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, scaleYAnim);

        var textBlock = new TextBlock
        {
            Text = "Loading...",
            VerticalAlignment = VerticalAlignment.Center
        };

        stackPanel.Children.Add(ellipse);
        stackPanel.Children.Add(textBlock);

        loadingButton.Content = stackPanel;
        loadingButton.Style = (Style)FindResource("PrimaryButtonStyle");
    }
}