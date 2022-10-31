
namespace DataGridViewOptimization
{
  partial class UserDataGridViewControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.repaintOptimizedDataGridView1 = new DataGridViewOptimization.RepaintOptimizedDataGridView();
      this.TableBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.repaintOptimizedDataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // repaintOptimizedDataGridView1
      // 
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.repaintOptimizedDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.repaintOptimizedDataGridView1.AutoGenerateColumns = false;
      this.repaintOptimizedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.repaintOptimizedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn});
      this.repaintOptimizedDataGridView1.DataSource = this.TableBindingSource;
      this.repaintOptimizedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.repaintOptimizedDataGridView1.IsEnableBorderPaint = true;
      this.repaintOptimizedDataGridView1.Location = new System.Drawing.Point(0, 0);
      this.repaintOptimizedDataGridView1.Name = "repaintOptimizedDataGridView1";
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.repaintOptimizedDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.repaintOptimizedDataGridView1.RowTemplate.Height = 21;
      this.repaintOptimizedDataGridView1.Size = new System.Drawing.Size(978, 496);
      this.repaintOptimizedDataGridView1.TabIndex = 0;
      // 
      // TableBindingSource
      // 
      this.TableBindingSource.DataSource = typeof(DataGridViewOptimization.GridDataModel.SimpleDataLine);
      // 
      // numberDataGridViewTextBoxColumn
      // 
      this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
      this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
      this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
      this.numberDataGridViewTextBoxColumn.Width = 200;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      // 
      // dateTimeDataGridViewTextBoxColumn
      // 
      this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
      this.dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
      this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
      this.dateTimeDataGridViewTextBoxColumn.Width = 150;
      // 
      // UserDataGridViewControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.repaintOptimizedDataGridView1);
      this.Name = "UserDataGridViewControl";
      this.Size = new System.Drawing.Size(978, 496);
      ((System.ComponentModel.ISupportInitialize)(this.repaintOptimizedDataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private RepaintOptimizedDataGridView repaintOptimizedDataGridView1;
    private System.Windows.Forms.BindingSource TableBindingSource;
    private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
  }
}
