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
  public partial class DataGridViewOnlyRowsAdd : Form
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }

    public DataGridViewOnlyRowsAdd()
    {
      InitializeComponent();
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {


      dataGridView1.Rows.Clear();

      var stopwatch = new Stopwatch();

      stopwatch.Start();
      foreach(var line in Lines)
      {
        dataGridView1.Rows.Add(new[]
        {
          line.Number.ToString(), line.Name, line.DateTime.ToString("yyyy/MM/dd HH:mm:SS")
        });
      }

      stopwatch.Stop();
      LabelStopWatch.Text = $"{stopwatch.ElapsedMilliseconds} ms";

    }

    private void LabelStopWatch_MouseClick(object sender, MouseEventArgs e)
    {
      if(e.Button == MouseButtons.Right)
      {
        Clipboard.SetText(LabelStopWatch.Text);
      }
    }

    private void DataGridViewOnlyRowsAdd_Load(object sender, EventArgs e)
    {

    }
  }
}
