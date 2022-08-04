
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
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.LogFontBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
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
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LogFontBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
      // dataGridView1
      // 
      this.dataGridView1.AllowUserToAddRows = false;
      this.dataGridView1.AllowUserToDeleteRows = false;
      this.dataGridView1.AllowUserToResizeColumns = false;
      this.dataGridView1.AllowUserToResizeRows = false;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
      this.dataGridView1.DataSource = this.LogFontBindingSource;
      this.dataGridView1.Location = new System.Drawing.Point(23, 85);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 21;
      this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dataGridView1.Size = new System.Drawing.Size(1164, 394);
      this.dataGridView1.TabIndex = 2;
      this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
      // 
      // LogFontBindingSource
      // 
      this.LogFontBindingSource.AllowNew = false;
      this.LogFontBindingSource.DataSource = typeof(ScreenFontList.LogFontWrapped);
      this.LogFontBindingSource.CurrentChanged += new System.EventHandler(this.TriggerPreview);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(23, 573);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(1164, 152);
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(23, 516);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(1150, 23);
      this.textBox1.TabIndex = 4;
      this.textBox1.Text = "Hello";
      this.textBox1.TextChanged += new System.EventHandler(this.TriggerPreview);
      // 
      // faceNameDataGridViewTextBoxColumn
      // 
      this.faceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.faceNameDataGridViewTextBoxColumn.DataPropertyName = "FaceName";
      this.faceNameDataGridViewTextBoxColumn.HeaderText = "FaceName";
      this.faceNameDataGridViewTextBoxColumn.Name = "faceNameDataGridViewTextBoxColumn";
      this.faceNameDataGridViewTextBoxColumn.ReadOnly = true;
      this.faceNameDataGridViewTextBoxColumn.Width = 104;
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
      this.weightDataGridViewTextBoxColumn.Width = 77;
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
      this.charSetDataGridViewTextBoxColumn.Width = 90;
      // 
      // outPrecisionDataGridViewTextBoxColumn
      // 
      this.outPrecisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.outPrecisionDataGridViewTextBoxColumn.DataPropertyName = "OutPrecision";
      this.outPrecisionDataGridViewTextBoxColumn.HeaderText = "OutPrecision";
      this.outPrecisionDataGridViewTextBoxColumn.Name = "outPrecisionDataGridViewTextBoxColumn";
      this.outPrecisionDataGridViewTextBoxColumn.ReadOnly = true;
      this.outPrecisionDataGridViewTextBoxColumn.Width = 119;
      // 
      // clipPrecisionDataGridViewTextBoxColumn
      // 
      this.clipPrecisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.clipPrecisionDataGridViewTextBoxColumn.DataPropertyName = "ClipPrecision";
      this.clipPrecisionDataGridViewTextBoxColumn.HeaderText = "ClipPrecision";
      this.clipPrecisionDataGridViewTextBoxColumn.Name = "clipPrecisionDataGridViewTextBoxColumn";
      this.clipPrecisionDataGridViewTextBoxColumn.ReadOnly = true;
      this.clipPrecisionDataGridViewTextBoxColumn.Width = 119;
      // 
      // qualityDataGridViewTextBoxColumn
      // 
      this.qualityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.qualityDataGridViewTextBoxColumn.DataPropertyName = "Quality";
      this.qualityDataGridViewTextBoxColumn.HeaderText = "Quality";
      this.qualityDataGridViewTextBoxColumn.Name = "qualityDataGridViewTextBoxColumn";
      this.qualityDataGridViewTextBoxColumn.ReadOnly = true;
      this.qualityDataGridViewTextBoxColumn.Width = 80;
      // 
      // pitchAndFamilyDataGridViewTextBoxColumn
      // 
      this.pitchAndFamilyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.pitchAndFamilyDataGridViewTextBoxColumn.DataPropertyName = "PitchAndFamily";
      this.pitchAndFamilyDataGridViewTextBoxColumn.HeaderText = "PitchAndFamily";
      this.pitchAndFamilyDataGridViewTextBoxColumn.Name = "pitchAndFamilyDataGridViewTextBoxColumn";
      this.pitchAndFamilyDataGridViewTextBoxColumn.ReadOnly = true;
      this.pitchAndFamilyDataGridViewTextBoxColumn.Width = 137;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1243, 737);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.button1);
      this.Font = new System.Drawing.Font("MS UI Gothic", 12F);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LogFontBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.BindingSource LogFontBindingSource;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TextBox textBox1;
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
  }
}

