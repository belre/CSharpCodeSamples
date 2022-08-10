using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolTipTestWinForms
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      toolTip1.SetToolTip(button1, "ToolTip1");
    }
  }
}
