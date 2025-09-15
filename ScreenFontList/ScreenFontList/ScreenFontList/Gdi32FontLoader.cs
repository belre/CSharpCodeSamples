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
  public class Gdi32FontLoader : AbstractWinFontLoader<Gdi32FontItem.LOGFONT>
  {
    public override float? DefaultFontSize => null;

    private List<Gdi32FontItem.LOGFONT> _logFontList = new List<Gdi32FontItem.LOGFONT>();

    public override IEnumerable<Gdi32FontItem.LOGFONT> ConcreteLogFontList => _logFontList;

    private int _fontInitCounter = 0;

    public Gdi32FontItem.LOGFONT CreateLogFont(string fontname)
    {
      Gdi32FontItem.LOGFONT lf = new Gdi32FontItem.LOGFONT();
      lf.lfHeight = 0;
      lf.lfWidth = 0;
      lf.lfEscapement = 0;
      lf.lfOrientation = 0;
      lf.lfWeight = 0;
      lf.lfItalic = false;
      lf.lfUnderline = false;
      lf.lfStrikeOut = false;
      lf.lfCharSet = Gdi32FontItem.FontCharSet.DEFAULT_CHARSET;
      lf.lfOutPrecision = 0;
      lf.lfClipPrecision = 0;
      lf.lfQuality = 0;
      lf.lfPitchAndFamily = Gdi32FontItem.FontPitchAndFamily.FF_DONTCARE;
      lf.lfFaceName = "";

      return lf;
    }

    public override Type LogFontType => typeof(Gdi32FontItem.LOGFONT);

    public override void Load()
    {
      Gdi32FontItem.LOGFONT lf = CreateLogFont("");

      IntPtr plogFont = Marshal.AllocHGlobal(Marshal.SizeOf(lf));
      Marshal.StructureToPtr(lf, plogFont, true);

      _fontInitCounter = 0;

      int ret = 0;
      try
      {
        var bitmap = new Bitmap(1000, 1000);
        using (var g = Graphics.FromImage(bitmap))
        {
          var intptr = g.GetHdc();
          Gdi32FontItem.EnumFontFamiliesEx(intptr, plogFont, FontFamiliesCallBack, IntPtr.Zero, 0);
          g.ReleaseHdc(intptr);
        }
      }
      catch
      {
        throw new SystemException("Font Loading Error");
      }
      finally
      {
        Marshal.DestroyStructure(plogFont, typeof(Gdi32FontItem.LOGFONT));
      }
    }

    private int FontFamiliesCallBack(ref Gdi32FontItem.ENUMLOGFONTEX lpelfe, ref Gdi32FontItem.NEWTEXTMETRICEX lpntme, int FontType, int lParam)
    {
      try
      {
        ++_fontInitCounter;

        _logFontList.Add(lpelfe.elfLogFont);
      }
      catch (Exception e)
      {
        System.Diagnostics.Trace.WriteLine(e.ToString());
      }

      return _fontInitCounter;
    }
  }
}
