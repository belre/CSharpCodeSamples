using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace CustomizedDataGrid001
{
  public class BehaviorInteractionCollection : FreezableCollection<Behavior>
  {
    public static readonly DependencyProperty GeneratedCellBehaviorsProperty =
      DependencyProperty.RegisterAttached(
        "GeneratedCellBehaviors",
        typeof(BehaviorInteractionCollection),
        typeof(BehaviorInteractionCollection),
          new PropertyMetadata((sender, e) =>
          {
            if (e.OldValue == e.NewValue) { return; }

            var value = e.NewValue as BehaviorInteractionCollection;
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
        typeof(BehaviorInteractionCollection),
        typeof(BehaviorInteractionCollection),
          new PropertyMetadata((sender, e) =>
          {
            if (e.OldValue == e.NewValue) { return; }

            var value = e.NewValue as BehaviorInteractionCollection;
            if (value == null) { return; }

            var behaviors = Interaction.GetBehaviors(sender);
            behaviors.Clear();
            foreach (var b in value.Select(x => (Behavior)x.Clone()))
            {
              behaviors.Add(b);
            }
          }));

    public static BehaviorInteractionCollection GetGeneratedCellBehaviors(DependencyObject obj)
    {
      return (BehaviorInteractionCollection)obj.GetValue(GeneratedCellBehaviorsProperty);
    }

    public static BehaviorInteractionCollection GetGeneratedEditingCellBehaviors(DependencyObject obj)
    {
      return (BehaviorInteractionCollection)obj.GetValue(GeneratedEditingCellBehaviorsProperty);
    }
    
    public static void SetGeneratedCellBehaviors(DependencyObject obj, BehaviorInteractionCollection value)
    {
      obj.SetValue(GeneratedCellBehaviorsProperty, value);
    }

    public static void SetGeneratedEditingCellBehaviors(DependencyObject obj, BehaviorInteractionCollection value)
    {
      obj.SetValue(GeneratedEditingCellBehaviorsProperty, value);
    }

    protected override Freezable CreateInstanceCore()
    {
      return new BehaviorInteractionCollection();
    }

  }
}
