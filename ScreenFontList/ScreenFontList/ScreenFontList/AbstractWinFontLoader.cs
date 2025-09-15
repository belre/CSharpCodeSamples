using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public abstract class AbstractWinFontLoader<T> : IWinFontLoader
    where T : class
  {
    public abstract void Load();

    public abstract Type LogFontType { get; }

    public abstract float? DefaultFontSize { get; }

    public IEnumerable<object> LogFontList => ConcreteLogFontList
      .Select(f => f as T)
      .Where(f => f != null);

    public abstract IEnumerable<T> ConcreteLogFontList { get; }


  }
}
