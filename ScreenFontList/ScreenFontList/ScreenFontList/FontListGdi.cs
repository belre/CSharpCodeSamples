using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  // https://stackoverflow.com/questions/3486546/enumerating-active-fonts-in-c-sharp-using-dll-call-to-enumfontfamiliesex-has-me

  public class FontListGdi
  {
    public delegate int EnumFontExDelegate(ref ENUMLOGFONTEX lpelfe, ref NEWTEXTMETRICEX lpntme, int FontType, int lParam);


    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    public static extern int EnumFontFamiliesEx(IntPtr hdc,
                                [In] IntPtr pLogfont,
                                EnumFontExDelegate lpEnumFontFamExProc,
                                IntPtr lParam,
                                uint dwFlags);


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class LOGFONT
    {
      public int lfHeight;
      public int lfWidth;
      public int lfEscapement;
      public int lfOrientation;
      public FontWeight lfWeight;
      [MarshalAs(UnmanagedType.U1)]
      public bool lfItalic;
      [MarshalAs(UnmanagedType.U1)]
      public bool lfUnderline;
      [MarshalAs(UnmanagedType.U1)]
      public bool lfStrikeOut;
      public FontCharSet lfCharSet;
      public FontPrecision lfOutPrecision;
      public FontClipPrecision lfClipPrecision;
      public FontQuality lfQuality;
      public FontPitchAndFamily lfPitchAndFamily;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string lfFaceName;
    }




    public enum FontWeight : int
    {
      FW_DONTCARE = 0,
      FW_THIN = 100,
      FW_EXTRALIGHT = 200,
      FW_LIGHT = 300,
      FW_NORMAL = 400,
      FW_MEDIUM = 500,
      FW_SEMIBOLD = 600,
      FW_BOLD = 700,
      FW_EXTRABOLD = 800,
      FW_HEAVY = 900,
    }
    public enum FontCharSet : byte
    {
      ANSI_CHARSET = 0,
      DEFAULT_CHARSET = 1,
      SYMBOL_CHARSET = 2,
      SHIFTJIS_CHARSET = 128,
      HANGEUL_CHARSET = 129,
      HANGUL_CHARSET = 129,
      GB2312_CHARSET = 134,
      CHINESEBIG5_CHARSET = 136,
      OEM_CHARSET = 255,
      JOHAB_CHARSET = 130,
      HEBREW_CHARSET = 177,
      ARABIC_CHARSET = 178,
      GREEK_CHARSET = 161,
      TURKISH_CHARSET = 162,
      VIETNAMESE_CHARSET = 163,
      THAI_CHARSET = 222,
      EASTEUROPE_CHARSET = 238,
      RUSSIAN_CHARSET = 204,
      MAC_CHARSET = 77,
      BALTIC_CHARSET = 186,
    }
    public enum FontPrecision : byte
    {
      OUT_DEFAULT_PRECIS = 0,
      OUT_STRING_PRECIS = 1,
      OUT_CHARACTER_PRECIS = 2,
      OUT_STROKE_PRECIS = 3,
      OUT_TT_PRECIS = 4,
      OUT_DEVICE_PRECIS = 5,
      OUT_RASTER_PRECIS = 6,
      OUT_TT_ONLY_PRECIS = 7,
      OUT_OUTLINE_PRECIS = 8,
      OUT_SCREEN_OUTLINE_PRECIS = 9,
      OUT_PS_ONLY_PRECIS = 10,
    }
    public enum FontClipPrecision : byte
    {
      CLIP_DEFAULT_PRECIS = 0,
      CLIP_CHARACTER_PRECIS = 1,
      CLIP_STROKE_PRECIS = 2,
      CLIP_MASK = 0xf,
      CLIP_LH_ANGLES = (1 << 4),
      CLIP_TT_ALWAYS = (2 << 4),
      CLIP_DFA_DISABLE = (4 << 4),
      CLIP_EMBEDDED = (8 << 4),
    }
    public enum FontQuality : byte
    {
      DEFAULT_QUALITY = 0,
      DRAFT_QUALITY = 1,
      PROOF_QUALITY = 2,
      NONANTIALIASED_QUALITY = 3,
      ANTIALIASED_QUALITY = 4,
      CLEARTYPE_QUALITY = 5,
      CLEARTYPE_NATURAL_QUALITY = 6,
    }
    [Flags]
    public enum FontPitchAndFamily : byte
    {
      DEFAULT_PITCH = 0,
      FIXED_PITCH = 1,
      VARIABLE_PITCH = 2,
      FF_DONTCARE = (0 << 4),
      FF_ROMAN = (1 << 4),
      FF_SWISS = (2 << 4),
      FF_MODERN = (3 << 4),
      FF_SCRIPT = (4 << 4),
      FF_DECORATIVE = (5 << 4),
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct NEWTEXTMETRIC
    {
      public int tmHeight;
      public int tmAscent;
      public int tmDescent;
      public int tmInternalLeading;
      public int tmExternalLeading;
      public int tmAveCharWidth;
      public int tmMaxCharWidth;
      public int tmWeight;
      public int tmOverhang;
      public int tmDigitizedAspectX;
      public int tmDigitizedAspectY;
      public char tmFirstChar;
      public char tmLastChar;
      public char tmDefaultChar;
      public char tmBreakChar;
      public byte tmItalic;
      public byte tmUnderlined;
      public byte tmStruckOut;
      public byte tmPitchAndFamily;
      public byte tmCharSet;
      int ntmFlags;
      int ntmSizeEM;
      int ntmCellHeight;
      int ntmAvgWidth;
    }
    public struct FONTSIGNATURE
    {
      [MarshalAs(UnmanagedType.ByValArray)]
      int[] fsUsb;
      [MarshalAs(UnmanagedType.ByValArray)]
      int[] fsCsb;
    }
    public struct NEWTEXTMETRICEX
    {
      NEWTEXTMETRIC ntmTm;
      FONTSIGNATURE ntmFontSig;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ENUMLOGFONTEX
    {
      public LOGFONT elfLogFont;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
      public string elfFullName;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string elfStyle;
      [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
      public string elfScript;
    }

    private const byte DEFAULT_CHARSET = 1;
    private const byte SHIFTJIS_CHARSET = 128;
    private const byte JOHAB_CHARSET = 130;
    private const byte EASTEUROPE_CHARSET = 238;

    private const byte DEFAULT_PITCH = 0;
    private const byte FIXED_PITCH = 1;
    private const byte VARIABLE_PITCH = 2;
    private const byte FF_DONTCARE = (0 << 4);
    private const byte FF_ROMAN = (1 << 4);
    private const byte FF_SWISS = (2 << 4);
    private const byte FF_MODERN = (3 << 4);
    private const byte FF_SCRIPT = (4 << 4);
    private const byte FF_DECORATIVE = (5 << 4);
  }
}
