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

namespace DataGridViewOptimization
{
  public partial class Form1 : Form
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }

    protected void CreateLines()
    {
      var lines = new List<SimpleDataLine>();

      int lines_number = (int)numericUpDown1.Value;

      var rand = new Random();

      for (int i = 0; i < lines_number; i++)
      {
        lines.Add(new SimpleDataLine()
        {
          Number = i,
          Name = (new string[10]).Aggregate(string.Empty, (str, a) => str + (char)(rand.Next('Z' - 'A' + 1) + 'A')),
          DateTime = DateTime.Now.AddDays(i)
        });
      }

      Lines = lines;
    }

    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      if(Lines == null)
      {
        CreateLines();
      }

      var dialog = new DataGridViewOnlyRowsAdd();
      dialog.Lines = Lines;
      dialog.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (Lines == null)
      {
        CreateLines();
      }

      var dialog = new DataGridViewBindingSource();
      dialog.Lines = Lines;
      dialog.ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      CreateLines();

    }

    private void button4_Click(object sender, EventArgs e)
    {
      var dialog = new DataGridViewUpdate();
      dialog.Lines = Lines;
      dialog.Show();
    }
  }
}
