using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;
using Prism.Commands;
using Prism.Mvvm;

namespace ContextMenuKeyHandleExtension.ViewModel
{
  public class MainViewModel : BindableBase
  {
    public enum ContextMenuExecutionState
    {
      Default,
      Key
    }

    public ObservableCollection<MenuViewModel> MenuItems
    {
      get;
      set;
    }

    private string _current_text;
    public string CurrentText
    {
      get
      {
        return _current_text;
      }
      set
      {
        _current_text = value;
        RaisePropertyChanged(nameof(CurrentText));
      }
    }

    public MainViewModel()
    {
      MenuItems = new ObservableCollection<MenuViewModel>();
      MenuItems.Add(new MenuViewModel()
      {
        MenuText = "Action A",
        Key = Key.A,
        KeyCommand = new DelegateCommand(RunActionAKey),
        ClickCommand = new DelegateCommand(RunActionAClick)
      });
      MenuItems.Add(new MenuViewModel()
      {
        MenuText = "Action B",
        Key = Key.B,
        KeyCommand = new DelegateCommand(RunActionBKey),
        ClickCommand = new DelegateCommand(RunActionBClick)
      }); MenuItems.Add(new MenuViewModel()
      {
        MenuText = "Action C",
        Key = Key.C,
        KeyCommand = new DelegateCommand(RunActionCKey),
        ClickCommand = new DelegateCommand(RunActionCClick)
      });

      CurrentText = string.Empty;
    }

    
    private ICommand _command_key_handle;
    public ICommand CommandKeyHandle
    {
      get
      {
        return _command_key_handle ?? (_command_key_handle = new DelegateCommand<KeyEventArgs>(HandleKeys, AcceptHandleKeys));
      }
    }

    private bool AcceptHandleKeys(KeyEventArgs arg)
    {
      foreach (var item in MenuItems)
      {
        if (item.Key == arg.Key)
        {
          return true;
        }
      }

      return false;
    }

    private void HandleKeys(KeyEventArgs arg)
    {
      foreach (var item in MenuItems)
      {
        if (item.Key == arg.Key && item.KeyCommand != null && item.KeyCommand.CanExecute(true))
        {
          item.KeyCommand.Execute(true);
        }
      }
    }

    private void RunActionAClick()
    {
      CurrentText = "Run Action A (Click)";
    }

    private void RunActionAKey()
    {
      CurrentText = "Run Action A (Key)";
    }


    private void RunActionBClick()
    {
      CurrentText = "Run Action B (Click)";
    }

    private void RunActionBKey()
    {
      CurrentText = "Run Action B (Key)";
    }

    private void RunActionCClick()
    {
      CurrentText = "Run Action C (Click)";
    }


    private void RunActionCKey()
    {
      CurrentText = "Run Action C (Key)";
    }

  }
}
