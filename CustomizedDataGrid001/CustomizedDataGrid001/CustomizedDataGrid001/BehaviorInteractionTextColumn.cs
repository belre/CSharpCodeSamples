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
  public class BehaviorInteractionTextColumn : DataGridTextColumn
  {
    public Style CellEditingStyle 
    { 
      get; 
      set; 
    }

    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
      return base.GenerateElement(cell, dataItem);
    }

    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
      var textbox = (TextBox)base.GenerateEditingElement(cell, dataItem);
      textbox.Style = CellEditingStyle;

      return textbox;
    }
  }
}
