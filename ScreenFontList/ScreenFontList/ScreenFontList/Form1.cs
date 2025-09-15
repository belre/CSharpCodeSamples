using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenFontList.ctkpcmswcs.Native;

namespace ScreenFontList
{
  public partial class Form1 : Form
  {
    private bool _isLoadedFont = false;

    private IEnumerable<FontLoaderStrategy.FontLoadMode> _fontLoadModes = 
      new List<FontLoaderStrategy.FontLoadMode>()
    {
      FontLoaderStrategy.FontLoadMode.Gdi32,
      FontLoaderStrategy.FontLoadMode.GdiPlus
    };


    private IEnumerable<LogFontProxy> _logFontProxies = new List<LogFontProxy>();

    private IEnumerable<LogFontProxy> FilteredLogFont
    {
      get
      {
        var filterText = textBoxFilterFaceName.Text;
        var proxies = _logFontProxies;
        if (!string.IsNullOrEmpty(filterText))
        {
          proxies = proxies
            .Where(p => p.FaceName.Contains(filterText));
        }
        return proxies;
      }
    }

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      FontLoaderModeBindingSource.DataSource = _fontLoadModes;
      LoadFontList();
      UpdateFontList();
    }

    private void LoadFontList()
    {
      _isLoadedFont = false;

      var currentLoaderMode = (FontLoaderStrategy.FontLoadMode)FontLoaderModeBindingSource.Current;
      var strategy = new FontLoaderStrategy(currentLoaderMode);
      strategy.LoadFont();
      _logFontProxies = LogFontProxy
        .ConvertFrom(strategy.FontLoader);

      _isLoadedFont = true;

    }

    private void UpdateFontList()
    {
      if (FontLoaderModeBindingSource.Current == null)
        return;


      var filterText = textBoxFilterFaceName.Text;
      FontBindingSource.DataSource = FilteredLogFont;
    }




    private void button1_Click(object sender, EventArgs e)
    {
      var font_dialog = new FontDialog();
      font_dialog.AllowVerticalFonts = true;
      font_dialog.AllowVectorFonts = true;
      font_dialog.AllowSimulations = true;
      font_dialog.AllowScriptChange = true;
      font_dialog.FixedPitchOnly = false;
      font_dialog.ScriptsOnly = false;
      font_dialog.ShowDialog();
    }

    private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
      e.Cancel = true;
    }

    private void TriggerPreview(object sender, EventArgs e)
    {
      PreviewGdi32();
      PreviewDotnetGraphics();
    }

    private void PreviewGdi32()
    {
      if (!_isLoadedFont)        return;

      var bitmap = new Bitmap(gdi32Previewer.Width, gdi32Previewer.Height);
      if (CheckBoxNonSmooth.Checked)
      {
        TextOutGdi.PreviewOnNonSmoothingFont(() => MakeTextAsGdi32(bitmap));
      }
      else
      {
        MakeTextAsGdi32(bitmap);
      }

      gdi32Previewer.Image = bitmap;
    }

    private void PreviewDotnetGraphics()
    {
      if (!_isLoadedFont) return;

      var bitmap =DotnetGdiplusMarkingTextRenderer.MakeDefaultBitmap(
        graphicsPreviewer.Width, graphicsPreviewer.Height);
      MakeTextAsDotnetGraphics(bitmap);

      graphicsPreviewer.Image = bitmap;
    }

    private void MakeTextAsDotnetGraphics(Image bitmap)
    {
      var text = textBox1.Text;
      if (string.IsNullOrEmpty(text))
      {
        return;
      }

      var selectedLogFont = FontBindingSource.Current as LogFontProxy;
      if (selectedLogFont == null)
      {
        return;
      }

      var gdiPlusBitmap = new DotnetGdiplusMarkingTextRenderer();
      gdiPlusBitmap.Print(bitmap, text, selectedLogFont);

      using (var gr = Graphics.FromImage(bitmap))
      {
        var selectedManagedFont = selectedLogFont.ToFont();
        var renderAreas = gdiPlusBitmap.RenderLocation;
        var fixedMargins = gdiPlusBitmap.FixedMargin;
        float baselineY = gdiPlusBitmap.BaseLine;

        labelSizeGraphics.Text = string.Format("{0} x {1}", renderAreas.Width, renderAreas.Height);

        // 固定座標
        gr.DrawRectangle(new Pen(Brushes.Green), new Rectangle()
        {
          X = 0,
          Y = 0,
          Width = (int)Math.Round(fixedMargins.X),
          Height = (int)Math.Round(fixedMargins.Y) != 0 ? (int)Math.Round(fixedMargins.Y) : 50
        });

        gr.DrawRectangle(new Pen(Brushes.Red), new Rectangle()
        {
          X = (int)Math.Round(renderAreas.X),
          Y = (int)Math.Round(renderAreas.Y),
          Width = (int)Math.Round(renderAreas.Width),
          Height = (int)Math.Round(renderAreas.Height)
        });

        gr.DrawLine(new Pen(Brushes.Blue),
          new Point()
          {
            X = (int)renderAreas.X,
            Y = (int)baselineY
          },
          new Point()
          {
            X = (int)renderAreas.Width,
            Y = (int)baselineY
          });
      }
    }

    private void MakeTextAsGdi32(Image bitmap)
    {
      var text = textBox1.Text;
      if (string.IsNullOrEmpty(text))
      {
        return;
      }

      var selectedLogFont = FontBindingSource.Current as LogFontProxy;
      if (selectedLogFont == null)
      {
        return;
      }

      var gdiBitmap = new Gdi32MarkingTextRenderer();
      gdiBitmap.Print(bitmap, text, selectedLogFont);

      // 固定座標
      using( var gr = Graphics.FromImage(gdiBitmap.PictureBoxImage))
      {
        var renderLocation = gdiBitmap.RenderLocation;

        gr.DrawRectangle(new Pen(Brushes.Green), new Rectangle()
        {
          X = 0,
          Y = 0,
          Width = renderLocation.X,
          Height = renderLocation.Y
        });

        gr.DrawRectangle(new Pen(Brushes.Red), new Rectangle()
        {
          X = renderLocation.X,
          Y = renderLocation.Y,
          Width = renderLocation.Width,
          Height = renderLocation.Height
        });

        gr.DrawRectangle(new Pen(Brushes.Red), new Rectangle()
        {
          X = renderLocation.X,
          Y = renderLocation.Y,
          Width = renderLocation.Width,
          Height = renderLocation.Height / 2
        });
      }
    }

    private void comboBoxFontLoader_SelectedValueChanged(object sender, EventArgs e)
    {

    }

    private void comboBoxFontLoader_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void FontLoaderModeBindingSource_CurrentChanged(object sender, EventArgs e)
    {
      if (_isLoadedFont)
      {
        LoadFontList();
        UpdateFontList();
      }
    }

    private void textBoxFilterFaceName_TextChanged(object sender, EventArgs e)
    {
      UpdateFontList();
    }

    private void buttonBatchExport_Click(object sender, EventArgs e)
    {
      var dialog = new FolderBrowserDialog();
      if(dialog.ShowDialog() != DialogResult.OK) 
      {
        return;
      }

      var renderers = new IWinFontRenderer[]
      {
        new Gdi32MarkingTextRenderer(),
        new DotnetGdiplusMarkingTextRenderer()
      };

      int defaultWidth = 1000;
      int defaultHeight = 1000;

      var fontProxies = _logFontProxies.ToList();
      Task.Run(() =>
      {
        var filteredLogFontTmp = FilteredLogFont.ToList();
        var path = dialog.SelectedPath;
        foreach (var renderer in renderers)
        {
          foreach (var fontProxy in filteredLogFontTmp)
          {
            var bitmap = new Bitmap(defaultWidth, defaultHeight);
            renderer.Print(bitmap, textBox1.Text, fontProxy);

            var cropSize = renderer.RenderImageSize;
            var cropBitmap = new Bitmap(cropSize.Width, cropSize.Height);
            using(var g = Graphics.FromImage(cropBitmap))
            {
              g.DrawImage(bitmap,
                  new Rectangle(0, 0, cropSize.Width, cropSize.Height),
                  new Rectangle(0, 0, cropSize.Width, cropSize.Height),
                  GraphicsUnit.Pixel);
            }

            cropBitmap.Save(string.Format("{0}/{1}_{2}_{3}{4}", 
              path, 
              renderer.RenderMethod, 
              fontProxy.FaceName,
              fontProxy.CharSet.ToString(), ".png"));

            cropBitmap.Dispose();
            bitmap.Dispose();
          }
        }
      });


    }
  }
}
