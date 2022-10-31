﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewOptimization
{
  public class RepaintOptimizedDataGridView : DataGridView
  {
    public RepaintOptimizedDataGridView()
    {
      IsEnableCellPaint = true;
    }

    public bool IsEnableCellPaint
    {
      get;
      set;
    }

    protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
    {
      base.OnRowPrePaint(e);

      if (IsEnableCellPaint)
      {
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All);
        e.PaintHeader(DataGridViewPaintParts.Background
                      | DataGridViewPaintParts.Border
                      | DataGridViewPaintParts.Focus
                      | DataGridViewPaintParts.SelectionBackground
                      | DataGridViewPaintParts.ContentForeground);

      }
      else
      {
        e.PaintCells(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
        e.PaintHeader(DataGridViewPaintParts.Background
                      | DataGridViewPaintParts.Border
                      | DataGridViewPaintParts.Focus
                      | DataGridViewPaintParts.SelectionBackground
                      | DataGridViewPaintParts.ContentForeground);
      }

      e.Handled = true;
    }
  }
}
