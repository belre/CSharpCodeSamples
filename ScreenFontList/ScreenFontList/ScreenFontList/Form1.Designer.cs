
namespace ScreenFontList
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.button1 = new System.Windows.Forms.Button();
      this.gdi_previewer = new System.Windows.Forms.DataGridView();
      this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.faceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.widthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.escapementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.orientationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.italicDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.underlineDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.strikeOutDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.charSetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.outPrecisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.clipPrecisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.qualityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pitchAndFamilyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FontBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gdi32Previewer = new System.Windows.Forms.PictureBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.CheckBoxNonSmooth = new System.Windows.Forms.CheckBox();
      this.label1 = new System.Windows.Forms.Label();
      this.graphicsPreviewer = new System.Windows.Forms.PictureBox();
      this.label2 = new System.Windows.Forms.Label();
      this.labelSizeGdi32 = new System.Windows.Forms.Label();
      this.labelSizeGraphics = new System.Windows.Forms.Label();
      this.comboBoxFontLoader = new System.Windows.Forms.ComboBox();
      this.FontLoaderModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.labelFontLoaderMode = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.textBoxFilterFaceName = new System.Windows.Forms.TextBox();
      this.buttonBatchExport = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.gdi_previewer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FontBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gdi32Previewer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewer)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.FontLoaderModeBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(23, 22);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(143, 47);
      this.button1.TabIndex = 1;
      this.button1.Text = "FontDialog";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // gdi_previewer
      // 
      this.gdi_previewer.AllowUserToAddRows = false;
      this.gdi_previewer.AllowUserToDeleteRows = false;
      this.gdi_previewer.AllowUserToResizeColumns = false;
      this.gdi_previewer.AllowUserToResizeRows = false;
      this.gdi_previewer.AutoGenerateColumns = false;
      this.gdi_previewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gdi_previewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.faceNameDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.widthDataGridViewTextBoxColumn,
            this.escapementDataGridViewTextBoxColumn,
            this.orientationDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.italicDataGridViewCheckBoxColumn,
            this.underlineDataGridViewCheckBoxColumn,
            this.strikeOutDataGridViewCheckBoxColumn,
            this.charSetDataGridViewTextBoxColumn,
            this.outPrecisionDataGridViewTextBoxColumn,
            this.clipPrecisionDataGridViewTextBoxColumn,
            this.qualityDataGridViewTextBoxColumn,
            this.pitchAndFamilyDataGridViewTextBoxColumn});
      this.gdi_previewer.DataSource = this.FontBindingSource;
      this.gdi_previewer.Location = new System.Drawing.Point(23, 172);
      this.gdi_previewer.Name = "gdi_previewer";
      this.gdi_previewer.RowTemplate.Height = 21;
      this.gdi_previewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gdi_previewer.Size = new System.Drawing.Size(1164, 394);
      this.gdi_previewer.TabIndex = 2;
      this.gdi_previewer.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
      // 
      // Column1
      // 
      this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.Column1.DataPropertyName = "FontName";
      this.Column1.HeaderText = "FontName";
      this.Column1.Name = "Column1";
      this.Column1.ReadOnly = true;
      this.Column1.Width = 101;
      // 
      // faceNameDataGridViewTextBoxColumn
      // 
      this.faceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.faceNameDataGridViewTextBoxColumn.DataPropertyName = "FaceName";
      this.faceNameDataGridViewTextBoxColumn.HeaderText = "FaceName";
      this.faceNameDataGridViewTextBoxColumn.Name = "faceNameDataGridViewTextBoxColumn";
      this.faceNameDataGridViewTextBoxColumn.ReadOnly = true;
      this.faceNameDataGridViewTextBoxColumn.Width = 103;
      // 
      // heightDataGridViewTextBoxColumn
      // 
      this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
      this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
      this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
      this.heightDataGridViewTextBoxColumn.ReadOnly = true;
      this.heightDataGridViewTextBoxColumn.Width = 75;
      // 
      // widthDataGridViewTextBoxColumn
      // 
      this.widthDataGridViewTextBoxColumn.DataPropertyName = "Width";
      this.widthDataGridViewTextBoxColumn.HeaderText = "Width";
      this.widthDataGridViewTextBoxColumn.Name = "widthDataGridViewTextBoxColumn";
      this.widthDataGridViewTextBoxColumn.ReadOnly = true;
      this.widthDataGridViewTextBoxColumn.Width = 70;
      // 
      // escapementDataGridViewTextBoxColumn
      // 
      this.escapementDataGridViewTextBoxColumn.DataPropertyName = "Escapement";
      this.escapementDataGridViewTextBoxColumn.HeaderText = "Escapement";
      this.escapementDataGridViewTextBoxColumn.Name = "escapementDataGridViewTextBoxColumn";
      this.escapementDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // orientationDataGridViewTextBoxColumn
      // 
      this.orientationDataGridViewTextBoxColumn.DataPropertyName = "Orientation";
      this.orientationDataGridViewTextBoxColumn.HeaderText = "Orientation";
      this.orientationDataGridViewTextBoxColumn.Name = "orientationDataGridViewTextBoxColumn";
      this.orientationDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // weightDataGridViewTextBoxColumn
      // 
      this.weightDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
      this.weightDataGridViewTextBoxColumn.HeaderText = "Weight";
      this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
      this.weightDataGridViewTextBoxColumn.ReadOnly = true;
      this.weightDataGridViewTextBoxColumn.Width = 76;
      // 
      // italicDataGridViewCheckBoxColumn
      // 
      this.italicDataGridViewCheckBoxColumn.DataPropertyName = "Italic";
      this.italicDataGridViewCheckBoxColumn.HeaderText = "Italic";
      this.italicDataGridViewCheckBoxColumn.Name = "italicDataGridViewCheckBoxColumn";
      this.italicDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // underlineDataGridViewCheckBoxColumn
      // 
      this.underlineDataGridViewCheckBoxColumn.DataPropertyName = "Underline";
      this.underlineDataGridViewCheckBoxColumn.HeaderText = "Underline";
      this.underlineDataGridViewCheckBoxColumn.Name = "underlineDataGridViewCheckBoxColumn";
      this.underlineDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // strikeOutDataGridViewCheckBoxColumn
      // 
      this.strikeOutDataGridViewCheckBoxColumn.DataPropertyName = "StrikeOut";
      this.strikeOutDataGridViewCheckBoxColumn.HeaderText = "StrikeOut";
      this.strikeOutDataGridViewCheckBoxColumn.Name = "strikeOutDataGridViewCheckBoxColumn";
      this.strikeOutDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // charSetDataGridViewTextBoxColumn
      // 
      this.charSetDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.charSetDataGridViewTextBoxColumn.DataPropertyName = "CharSet";
      this.charSetDataGridViewTextBoxColumn.HeaderText = "CharSet";
      this.charSetDataGridViewTextBoxColumn.Name = "charSetDataGridViewTextBoxColumn";
      this.charSetDataGridViewTextBoxColumn.ReadOnly = true;
      this.charSetDataGridViewTextBoxColumn.Width = 89;
      // 
      // outPrecisionDataGridViewTextBoxColumn
      // 
      this.outPrecisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.outPrecisionDataGridViewTextBoxColumn.DataPropertyName = "OutPrecision";
      this.outPrecisionDataGridViewTextBoxColumn.HeaderText = "OutPrecision";
      this.outPrecisionDataGridViewTextBoxColumn.Name = "outPrecisionDataGridViewTextBoxColumn";
      this.outPrecisionDataGridViewTextBoxColumn.ReadOnly = true;
      this.outPrecisionDataGridViewTextBoxColumn.Width = 118;
      // 
      // clipPrecisionDataGridViewTextBoxColumn
      // 
      this.clipPrecisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.clipPrecisionDataGridViewTextBoxColumn.DataPropertyName = "ClipPrecision";
      this.clipPrecisionDataGridViewTextBoxColumn.HeaderText = "ClipPrecision";
      this.clipPrecisionDataGridViewTextBoxColumn.Name = "clipPrecisionDataGridViewTextBoxColumn";
      this.clipPrecisionDataGridViewTextBoxColumn.ReadOnly = true;
      this.clipPrecisionDataGridViewTextBoxColumn.Width = 118;
      // 
      // qualityDataGridViewTextBoxColumn
      // 
      this.qualityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.qualityDataGridViewTextBoxColumn.DataPropertyName = "Quality";
      this.qualityDataGridViewTextBoxColumn.HeaderText = "Quality";
      this.qualityDataGridViewTextBoxColumn.Name = "qualityDataGridViewTextBoxColumn";
      this.qualityDataGridViewTextBoxColumn.ReadOnly = true;
      this.qualityDataGridViewTextBoxColumn.Width = 79;
      // 
      // pitchAndFamilyDataGridViewTextBoxColumn
      // 
      this.pitchAndFamilyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.pitchAndFamilyDataGridViewTextBoxColumn.DataPropertyName = "PitchAndFamily";
      this.pitchAndFamilyDataGridViewTextBoxColumn.HeaderText = "PitchAndFamily";
      this.pitchAndFamilyDataGridViewTextBoxColumn.Name = "pitchAndFamilyDataGridViewTextBoxColumn";
      this.pitchAndFamilyDataGridViewTextBoxColumn.ReadOnly = true;
      this.pitchAndFamilyDataGridViewTextBoxColumn.Width = 136;
      // 
      // FontBindingSource
      // 
      this.FontBindingSource.AllowNew = false;
      this.FontBindingSource.DataSource = typeof(ScreenFontList.LogFontProxy);
      this.FontBindingSource.CurrentChanged += new System.EventHandler(this.TriggerPreview);
      // 
      // gdi32Previewer
      // 
      this.gdi32Previewer.Location = new System.Drawing.Point(23, 624);
      this.gdi32Previewer.Name = "gdi32Previewer";
      this.gdi32Previewer.Size = new System.Drawing.Size(550, 116);
      this.gdi32Previewer.TabIndex = 3;
      this.gdi32Previewer.TabStop = false;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(23, 572);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(1150, 23);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "Hello";
      this.textBox1.TextChanged += new System.EventHandler(this.TriggerPreview);
      // 
      // CheckBoxNonSmooth
      // 
      this.CheckBoxNonSmooth.AutoSize = true;
      this.CheckBoxNonSmooth.Location = new System.Drawing.Point(23, 760);
      this.CheckBoxNonSmooth.Name = "CheckBoxNonSmooth";
      this.CheckBoxNonSmooth.Size = new System.Drawing.Size(130, 20);
      this.CheckBoxNonSmooth.TabIndex = 5;
      this.CheckBoxNonSmooth.Text = "Non-Smoothing";
      this.CheckBoxNonSmooth.UseVisualStyleBackColor = true;
      this.CheckBoxNonSmooth.CheckedChanged += new System.EventHandler(this.TriggerPreview);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(20, 605);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 16);
      this.label1.TabIndex = 6;
      this.label1.Text = "Gdi32";
      // 
      // graphicsPreviewer
      // 
      this.graphicsPreviewer.Location = new System.Drawing.Point(608, 624);
      this.graphicsPreviewer.Name = "graphicsPreviewer";
      this.graphicsPreviewer.Size = new System.Drawing.Size(550, 116);
      this.graphicsPreviewer.TabIndex = 7;
      this.graphicsPreviewer.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(605, 605);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(102, 16);
      this.label2.TabIndex = 8;
      this.label2.Text = ".NET Graphics";
      // 
      // labelSizeGdi32
      // 
      this.labelSizeGdi32.AutoSize = true;
      this.labelSizeGdi32.Location = new System.Drawing.Point(83, 605);
      this.labelSizeGdi32.Name = "labelSizeGdi32";
      this.labelSizeGdi32.Size = new System.Drawing.Size(70, 16);
      this.labelSizeGdi32.TabIndex = 9;
      this.labelSizeGdi32.Text = "sizeGdi32";
      // 
      // labelSizeGraphics
      // 
      this.labelSizeGraphics.AutoSize = true;
      this.labelSizeGraphics.Location = new System.Drawing.Point(733, 605);
      this.labelSizeGraphics.Name = "labelSizeGraphics";
      this.labelSizeGraphics.Size = new System.Drawing.Size(91, 16);
      this.labelSizeGraphics.TabIndex = 10;
      this.labelSizeGraphics.Text = "sizeGraphics";
      // 
      // comboBoxFontLoader
      // 
      this.comboBoxFontLoader.DataSource = this.FontLoaderModeBindingSource;
      this.comboBoxFontLoader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxFontLoader.FormattingEnabled = true;
      this.comboBoxFontLoader.Location = new System.Drawing.Point(362, 34);
      this.comboBoxFontLoader.Name = "comboBoxFontLoader";
      this.comboBoxFontLoader.Size = new System.Drawing.Size(200, 24);
      this.comboBoxFontLoader.TabIndex = 11;
      this.comboBoxFontLoader.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontLoader_SelectedIndexChanged);
      this.comboBoxFontLoader.SelectedValueChanged += new System.EventHandler(this.comboBoxFontLoader_SelectedValueChanged);
      // 
      // FontLoaderModeBindingSource
      // 
      this.FontLoaderModeBindingSource.DataSource = typeof(ScreenFontList.FontLoaderStrategy.FontLoadMode);
      this.FontLoaderModeBindingSource.CurrentChanged += new System.EventHandler(this.FontLoaderModeBindingSource_CurrentChanged);
      // 
      // labelFontLoaderMode
      // 
      this.labelFontLoaderMode.AutoSize = true;
      this.labelFontLoaderMode.Location = new System.Drawing.Point(206, 37);
      this.labelFontLoaderMode.Name = "labelFontLoaderMode";
      this.labelFontLoaderMode.Size = new System.Drawing.Size(131, 16);
      this.labelFontLoaderMode.TabIndex = 12;
      this.labelFontLoaderMode.Text = "Font Loader Mode";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(20, 101);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(121, 16);
      this.label3.TabIndex = 13;
      this.label3.Text = "Filter: FaceName";
      // 
      // textBoxFilterFaceName
      // 
      this.textBoxFilterFaceName.Location = new System.Drawing.Point(163, 98);
      this.textBoxFilterFaceName.Name = "textBoxFilterFaceName";
      this.textBoxFilterFaceName.Size = new System.Drawing.Size(260, 23);
      this.textBoxFilterFaceName.TabIndex = 14;
      this.textBoxFilterFaceName.TextChanged += new System.EventHandler(this.textBoxFilterFaceName_TextChanged);
      // 
      // buttonBatchExport
      // 
      this.buttonBatchExport.Location = new System.Drawing.Point(1025, 752);
      this.buttonBatchExport.Name = "buttonBatchExport";
      this.buttonBatchExport.Size = new System.Drawing.Size(133, 35);
      this.buttonBatchExport.TabIndex = 15;
      this.buttonBatchExport.Text = "Batch Export";
      this.buttonBatchExport.UseVisualStyleBackColor = true;
      this.buttonBatchExport.Click += new System.EventHandler(this.buttonBatchExport_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1248, 804);
      this.Controls.Add(this.buttonBatchExport);
      this.Controls.Add(this.textBoxFilterFaceName);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.labelFontLoaderMode);
      this.Controls.Add(this.comboBoxFontLoader);
      this.Controls.Add(this.labelSizeGraphics);
      this.Controls.Add(this.labelSizeGdi32);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.graphicsPreviewer);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CheckBoxNonSmooth);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.gdi32Previewer);
      this.Controls.Add(this.gdi_previewer);
      this.Controls.Add(this.button1);
      this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gdi_previewer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FontBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gdi32Previewer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.graphicsPreviewer)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.FontLoaderModeBindingSource)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.BindingSource FontBindingSource;
    private System.Windows.Forms.DataGridView gdi_previewer;
    private System.Windows.Forms.PictureBox gdi32Previewer;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.CheckBox CheckBoxNonSmooth;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox graphicsPreviewer;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label labelSizeGdi32;
    private System.Windows.Forms.Label labelSizeGraphics;
    private System.Windows.Forms.ComboBox comboBoxFontLoader;
    private System.Windows.Forms.Label labelFontLoaderMode;
    private System.Windows.Forms.BindingSource FontLoaderModeBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    private System.Windows.Forms.DataGridViewTextBoxColumn faceNameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn widthDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn escapementDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn orientationDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn italicDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn underlineDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewCheckBoxColumn strikeOutDataGridViewCheckBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn charSetDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn outPrecisionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn clipPrecisionDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn qualityDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn pitchAndFamilyDataGridViewTextBoxColumn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBoxFilterFaceName;
    private System.Windows.Forms.Button buttonBatchExport;
  }
}

