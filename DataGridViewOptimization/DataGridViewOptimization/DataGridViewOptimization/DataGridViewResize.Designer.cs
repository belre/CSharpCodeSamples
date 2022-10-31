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
      this.LabelStopWatch = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.CheckBoxResizeOptimized = new System.Windows.Forms.CheckBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.userDataGridViewControl1 = new DataGridViewOptimization.UserDataGridViewControl();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
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
      // panel1
      // 
      this.panel1.Controls.Add(this.CheckBoxResizeOptimized);
      this.panel1.Controls.Add(this.button1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(784, 72);
      this.panel1.TabIndex = 6;
      // 
      // CheckBoxResizeOptimized
      // 
      this.CheckBoxResizeOptimized.AutoSize = true;
      this.CheckBoxResizeOptimized.Location = new System.Drawing.Point(159, 37);
      this.CheckBoxResizeOptimized.Name = "CheckBoxResizeOptimized";
      this.CheckBoxResizeOptimized.Size = new System.Drawing.Size(151, 16);
      this.CheckBoxResizeOptimized.TabIndex = 4;
      this.CheckBoxResizeOptimized.Text = "リサイズ時の再描画を抑制";
      this.CheckBoxResizeOptimized.UseVisualStyleBackColor = true;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.LabelStopWatch);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 434);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(784, 56);
      this.panel2.TabIndex = 7;
      // 
      // userDataGridViewControl1
      // 
      this.userDataGridViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.userDataGridViewControl1.Lines = null;
      this.userDataGridViewControl1.Location = new System.Drawing.Point(0, 72);
      this.userDataGridViewControl1.Name = "userDataGridViewControl1";
      this.userDataGridViewControl1.Size = new System.Drawing.Size(784, 362);
      this.userDataGridViewControl1.TabIndex = 8;
      // 
      // DataGridViewResize
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(784, 490);
      this.Controls.Add(this.userDataGridViewControl1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "DataGridViewResize";
      this.Text = "DataGridViewResize";
      this.Load += new System.EventHandler(this.DataGridViewResize_Load);
      this.ResizeBegin += new System.EventHandler(this.DataGridViewResize_ResizeBegin);
      this.ResizeEnd += new System.EventHandler(this.DataGridViewResize_ResizeEnd);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label LabelStopWatch;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.CheckBox CheckBoxResizeOptimized;
    private UserDataGridViewControl userDataGridViewControl1;
  }
}