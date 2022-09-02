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
  public partial class DataGridViewBindingSource : Form
  {
    public IEnumerable<SimpleDataLine> Lines
    {
      get;
      set;
    }

    public DataGridViewBindingSource()
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



    private void dataGridView1_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
    {
      if(e.RowIndex >= 0 && e.ColumnIndex < 0)
      {
        e.ContextMenuStrip = RowContextMenu;
      }
      else if(e.ColumnIndex >= 0 && e.RowIndex < 0)
      {
        e.ContextMenuStrip = ColumnContextMenu;
      }
    }


    private void ColumnContextMenu_Opening(object sender, CancelEventArgs e)
    {
      foreach (ToolStripMenuItem item in autoSizeModeToolStripMenuItem.DropDownItems)
      {
        item.Checked = false;
      }

      if(_clicked_column_number >= 0)
      {
        var auto_size_mode = dataGridView1.Columns[_clicked_column_number].AutoSizeMode;
        if (auto_size_mode == DataGridViewAutoSizeColumnMode.NotSet)
        {
          notSetToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.None)
        {
          noneToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.DisplayedCells)
        {
          displayCellsToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader)
        {
          displayCellsExceptHeaderToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.ColumnHeader)
        {
          columnHeaderToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.AllCells)
        {
          allCellsToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
        {
          allCellsExceptHeaderToolStripMenuItem.Checked = true;
        }
        else if(auto_size_mode == DataGridViewAutoSizeColumnMode.Fill)
        {
          fillToolStripMenuItem.Checked = true;
        }
      }
      else
      {
        e.Cancel = true;
      }
    }

    private void AutoSizeModeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if(_clicked_column_number < 0)
      {
        return;
      }

      DataGridViewColumn target_item = dataGridView1.Columns[_clicked_column_number];

      if (sender == notSetToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
      }
      else if(sender == noneToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
      }
      else if(sender == displayCellsToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
      }
      else if(sender == displayCellsExceptHeaderToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
      }
      else if(sender == columnHeaderToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
      }
      else if(sender == allCellsToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      }
      else if(sender == allCellsExceptHeaderToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
      }
      else if(sender == fillToolStripMenuItem)
      {
        target_item.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      }
    }

    private void insertEmptyLineToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if(dataGridView1.SelectedRows.Count >= 1)
      {
        var index_list = new List<int>();
        for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
        {
          index_list.Add(dataGridView1.SelectedRows[i].Index);
        }


        var index = index_list.Min();

        for(int i = 0; i < index_list.Count(); i++)
        {
          TableBindingSource.Insert(index, new SimpleDataLine());
        }
      }
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      if (dataGridView1.SelectedRows.Count >= 1)
      {
        var index_list = new List<int>();
        for(int i = 0; i < dataGridView1.SelectedRows.Count; i++)
        {
          index_list.Add(dataGridView1.SelectedRows[i].Index);
        }
        var sorted_index_list = index_list.OrderByDescending(c => c);


        foreach(var sorted_index in sorted_index_list)
        {
          TableBindingSource.RemoveAt(sorted_index);
        }
      }

    }
  }
}
