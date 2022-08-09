using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace CustomizedDataGrid001
{
  public class BehaviorTextColumn : DataGridTextColumn
  {
    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
      Interaction.GetBehaviors(cell).Add(new KeyEscapeBehavior());

      return base.GenerateElement(cell, dataItem);
    }

    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
      var textbox = (TextBox)base.GenerateEditingElement(cell, dataItem);
      Interaction.GetBehaviors(textbox).Add(new KeyOnlyNumericBehavior());
  
      return textbox;
    }

  }
}
