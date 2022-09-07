using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContextMenuKeyHandleExtension.ViewModel
{
  public class MenuViewModel
  {
    public string MenuText
    {
      get;
      set;
    }

    public Key Key
    {
      get;
      set;
    }

    public string KeyGesture
    {
      get
      {
        return Key.ToString();
      }
    }

    public ICommand KeyCommand
    {
      get;
      set;
    }

    public ICommand ClickCommand
    {
      get;
      set;
    }
  }
}
