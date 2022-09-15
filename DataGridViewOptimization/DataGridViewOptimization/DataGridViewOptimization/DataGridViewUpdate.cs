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
  public partial class DataGridViewUpdate : Form
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }

    public DataGridViewUpdate()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {

      var stopwatch = new Stopwatch();

      
      Task.Delay(200);

      stopwatch.Start();
      if (CheckBoxDisableAutoBind.Checked)
      {
        TableBindingSource.RaiseListChangedEvents = false;
        TableBindingSource.SuspendBinding();
      }

      TableBindingSource.DataSource = Lines;

      if (CheckBoxDisableAutoBind.Checked)
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
      if (e.Button == MouseButtons.Right)
      {
        Clipboard.SetText(LabelStopWatch.Text);
      }
    }

    int _clicked_column_number = -1;
    int _clicked_row_number = -1;

    private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if(e.RowIndex < 0 && e.ColumnIndex >= 0)
      {
        _clicked_row_number = -1;
        _clicked_column_number = e.ColumnIndex;
      }
      else if(e.RowIndex >= 0 && e.ColumnIndex < 0)
      {
        _clicked_row_number = e.RowIndex;
        _clicked_column_number = -1;
      }
    }



  }
}
