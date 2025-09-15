using ScreenFontList.ctkpcmswcs.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenFontList
{
  public class Gdi32MarkingTextRenderer : IDisposable, IWinFontRenderer
  {
    public string RenderMethod => "Gdi32";

    private System.Drawing.Image _pictureBoxImage;

    public System.Drawing.Image PictureBoxImage => _pictureBoxImage;

    private Rectangle _renderLocation;

    public Rectangle RenderLocation => _renderLocation;

    public int MarginXForCorrection => 10;
    public int MarginYForCorrection => 10;

    public Rectangle RenderImageSize => new Rectangle()
    {
      Width = MarginXForCorrection + _renderLocation.Width,
      Height = MarginYForCorrection + _renderLocation.Height
    };

    public void Dispose()
    {

    }

    private ImageAttributes GetTransparentColorMap()
    {
      //ColorMapオブジェクトの配列（カラーリマップテーブル）を作成
      var cms = new System.Drawing.Imaging.ColorMap[] {
        new System.Drawing.Imaging.ColorMap(),
        new System.Drawing.Imaging.ColorMap()
      };

      //青を黒に変換する
      cms[0].OldColor = Color.White;
      cms[0].NewColor = Color.Transparent;

      //ImageAttributesオブジェクトの作成
      var ia = new System.Drawing.Imaging.ImageAttributes();
      //ColorMapを設定
      ia.SetRemapTable(cms);

      return ia;
    }

    private int CalculateRawOffset(int x, int y, int stride)
    {
      return y * stride + x * 4;
    }

    private Rectangle AnalyzeRenderingArea(Bitmap convBitmap)
    {
      // 幅高さの計算
      // GetPixelは遅いので、LockBitsを使用
      var bitmapData = convBitmap.LockBits(
        new Rectangle(0, 0, _pictureBoxImage.Width, _pictureBoxImage.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

      int width = bitmapData.Width;
      int height = bitmapData.Height;
      int stride = bitmapData.Stride;

      byte[] rgbValues = new byte[Math.Abs(stride) * height];
      Marshal.Copy(bitmapData.Scan0, rgbValues, 0, Math.Abs(stride) * height);

      int transparentWidth = -1;
      int transparentHeight = -1;
      for (int y = 0; y < height; y++)
      {
        int offset = CalculateRawOffset(0, y, stride);
        if (rgbValues[offset + 3] == 0)
        {
          transparentHeight = y;
          break;
        }
      }
      for (int x = 0; x < width; x++)
      {
        int offset = CalculateRawOffset(x, 0, stride);
        if (rgbValues[offset + 3] == 0)
        {
          transparentWidth = x;
          break;
        }
      }
      convBitmap.UnlockBits(bitmapData);

      return new Rectangle()
      {
        Width = transparentWidth,
        Height = transparentHeight
      };
    }

    public void Print(System.Drawing.Image pictureBoxImage, string text, LogFontProxy logFontProxy)
    {
      if (string.IsNullOrEmpty(text))
      {
        return;
      }

      if (logFontProxy == null)
      {
        return;
      }

      if (pictureBoxImage == null)
        throw new InvalidOperationException("Picturebox bitmap is not preserved");

      _pictureBoxImage = pictureBoxImage;

      Color color = Color.Black;
      var convBitmap = new Bitmap(_pictureBoxImage.Width, _pictureBoxImage.Height);
      using (var gr = Graphics.FromImage(convBitmap))
      {
        gr.InterpolationMode = InterpolationMode.Bilinear;

        if (text != null)
        {
          IntPtr hDC = gr.GetHdc();

          var log_font = logFontProxy.RawLogFont;
          log_font.lfQuality = Gdi32FontItem.FontQuality.NONANTIALIASED_QUALITY;


          var hFont_2 = TextOutGdi.CreateFontIndirect(log_font);

          IntPtr hOldFont = TextOutGdi.SelectObject(hDC, hFont_2);

          // 文字色の設定
          var color_flag = (int)(color.R + (color.G << 8) + (color.B << 16));
          TextOutGdi.SetTextColor(hDC, color_flag);

          // TextOut
          var encoding = Encoding.GetEncoding("shift-jis");
          //var shift_jis_encoding = Encoding.GetEncoding("shift-jis");
          TextOutGdi.TextOut(hDC, 0, 0, text, encoding.GetByteCount(text));
          TextOutGdi.DeleteObject(TextOutGdi.SelectObject(hDC, hOldFont));
          gr.ReleaseHdc(hDC);
        }
      }

      // 幅高さの計算
      // GetPixelは遅いので、LockBitsを使用
      var renderedAreaSize = AnalyzeRenderingArea(convBitmap);

      // 背景白を透明化して処理する
      int margin = 10;
      using (Graphics gr = Graphics.FromImage(_pictureBoxImage))
      {
        gr.InterpolationMode = InterpolationMode.NearestNeighbor;
        gr.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;

        // 印字するときに余白を開けて描画する
        gr.DrawImage(convBitmap, 
          new Rectangle(MarginXForCorrection, MarginYForCorrection, 
          _pictureBoxImage.Width, _pictureBoxImage.Height),
          0, 0, _pictureBoxImage.Width, _pictureBoxImage.Height, 
          GraphicsUnit.Pixel, GetTransparentColorMap());
      }

      _renderLocation = new Rectangle()
      {
        X = margin,
        Y = margin,
        Width = renderedAreaSize.Width,
        Height = renderedAreaSize.Height
      };

      convBitmap.Dispose();
    }
  }
}
