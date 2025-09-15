using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class GdiplusFontLoader : AbstractWinFontLoader<FontFamily>
  {
    private List<FontFamily> _logFontList = new List<FontFamily>();


    private float _defaultFontSize = 12.0F;
    public override float? DefaultFontSize => _defaultFontSize;


    public GdiplusFontLoader()
    {
      
    }

    public GdiplusFontLoader(float defaultFontSize)
    {
      _defaultFontSize = defaultFontSize;
    }

    public override IEnumerable<FontFamily> ConcreteLogFontList => _logFontList;

    public override void Load()
    {
      _logFontList.Clear();
      _logFontList.AddRange(new InstalledFontCollection().Families);
    }

    public override Type LogFontType => typeof(FontFamily);

  }
}
