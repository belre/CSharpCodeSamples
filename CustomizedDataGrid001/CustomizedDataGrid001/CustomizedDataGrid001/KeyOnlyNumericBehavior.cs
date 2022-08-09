using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CustomizedDataGrid001
{
  public class KeyOnlyNumericBehavior : Behavior<TextBox>
  {
    protected override void OnAttached()
    {
      AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
    }


    protected override void OnDetaching()
    {
      AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
    }


    private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      int val = 0;
      if (!int.TryParse(e.Text, out val))
      {
        e.Handled = true;
      }
    }
  }
}
