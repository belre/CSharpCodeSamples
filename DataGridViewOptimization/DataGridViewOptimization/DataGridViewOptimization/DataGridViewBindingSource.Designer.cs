namespace DataGridViewOptimization
{
  partial class DataGridViewBindingSource
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
      this.LabelStopWatch = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.ColumnContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.autoSizeModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.notSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.columnHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.allCellsExceptHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.allCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.displayCellsExceptHeaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.displayCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.fillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TableBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.CheckBoxVirtualMode = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.ColumnContextMenu.SuspendLayout();
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
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.dateTimeDataGridViewTextBoxColumn});
      this.dataGridView1.DataSource = this.TableBindingSource;
      this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGridView1.Location = new System.Drawing.Point(0, 0);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 21;
      this.dataGridView1.Size = new System.Drawing.Size(966, 586);
      this.dataGridView1.TabIndex = 5;
      this.dataGridView1.CellContextMenuStripChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContextMenuStripChanged);
      this.dataGridView1.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
      this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.CheckBoxVirtualMode);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(966, 72);
      this.panel1.TabIndex = 6;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.LabelStopWatch);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 658);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(966, 56);
      this.panel2.TabIndex = 7;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.dataGridView1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 72);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(966, 586);
      this.panel3.TabIndex = 8;
      // 
      // ColumnContextMenu
      // 
      this.ColumnContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeModeToolStripMenuItem});
      this.ColumnContextMenu.Name = "ColumnContextMenu";
      this.ColumnContextMenu.Size = new System.Drawing.Size(152, 26);
      this.ColumnContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ColumnContextMenu_Opening);
      // 
      // autoSizeModeToolStripMenuItem
      // 
      this.autoSizeModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notSetToolStripMenuItem,
            this.noneToolStripMenuItem,
            this.columnHeaderToolStripMenuItem,
            this.allCellsExceptHeaderToolStripMenuItem,
            this.allCellsToolStripMenuItem,
            this.displayCellsExceptHeaderToolStripMenuItem,
            this.displayCellsToolStripMenuItem,
            this.fillToolStripMenuItem});
      this.autoSizeModeToolStripMenuItem.Name = "autoSizeModeToolStripMenuItem";
      this.autoSizeModeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.autoSizeModeToolStripMenuItem.Text = "AutoSizeMode";
      // 
      // notSetToolStripMenuItem
      // 
      this.notSetToolStripMenuItem.Name = "notSetToolStripMenuItem";
      this.notSetToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.notSetToolStripMenuItem.Text = "NotSet";
      this.notSetToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // noneToolStripMenuItem
      // 
      this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
      this.noneToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.noneToolStripMenuItem.Text = "None";
      this.noneToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // columnHeaderToolStripMenuItem
      // 
      this.columnHeaderToolStripMenuItem.Name = "columnHeaderToolStripMenuItem";
      this.columnHeaderToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.columnHeaderToolStripMenuItem.Text = "ColumnHeader";
      this.columnHeaderToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // allCellsExceptHeaderToolStripMenuItem
      // 
      this.allCellsExceptHeaderToolStripMenuItem.Name = "allCellsExceptHeaderToolStripMenuItem";
      this.allCellsExceptHeaderToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.allCellsExceptHeaderToolStripMenuItem.Text = "AllCellsExceptHeader";
      this.allCellsExceptHeaderToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // allCellsToolStripMenuItem
      // 
      this.allCellsToolStripMenuItem.Name = "allCellsToolStripMenuItem";
      this.allCellsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.allCellsToolStripMenuItem.Text = "AllCells";
      this.allCellsToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // displayCellsExceptHeaderToolStripMenuItem
      // 
      this.displayCellsExceptHeaderToolStripMenuItem.Name = "displayCellsExceptHeaderToolStripMenuItem";
      this.displayCellsExceptHeaderToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.displayCellsExceptHeaderToolStripMenuItem.Text = "DisplayCellsExceptHeader";
      this.displayCellsExceptHeaderToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // displayCellsToolStripMenuItem
      // 
      this.displayCellsToolStripMenuItem.Name = "displayCellsToolStripMenuItem";
      this.displayCellsToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.displayCellsToolStripMenuItem.Text = "DisplayCells";
      this.displayCellsToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // fillToolStripMenuItem
      // 
      this.fillToolStripMenuItem.Name = "fillToolStripMenuItem";
      this.fillToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
      this.fillToolStripMenuItem.Text = "Fill";
      this.fillToolStripMenuItem.Click += new System.EventHandler(this.AutoSizeModeToolStripMenuItem_Click);
      // 
      // numberDataGridViewTextBoxColumn
      // 
      this.numberDataGridViewTextBoxColumn.ContextMenuStrip = this.ColumnContextMenu;
      this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
      this.numberDataGridViewTextBoxColumn.HeaderText = "Number";
      this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.ContextMenuStrip = this.ColumnContextMenu;
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      // 
      // dateTimeDataGridViewTextBoxColumn
      // 
      this.dateTimeDataGridViewTextBoxColumn.ContextMenuStrip = this.ColumnContextMenu;
      this.dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
      this.dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
      this.dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
      // 
      // TableBindingSource
      // 
      this.TableBindingSource.DataSource = typeof(DataGridViewOptimization.GridDataModel.SimpleDataLine);
      // 
      // CheckBoxVirtualMode
      // 
      this.CheckBoxVirtualMode.AutoSize = true;
      this.CheckBoxVirtualMode.Location = new System.Drawing.Point(146, 37);
      this.CheckBoxVirtualMode.Name = "CheckBoxVirtualMode";
      this.CheckBoxVirtualMode.Size = new System.Drawing.Size(89, 16);
      this.CheckBoxVirtualMode.TabIndex = 4;
      this.CheckBoxVirtualMode.Text = "Virtual Mode";
      this.CheckBoxVirtualMode.UseVisualStyleBackColor = true;
      // 
      // DataGridViewBindingSource
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(966, 714);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "DataGridViewBindingSource";
      this.Text = "DataGridViewBindingSource";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ColumnContextMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TableBindingSource)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label LabelStopWatch;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.BindingSource TableBindingSource;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ContextMenuStrip ColumnContextMenu;
    private System.Windows.Forms.ToolStripMenuItem autoSizeModeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem notSetToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem columnHeaderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem allCellsExceptHeaderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem allCellsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem displayCellsExceptHeaderToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem displayCellsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem fillToolStripMenuItem;
    private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
    private System.Windows.Forms.CheckBox CheckBoxVirtualMode;
  }
}