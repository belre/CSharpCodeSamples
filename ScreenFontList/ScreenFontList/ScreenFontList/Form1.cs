using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenFontList.ctkpcmswcs.Native;

namespace ScreenFontList
{
  public partial class Form1 : Form
  {
    private bool _is_loaded = false;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      _is_loaded = false;

      var screen_font_table = new ScreenFontTable();
      screen_font_table.LoadFont();

      LogFontBindingSource.DataSource = screen_font_table.LogFontList.Select(c => new LogFontWrapped(c));

      _is_loaded = true;
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
      PreviewImage();
    }

    private void PreviewImage()
    {
      if (_is_loaded)
      {
        var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        if (CheckBoxNonSmooth.Checked)
        {
          TextOutGdi.PreviewOnNonSmoothingFont(() => PreviewText(bitmap));
        }
        else
        {
          PreviewText(bitmap);
        }

        pictureBox1.Image = bitmap;
      }
    }

    private void PreviewText(Image bitmap)
    {
      var selected_log_font = (LogFontWrapped)LogFontBindingSource.Current;
      var text = textBox1.Text;
      Color color = Color.Black;

      if (string.IsNullOrEmpty(text))
      {
        return;
      }

      //ImageAttributesオブジェクトの作成
      var ia = new System.Drawing.Imaging.ImageAttributes();

      using (var gr = Graphics.FromImage(bitmap))
      {
        gr.InterpolationMode = InterpolationMode.Bilinear;

        if (text != null)
        {
          IntPtr hDC = gr.GetHdc();

          var log_font = selected_log_font.RawLogFont;
          var hFont_2 = TextOutGdi.CreateFontIndirect(log_font);

          IntPtr hOldFont = TextOutGdi.SelectObject(hDC, hFont_2);

          // 文字色の設定
          var color_flag = (int)(color.R + (color.G << 8) + (color.B << 16));
          TextOutGdi.SetTextColor(hDC, color_flag);

          // TextOut
          var shift_jis_encoding = Encoding.GetEncoding("shift-jis");
          TextOutGdi.TextOut(hDC, 0, 0, text, shift_jis_encoding.GetByteCount(text));
          TextOutGdi.DeleteObject(TextOutGdi.SelectObject(hDC, hOldFont));
          gr.ReleaseHdc(hDC);

          gr.DrawImage(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
        }
      }
    }
  }
}
