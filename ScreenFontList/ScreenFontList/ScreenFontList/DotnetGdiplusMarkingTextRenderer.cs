using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class DotnetGdiplusMarkingTextRenderer : IWinFontRenderer
  {
    public string RenderMethod => "DotnetGdiplus";


    private System.Drawing.Image _pictureBoxImage;

    public System.Drawing.Image PictureBoxImage => _pictureBoxImage;

    private RectangleF _renderLocation;
    public RectangleF RenderLocation => _renderLocation;

    private float _baseLine;
    public float BaseLine => _baseLine;

    private RectangleF _fixedMargin;
    public RectangleF FixedMargin => _fixedMargin;


    public Rectangle RenderImageSize => new Rectangle()
    {
      Width = (int)Math.Ceiling(_fixedMargin.X + _renderLocation.Width),
      Height = (int)Math.Ceiling(_fixedMargin.Y + _renderLocation.Height)
    };

    // https://stackoverflow.com/questions/2133411/using-gdi-whats-the-easiest-approach-to-align-text-drawn-in-several-differen
    private float CalculateBaseline(Font font, float drawY)
    {
      FontFamily family = font.FontFamily;
      float emHeight = family.GetEmHeight(font.Style);
      float ascent = family.GetCellAscent(font.Style) * font.Size / emHeight;

      // drawYから描画される位置のベースライン位置
      return drawY + ascent;
    }
    private StringFormat GetRenderStringFormat()
    {
      StringFormat format = new StringFormat();
      // ベースライン描画のための設定
      format.LineAlignment = StringAlignment.Near;  // 垂直方向は上詰め（後で手動調整）
      format.Alignment = StringAlignment.Near;      // 水平方向は左詰め
      format.FormatFlags = StringFormatFlags.MeasureTrailingSpaces |
                          StringFormatFlags.NoWrap |
                          StringFormatFlags.FitBlackBox;  // 余白を最小化

      return format;
    }


    // 文字の実際の境界ボックスを取得
    private Region GetCharacterBounds(string text, Font font, Graphics graphics)
    {
      // CharacterRangeを使って正確な境界を取得
      CharacterRange[] ranges = new[] { new CharacterRange(0, text.Length) };
      var format = GetRenderStringFormat();
      //format.Alignment = StringAlignment.Near;      // 左詰め
      format.SetMeasurableCharacterRanges(ranges);

      RectangleF layoutRect = new RectangleF(0, 0, 1000, 1000);
      Region[] regions = graphics.MeasureCharacterRanges(text, font, layoutRect, format);

      return regions[0];
    }

    public void Print(System.Drawing.Image pictureBoxImage, string text, LogFontProxy logFontProxy)
    {
      _pictureBoxImage = pictureBoxImage;

      using (var gr = Graphics.FromImage(_pictureBoxImage))
      {
        var selectedManagedFont = logFontProxy.ToFont();

        gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit; // GDI32に近い
        gr.DrawString(text, selectedManagedFont, Brushes.Black, new PointF(0, 0), GetRenderStringFormat());

        _renderLocation = GetCharacterBounds(text, selectedManagedFont, gr).GetBounds(gr);
        _baseLine = CalculateBaseline(selectedManagedFont, 0);
        _fixedMargin = GetCharacterBounds("M", selectedManagedFont, gr).GetBounds(gr);
      }
    }

    public static Bitmap MakeDefaultBitmap(int width, int height)
    {
      var bitmap = new Bitmap(width, height);
      bitmap.SetResolution(96f, 96f);
      return bitmap;
    }
  }
}
