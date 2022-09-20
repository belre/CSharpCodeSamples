using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Linq;
  using System.Runtime.InteropServices;
  using System.Text;
  using System.Threading.Tasks;

  namespace ctkpcmswcs.Native
  {
    // https://aharisu.hatenadiary.org/entry/20090525/1243253367

    public class TextOutGdi
    {
      [DllImport("gdi32.dll")]
      public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart,
        string lpString, int cbString);

      [DllImport("gdi32.dll")]
      public static extern UInt32 GetFontData(IntPtr hdc, UInt32 dwTable, UInt32 dwOffset, Byte[] pvBuffer, UInt32 cjBuffer);

      public static readonly int BKMODE_TRANSPARENT = 1;

      [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
      public static extern IntPtr CreateFontIndirect(FontListGdi.LOGFONT lf);


      [DllImport("gdi32.dll")]
      public static extern int SetBkColor(IntPtr hdc, uint crColor);


      [DllImport("gdi32.dll")]
      public static extern int SetBkMode(IntPtr hdc, int crColor);

      [DllImport("gdi32.dll")]
      public static extern int SetTextColor(System.IntPtr hdc, int flag);

      [DllImport("gdi32.dll")]
      public static extern bool GetTextExtentPoint32(IntPtr hdc, string lpString, int cbString, out Size lpSize);

      [DllImport("gdi32.dll")]
      public static extern bool DeleteObject(IntPtr hObject);

      [DllImport("gdi32.dll")]
      public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

      public enum StockObjects
      {
        WHITE_BRUSH = 0,
        LTGRAY_BRUSH = 1,
        GRAY_BRUSH = 2,
        DKGRAY_BRUSH = 3,
        BLACK_BRUSH = 4,
        NULL_BRUSH = 5,
        HOLLOW_BRUSH = NULL_BRUSH,
        WHITE_PEN = 6,
        BLACK_PEN = 7,
        NULL_PEN = 8,
        OEM_FIXED_FONT = 10,
        ANSI_FIXED_FONT = 11,
        ANSI_VAR_FONT = 12,
        SYSTEM_FONT = 13,
        DEVICE_DEFAULT_FONT = 14,
        DEFAULT_PALETTE = 15,
        SYSTEM_FIXED_FONT = 16,
        DEFAULT_GUI_FONT = 17,
        DC_BRUSH = 18,
        DC_PEN = 19,
      }

      [DllImport("gdi32.dll")]
      public static extern IntPtr GetStockObject(StockObjects fnObject);

      public static void PreviewOnNonSmoothingFont(Action action)
      {
        ControlDrawing.SystemParametersInfo(ControlDrawing.SPI_SETFONTSMOOTHING, 0, IntPtr.Zero, 0);

        Exception exp = null;
        try
        {
          if (action != null)
          {
            action();
          }
        }
        catch (Exception e)
        {
          exp = e;
        }
        finally
        {
          ControlDrawing.SystemParametersInfo(ControlDrawing.SPI_SETFONTSMOOTHING, 1, IntPtr.Zero, 0);
        }

        if (exp != null)
        {
          throw exp;
        }
      }
    }
  }

}
