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
  public class BaseUserTextColumn : DataGridTextColumn
  {
    /// <summary>
    /// キーが生成されるときに実行される
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="dataItem"></param>
    /// <returns></returns>
    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
      return base.GenerateElement(cell, dataItem);
    }

    /// <summary>
    /// キーが編集されるときに実行される
    /// </summary>
    /// <param name="cell"></param>
    /// <param name="dataItem"></param>
    /// <returns></returns>
    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
      return base.GenerateEditingElement(cell, dataItem);
    }
  }
}
