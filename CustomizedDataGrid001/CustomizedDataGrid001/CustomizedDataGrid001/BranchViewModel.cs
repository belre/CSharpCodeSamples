using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;

namespace CustomizedDataGrid001
{
  public class BranchViewModel : BindableBase
  {
    public string DefaultItem
    {
      get;
      set;
    }

    public string CodeBehindItem
    {
      get;
      set;
    }

    public string TriggerItem
    {
      get;
      set;
    }

    public string BehaviorItem
    {
      get;
      set;
    }

  }
}
