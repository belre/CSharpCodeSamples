namespace DataGridViewOptimization
{
  partial class DataGridViewResize
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.LabelStopWatch = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.dataGridView1 = new UserDataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.CheckBoxDisableAutoBind = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TableBindingSource = new System.Windows.Forms.BindingSource(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // LabelStopWatch
      // 
      this.LabelStopWatch.AutoSize = true;
      this.LabelStopWatch.Location = new System.Drawing.Point(17, 18);
      this.LabelStopWatch.Name = "LabelStopWatch";
      this.LabelStopWatch.Size = new System.Drawing.Size(35, 12);
      this.LabelStopWatch.TabIndex = 4;
      this.LabelStopWatch.Text = "label1";
      this.LabelStopWatch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LabelStopWatch_MouseClick);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(19, 31);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 3;
      this.button1.Text = "表示開始";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // dataGridView1
      // 
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.TableBindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.dataGridView1.RowTemplate.Height = 35;
      this.dataGridView1.Size = new System.Drawing.Size(784, 633);
      this.dataGridView1.TabIndex = 5;
      this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.CheckBoxDisableAutoBind);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(784, 72);
      this.panel1.TabIndex = 6;
      // 
      // CheckBoxDisableAutoBind
      // 
      this.CheckBoxDisableAutoBind.AutoSize = true;
      this.CheckBoxDisableAutoBind.Location = new System.Drawing.Point(159, 37);
      this.CheckBoxDisableAutoBind.Name = "CheckBoxDisableAutoBind";
      this.CheckBoxDisableAutoBind.Size = new System.Drawing.Size(140, 16);
      this.CheckBoxDisableAutoBind.TabIndex = 4;
      this.CheckBoxDisableAutoBind.Text = "自動的なバインドを抑制";
      this.CheckBoxDisableAutoBind.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.LabelStopWatch);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 705);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(784, 56);
      this.panel2.TabIndex = 7;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.dataGridView1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 72);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(784, 633);
      this.panel3.TabIndex = 8;
      // 
      // numberDataGridViewTextBoxColumn
      // 
      this.numberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
      this.numberDataGridViewTextBoxColumn.HeaderText = "*****************Number*****************";
      this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
      this.numberDataGridViewTextBoxColumn.Width = 273;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "*****************Name*****************";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.Width = 263;
      // 
      // dateTimeDataGridViewTextBoxColumn
      // 
      this.dateTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
      this.dateTimeDataGridViewTextBoxColumn.HeaderText = "*****************DateTime*****************";
      this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
      // 
      // TableBindingSource
      // 
      this.TableBindingSource.DataSource = typeof(DataGridViewOptimization.GridDataModel.SimpleDataLine);
      // 
      // DataGridViewUpdate
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(784, 761);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "DataGridViewResize";
      this.Text = "DataGridViewBindingSource";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label LabelStopWatch;
    private System.Windows.Forms.Button button1;
    private UserDataGridView dataGridView1;
    private System.Windows.Forms.BindingSource TableBindingSource;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.CheckBox CheckBoxDisableAutoBind;
    private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
  }
}