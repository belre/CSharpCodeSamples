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
using System.Windows.Shapes;

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
      userDataGridViewControl1.UpdateData();
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
        userDataGridViewControl1.EnableResizeMode();
      }
    }

    private void DataGridViewResize_ResizeEnd(object sender, EventArgs e)
    {
      if (CheckBoxResizeOptimized.Checked)
      {
        userDataGridViewControl1.DisableResizeMode();
      }
    }

    private void DataGridViewResize_Load(object sender, EventArgs e)
    {
      userDataGridViewControl1.Lines = Lines;
    }
  }
}
