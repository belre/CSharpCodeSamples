using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class LogFontProxy
  {
    public string FontName
    {
      get;
      set;
    }
    public string FaceName
    {
      get;
      set;
    }

    public int Height
    {
      get;
      set;
    }

    public int Width
    {
      get;
      set;
    }

    public int Escapement
    {
      get;
      set;
    }

    public int Orientation
    {
      get;
      set;
    }

    public Gdi32FontItem.FontWeight Weight
    {
      get;
      set;
    }

    public bool Italic
    {
      get;
      set;
    }

    public bool Underline
    {
      get;
      set;
    }

    public bool StrikeOut
    {
      get;
      set;
    }

    public Gdi32FontItem.FontCharSet CharSet
    {
      get;
      set;
    }

    public Gdi32FontItem.FontPrecision OutPrecision
    {
      get;
      set;
    }

    public Gdi32FontItem.FontClipPrecision ClipPrecision
    {
      get;
      set;
    }

    public Gdi32FontItem.FontQuality Quality
    {
      get;
      set;
    }

    public Gdi32FontItem.FontPitchAndFamily PitchAndFamily
    {
      get;
      set;
    }

    public Gdi32FontItem.LOGFONT RawLogFont
    {
      get;
      set;
    }


    private void SetFromLogFont(Gdi32FontItem.LOGFONT font)
    {
      FaceName = font.lfFaceName;
      Height = font.lfHeight;
      Width = font.lfWidth;
      Escapement = font.lfEscapement;
      Orientation = font.lfOrientation;
      Weight = font.lfWeight;
      Italic = font.lfItalic;
      Underline = font.lfUnderline;
      StrikeOut = font.lfStrikeOut;
      CharSet = font.lfCharSet;
      OutPrecision = font.lfOutPrecision;
      ClipPrecision = font.lfClipPrecision;
      Quality = font.lfQuality;
      PitchAndFamily = font.lfPitchAndFamily;
      RawLogFont = font;
    }

    public LogFontProxy(Gdi32FontItem.LOGFONT font)
    {
      SetFromLogFont(font);
    }

    public LogFontProxy(FontFamily family)
    {
      // LogFontが読めるので、Font Familyからの設定も反映する
      var familyFont = new Font(family, 11F);
      var logFont = new Gdi32FontItem.LOGFONT();
      familyFont.ToLogFont(logFont);

      SetFromLogFont(logFont);
      FontName = family.Name;
    }


    public static IEnumerable<LogFontProxy> ConvertFrom(IWinFontLoader loader)
    {
      var fontList = loader.LogFontList;

      if(loader.LogFontType == typeof(Gdi32FontItem.LOGFONT)) {
        return loader.LogFontList
          .Cast<Gdi32FontItem.LOGFONT>()
          .Select(f => new LogFontProxy(f));
      }
      else if(loader.LogFontType == typeof(FontFamily))
      {
        return loader.LogFontList
          .Cast<FontFamily>()
          .Select(f => new LogFontProxy(f));
      }

      throw new InvalidOperationException("Log font type is not corrected");
    }

    /// <summary>
    /// LogFontProxyを.NETのFont型に変換します
    /// </summary>
    /// <param name="graphics">フォントサイズ計算用のGraphicsオブジェクト</param>
    /// <returns>変換されたFontオブジェクト</returns>
    public Font ToFont(Graphics graphics = null)
    {
      try
      {
        // フォントファミリを取得
        FontFamily fontFamily;
        try
        {
          fontFamily = new FontFamily(FaceName);
        }
        catch (ArgumentException)
        {
          // 指定されたフォント名が見つからない場合はデフォルトを使用
          fontFamily = FontFamily.GenericSansSerif;
        }

        // フォントサイズを計算
        float fontSize = CalculateFontSize(graphics);

        // フォントスタイルを設定
        FontStyle style = FontStyle.Regular;
        if (Italic) style |= FontStyle.Italic;
        if (Underline) style |= FontStyle.Underline;
        if (StrikeOut) style |= FontStyle.Strikeout;
        if (IsBold()) style |= FontStyle.Bold;

        return new Font(fontFamily, fontSize, style);
      }
      catch (Exception)
      {
        // エラーの場合はデフォルトフォントを返す
        return SystemFonts.DefaultFont;
      }
    }

    /// LOGFONTのHeightからフォントサイズを計算します
    /// </summary>
    /// <param name="graphics">計算用のGraphicsオブジェクト</param>
    /// <returns>フォントサイズ（ポイント単位）</returns>
    private float CalculateFontSize(Graphics graphics)
    {
      if (graphics == null)
      {
        using (var bitmap = new Bitmap(1, 1))
        using (var g = Graphics.FromImage(bitmap))
        {
          return CalculateFontSizeInternal(g);
        }
      }
      return CalculateFontSizeInternal(graphics);
    }

    private float CalculateFontSizeInternal(Graphics graphics)
    {
      if (Height == 0)
        return 12f; // デフォルトサイズ

      // Heightがマイナスの場合は文字の高さ、プラスの場合はセルの高さ
      float absHeight = Math.Abs(Height);

      // ピクセルからポイントに変換
      // 1ポイント = 1/72インチ
      float fontSize = absHeight * 72f / graphics.DpiY;

      // 最小値と最大値を制限
      if (fontSize < 1f) fontSize = 1f;
      if (fontSize > 1000f) fontSize = 1000f;

      return fontSize;
    }

    /// <summary>
    /// フォントウェイトから太字かどうかを判定します
    /// </summary>
    /// <returns>太字の場合true</returns>
    private bool IsBold()
    {
      // FontWeight.FW_BOLD (700) 以上を太字とする
      return (int)Weight >= 700;
    }

    /// <summary>
    /// LOGFONTから直接Fontオブジェクトを作成する静的メソッド
    /// </summary>
    /// <param name="logFont">LOGFONT構造体</param>
    /// <param name="graphics">計算用のGraphicsオブジェクト（省略可能）</param>
    /// <returns>変換されたFontオブジェクト</returns>
    public static Font CreateFontFromLogFont(Gdi32FontItem.LOGFONT logFont, Graphics graphics = null)
    {
      var proxy = new LogFontProxy(logFont);
      return proxy.ToFont(graphics);
    }
  }
}
