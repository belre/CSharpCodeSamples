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
  public class ScreenFontTable
  {


    public ScreenFontTable()
    {
      ScreenFontList = new List<string>();
      FontDictionary = new Dictionary<string, List<FontListGdi.LOGFONT>>();
      LogFontList = new List<FontListGdi.LOGFONT>();
    }

    public IEnumerable<string> SortedFontList
    {
      get
      {
        return ScreenFontList.OrderBy(c => c);
      }
    }

    public Dictionary<string, List<FontListGdi.LOGFONT>> FontDictionary
    {
      get;
      protected set;
    }

    public List<FontListGdi.LOGFONT> LogFontList
    {
      get;
      protected set;
    }

    public List<string> ScreenFontList
    {
      get;
      protected set;
    }

    public void LoadFont()
    {
      FontListGdi.LOGFONT lf = CreateLogFont("");

      IntPtr plogFont = Marshal.AllocHGlobal(Marshal.SizeOf(lf));
      Marshal.StructureToPtr(lf, plogFont, true);

      int ret = 0;
      try
      {
        var bitmap = new Bitmap(1000, 1000);
        using (var g = Graphics.FromImage(bitmap))
        {
          var intptr = g.GetHdc();
          FontListGdi.EnumFontFamiliesEx(intptr, plogFont, FontFamiliesCallBack, IntPtr.Zero, 0);
          g.ReleaseHdc(intptr);
        }
      }
      catch
      {
        // エラーの場合はデフォルトのフォントを選択する
        ScreenFontList.Clear();
        ScreenFontList.AddRange(new InstalledFontCollection().Families.Select(c => c.Name).Distinct());
      }
      finally
      {
        Marshal.DestroyStructure(plogFont, typeof(FontListGdi.LOGFONT));
      }
    }

    public FontListGdi.LOGFONT CreateLogFont(string fontname)
    {
      FontListGdi.LOGFONT lf = new FontListGdi.LOGFONT();
      lf.lfHeight = 0;
      lf.lfWidth = 0;
      lf.lfEscapement = 0;
      lf.lfOrientation = 0;
      lf.lfWeight = 0;
      lf.lfItalic = false;
      lf.lfUnderline = false;
      lf.lfStrikeOut = false;
      lf.lfCharSet = FontListGdi.FontCharSet.DEFAULT_CHARSET;
      lf.lfOutPrecision = 0;
      lf.lfClipPrecision = 0;
      lf.lfQuality = 0;
      lf.lfPitchAndFamily = FontListGdi.FontPitchAndFamily.FF_DONTCARE;
      lf.lfFaceName = "";

      return lf;
    }

    private int cnt = 0;
    public int FontFamiliesCallBack(ref FontListGdi.ENUMLOGFONTEX lpelfe, ref FontListGdi.NEWTEXTMETRICEX lpntme, int FontType, int lParam)
    {
      try
      {
        ++cnt;

        if (!ScreenFontList.Contains(lpelfe.elfFullName))
        {
          ScreenFontList.Add(lpelfe.elfFullName);
        }

        if (!FontDictionary.ContainsKey(lpelfe.elfFullName))
        {
          FontDictionary[lpelfe.elfFullName] = new List<FontListGdi.LOGFONT>();
        }
        FontDictionary[lpelfe.elfFullName].Add(lpelfe.elfLogFont);

        LogFontList.Add(lpelfe.elfLogFont);
      }
      catch (Exception e)
      {
        System.Diagnostics.Trace.WriteLine(e.ToString());
      }
      return cnt;
    }
  }
}
