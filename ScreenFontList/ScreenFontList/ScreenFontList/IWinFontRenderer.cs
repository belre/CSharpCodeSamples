using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public interface IWinFontRenderer
  {
    string RenderMethod { get; }
    void Print(System.Drawing.Image pictureBoxImage, string text, LogFontProxy logFontProxy);

    Rectangle RenderImageSize { get; }
  }
}
