using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewOptimization.GridDataModel;
using System.Diagnostics;

namespace DataGridViewOptimization
{
  public partial class DataGridViewResize : Form
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }
    


    public DataGridViewResize()
    {
      InitializeComponent();
    }


    private void button1_Click(object sender, EventArgs e)
    {
      var stopwatch = new Stopwatch();

      Task.Delay(200);

      stopwatch.Start();
      if (CheckBoxResizeOptimized.Checked)
      {
        TableBindingSource.RaiseListChangedEvents = false;
        TableBindingSource.SuspendBinding();
      }

      TableBindingSource.DataSource = Lines;

      if (CheckBoxResizeOptimized.Checked)
      {
        TableBindingSource.RaiseListChangedEvents = true;
        TableBindingSource.ResumeBinding();
        TableBindingSource.ResetBindings(false);
      }

      stopwatch.Stop();
      LabelStopWatch.Text = $"{stopwatch.ElapsedMilliseconds} ms";
    }

    private void LabelStopWatch_MouseClick(object sender, MouseEventArgs e)
    {

    }


    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {

    }

    private void DataGridViewResize_ResizeBegin(object sender, EventArgs e)
    {
      if (CheckBoxResizeOptimized.Checked)
      {
        dataGridView1.IsEnableCellPaint = false;
      }
    }

    private void DataGridViewResize_ResizeEnd(object sender, EventArgs e)
    {
      if (CheckBoxResizeOptimized.Checked)
      {
        dataGridView1.IsEnableCellPaint = true;
        dataGridView1.Invalidate();
      }
    }




  }
}
