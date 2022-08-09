using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;

namespace CustomizedDataGrid001
{
  public class MainViewModel : BindableBase
  {
    public ObservableCollection<BranchViewModel> Items
    {
      get;
      set;
    }

    public MainViewModel()
    {
      Items = new ObservableCollection<BranchViewModel>()
      {
        new BranchViewModel()
        {
          DefaultItem = "デフォルト",
          CodeBehindItem = "コードビハインド", 
          BehaviorItem = "ビヘイビア",
          UserStyleBehaviorItem = "ビヘイビアインタラクション",
        },
        new BranchViewModel()
        {
          DefaultItem = "DEFAULT",
          CodeBehindItem = "CODEBEHIND",
          BehaviorItem = "BEHAVIOR",
          UserStyleBehaviorItem = "BEHAVIOR INTERACTION",
        }
      };
    }
  }
}
