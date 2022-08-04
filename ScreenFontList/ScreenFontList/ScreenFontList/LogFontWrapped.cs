using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class LogFontWrapped
  {
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

    public FontListGdi.FontWeight Weight
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

    public FontListGdi.FontCharSet CharSet
    {
      get;
      set;
    }

    public FontListGdi.FontPrecision OutPrecision
    {
      get;
      set;
    }

    public FontListGdi.FontClipPrecision ClipPrecision
    {
      get;
      set;
    }

    public FontListGdi.FontQuality Quality
    {
      get;
      set;
    }

    public FontListGdi.FontPitchAndFamily PitchAndFamily
    {
      get;
      set;
    }

    public FontListGdi.LOGFONT RawLogFont
    {
      get;
      set;
    }

    public LogFontWrapped(FontListGdi.LOGFONT font)
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
  }
}
