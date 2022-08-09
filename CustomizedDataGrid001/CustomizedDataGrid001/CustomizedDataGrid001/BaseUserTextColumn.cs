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
    /// 列が生成されるときに実行される
    /// </summary>
    /// <param name="cell">セル</param>
    /// <param name="dataItem">Context</param>
    /// <returns></returns>
    protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
    {
      return base.GenerateElement(cell, dataItem);
    }

    /// <summary>
    /// 列が編集されるときに実行される
    /// </summary>
    /// <param name="cell">セル</param>
    /// <param name="dataItem">Context</param>
    /// <returns></returns>
    protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
    {
      var textbox = (TextBox)base.GenerateEditingElement(cell, dataItem);
      return textbox;
    }
  }
}
