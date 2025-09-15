using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public interface IWinFontLoader
  {
    void Load();

    Type LogFontType { get; }

    IEnumerable<object> LogFontList { get; }

    float? DefaultFontSize {  get; }
  }

}
