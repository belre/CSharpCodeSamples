using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace CustomizedDataGrid001
{
  public class UserStyleBehaviorCollection : FreezableCollection<Behavior>
  {
    public static readonly DependencyProperty GeneratedCellBehaviorsProperty =
      DependencyProperty.RegisterAttached(
        "GeneratedCellBehaviors",
        typeof(UserStyleBehaviorCollection),
        typeof(UserStyleBehaviorCollection),
          new PropertyMetadata((sender, e) =>
          {
            if (e.OldValue == e.NewValue) { return; }

            var value = e.NewValue as UserStyleBehaviorCollection;
            if (value == null) { return; }

            var behaviors = Interaction.GetBehaviors(sender);
            behaviors.Clear();
            foreach (var b in value.Select(x => (Behavior)x.Clone()))
            {
              behaviors.Add(b);
            }
          }));

    public static readonly DependencyProperty GeneratedEditingCellBehaviorsProperty =
      DependencyProperty.RegisterAttached(
        "GeneratedEditingCellBehaviors",
        typeof(UserStyleBehaviorCollection),
        typeof(UserStyleBehaviorCollection),
          new PropertyMetadata((sender, e) =>
          {
            if (e.OldValue == e.NewValue) { return; }

            var value = e.NewValue as UserStyleBehaviorCollection;
            if (value == null) { return; }

            var behaviors = Interaction.GetBehaviors(sender);
            behaviors.Clear();
            foreach (var b in value.Select(x => (Behavior)x.Clone()))
            {
              behaviors.Add(b);
            }
          }));

    public static UserStyleBehaviorCollection GetGeneratedCellBehaviors(DependencyObject obj)
    {
      return (UserStyleBehaviorCollection)obj.GetValue(GeneratedCellBehaviorsProperty);
    }

    public static UserStyleBehaviorCollection GetGeneratedEditingCellBehaviors(DependencyObject obj)
    {
      return (UserStyleBehaviorCollection)obj.GetValue(GeneratedEditingCellBehaviorsProperty);
    }
    
    public static void SetGeneratedCellBehaviors(DependencyObject obj, UserStyleBehaviorCollection value)
    {
      obj.SetValue(GeneratedCellBehaviorsProperty, value);
    }

    public static void SetGeneratedEditingCellBehaviors(DependencyObject obj, UserStyleBehaviorCollection value)
    {
      obj.SetValue(GeneratedEditingCellBehaviorsProperty, value);
    }

    protected override Freezable CreateInstanceCore()
    {
      return new UserStyleBehaviorCollection();
    }

  }
}
