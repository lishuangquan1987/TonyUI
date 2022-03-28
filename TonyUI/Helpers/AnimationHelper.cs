using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace TonyUI.Helpers
{
    internal class AnimationHelper
    {
        public static void StartColorAnimation(DependencyObject element, string propertyPath, Color? from, Color? to, double duration=0.4, EventHandler completed = null)
        {
            Storyboard storyboard = new Storyboard();
            
            ColorAnimation animation = new ColorAnimation();
            animation.From= from;
            animation.To= to;
            animation.Duration = TimeSpan.FromSeconds(duration);

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath(propertyPath));

            storyboard.Children.Add(animation);
            storyboard.Completed += (s, e) => completed?.Invoke(s, e);

            storyboard.Begin();
        }
    }
}
