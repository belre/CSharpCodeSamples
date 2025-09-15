using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ScreenFontList;

namespace ScreenFontList
{
  // https://stackoverflow.com/questions/3486546/enumerating-active-fonts-in-c-sharp-using-dll-call-to-enumfontfamiliesex-has-me

  /// <summary>
  /// スクリーンフォントの一覧を読み取る
  /// </summary>
  public class FontLoaderStrategy
  {
    public enum FontLoadMode
    {
      Gdi32,
      GdiPlus
    }

    private IWinFontLoader _gdiFontLoader;

    public IWinFontLoader FontLoader => _gdiFontLoader;


    public FontLoaderStrategy(FontLoadMode fontLoadMode)
    {
      if(fontLoadMode == FontLoadMode.Gdi32)
      {
        _gdiFontLoader = new Gdi32FontLoader();
      }
      else if(fontLoadMode == FontLoadMode.GdiPlus)
      {
        _gdiFontLoader = new GdiplusFontLoader();
      }
    }

    public void LoadFont()
    {
      _gdiFontLoader.Load();
    }
  }
}
