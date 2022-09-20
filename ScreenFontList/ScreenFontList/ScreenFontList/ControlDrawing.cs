using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class ControlDrawing
  {
    public static UInt32 SPI_SETFONTSMOOTHING = 0x004B;

    
    [DllImport("user32.dll")]
    public static extern bool SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);
  }
}
