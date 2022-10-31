using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewOptimization.GridDataModel;

namespace DataGridViewOptimization
{
  public partial class UserDataGridViewControl : UserControl
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }

    public UserDataGridViewControl()
    {
      InitializeComponent();

    }

    public void UpdateData()
    {
      TableBindingSource.RaiseListChangedEvents = false;
      TableBindingSource.SuspendBinding();

      TableBindingSource.DataSource = Lines;

      TableBindingSource.RaiseListChangedEvents = true;
      TableBindingSource.ResumeBinding();
      TableBindingSource.ResetBindings(false);

    }

    public void EnableResizeMode()
    {
      repaintOptimizedDataGridView1.IsEnableBorderPaint = false;
    }

    public void DisableResizeMode()
    {
      repaintOptimizedDataGridView1.IsEnableBorderPaint = true;
      repaintOptimizedDataGridView1.Invalidate();
    }
  }
}
