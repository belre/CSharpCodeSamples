using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;

namespace CustomizedDataGrid001
{
  public class CodeBehindTextColumn : DataGridTextColumn
  {
    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
      cell.PreviewKeyDown -= Cell_PreviewKeyDown;
      cell.PreviewKeyDown += Cell_PreviewKeyDown;

      return base.GenerateElement(cell, dataItem);
    }


    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
      cell.PreviewTextInput -= Cell_PreviewTextInput;
      cell.PreviewTextInput += Cell_PreviewTextInput;
      return base.GenerateEditingElement(cell, dataItem);
    }


    private void Cell_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if(e.Key == System.Windows.Input.Key.Escape)
      {
        e.Handled = true;
      }
    }

    private void Cell_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      int val = 0;
      if(!int.TryParse(e.Text, out val))
      {
        e.Handled = true;
      }
    }
  }
}
