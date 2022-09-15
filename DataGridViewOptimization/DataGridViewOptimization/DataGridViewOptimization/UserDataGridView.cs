using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewOptimization
{
  public class UserDataGridView : DataGridView
  {
    public enum DataGridViewRepaintMode
    {
      Normal,
      ControlUpdate
    }

    [Browsable(true)]
    public DataGridViewRepaintMode RepaintMode
    {
      get;
      set;
    }

    protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
    {
      base.OnRowPrePaint(e);
    }
  }
}
