using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CustomizedDataGrid001
{
  public class KeyEscapeBehavior : Behavior<DataGridCell>
  {
    protected override void OnAttached()
    {
      AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
    }


    protected override void OnDetaching()
    {
      AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
    }

    private void AssociatedObject_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if (e.Key == System.Windows.Input.Key.Escape)
      {
        e.Handled = true;
      }
    }
  }
}
