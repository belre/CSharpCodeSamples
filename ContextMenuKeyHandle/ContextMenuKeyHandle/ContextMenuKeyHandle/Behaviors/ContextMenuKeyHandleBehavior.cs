using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;

namespace ContextMenuKeyHandle.Behaviors
{
  public class ContextMenuKeyHandleBehavior : Behavior<ContextMenu>
  {
    public static readonly DependencyProperty CommandKeyHandleProperty = 
      DependencyProperty.Register(nameof(CommandKeyHandle),
        typeof(ICommand),
        typeof(ContextMenuKeyHandleBehavior),
        new PropertyMetadata(null));

    public ICommand CommandKeyHandle
    {
      get
      {
        return (ICommand)GetValue(CommandKeyHandleProperty);

      }
      set
      {
        SetValue(CommandKeyHandleProperty, value);
      }
    }

    protected override void OnAttached()
    {
      base.OnAttached();

      AssociatedObject.KeyDown += AssociatedObjectOnKeyDown;
    }


    protected override void OnDetaching()
    {
      base.OnDetaching();

      AssociatedObject.KeyDown -= AssociatedObjectOnKeyDown;
    }


    private void AssociatedObjectOnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Escape)
      {
        AssociatedObject.IsOpen = false;
        return;
      }

      if (CommandKeyHandle != null && CommandKeyHandle.CanExecute(e))
      {
        CommandKeyHandle.Execute(e);

        AssociatedObject.IsOpen = false;
      }
    }
  }
}
