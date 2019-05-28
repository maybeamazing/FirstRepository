namespace DataAcquisition
{
    partial class TorquePanel
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBox_Roll = new System.Windows.Forms.CheckBox();
            this.checkBox_Record = new System.Windows.Forms.CheckBox();
            this.btnClearListBox = new System.Windows.Forms.Button();
            this.btnStopAcquire = new System.Windows.Forms.Button();
            this.btnStartAcquire = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Aqua;
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Roll);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Record);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearListBox);
            this.splitContainer1.Panel1.Controls.Add(this.btnStopAcquire);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartAcquire);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(452, 553);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkBox_Roll
            // 
            this.checkBox_Roll.AutoSize = true;
            this.checkBox_Roll.Checked = true;
            this.checkBox_Roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Roll.Location = new System.Drawing.Point(321, 113);
            this.checkBox_Roll.Name = "checkBox_Roll";
            this.checkBox_Roll.Size = new System.Drawing.Size(59, 19);
            this.checkBox_Roll.TabIndex = 6;
            this.checkBox_Roll.Text = "滚动";
            this.checkBox_Roll.UseVisualStyleBackColor = true;
            // 
            // checkBox_Record
            // 
            this.checkBox_Record.AutoSize = true;
            this.checkBox_Record.Checked = true;
            this.checkBox_Record.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Record.Location = new System.Drawing.Point(236, 113);
            this.checkBox_Record.Name = "checkBox_Record";
            this.checkBox_Record.Size = new System.Drawing.Size(59, 19);
            this.checkBox_Record.TabIndex = 5;
            this.checkBox_Record.Text = "记录";
            this.checkBox_Record.UseVisualStyleBackColor = true;
            // 
            // btnClearListBox
            // 
            this.btnClearListBox.Location = new System.Drawing.Point(106, 104);
            this.btnClearListBox.Name = "btnClearListBox";
            this.btnClearListBox.Size = new System.Drawing.Size(93, 28);
            this.btnClearListBox.TabIndex = 4;
            this.btnClearListBox.Text = "清空";
            this.btnClearListBox.UseVisualStyleBackColor = true;
            this.btnClearListBox.Click += new System.EventHandler(this.btnClearListBox_Click);
            // 
            // btnStopAcquire
            // 
            this.btnStopAcquire.Location = new System.Drawing.Point(221, 32);
            this.btnStopAcquire.Name = "btnStopAcquire";
            this.btnStopAcquire.Size = new System.Drawing.Size(90, 31);
            this.btnStopAcquire.TabIndex = 3;
            this.btnStopAcquire.Text = "停止采集";
            this.btnStopAcquire.UseVisualStyleBackColor = true;
            this.btnStopAcquire.Click += new System.EventHandler(this.btnStopAcquire_Click);
            // 
            // btnStartAcquire
            // 
            this.btnStartAcquire.Location = new System.Drawing.Point(89, 32);
            this.btnStartAcquire.Name = "btnStartAcquire";
            this.btnStartAcquire.Size = new System.Drawing.Size(93, 31);
            this.btnStartAcquire.TabIndex = 2;
            this.btnStartAcquire.Text = "开始采集";
            this.btnStartAcquire.UseVisualStyleBackColor = true;
            this.btnStartAcquire.Click += new System.EventHandler(this.btnStartAcquire_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 362);
            this.panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(448, 364);
            this.listBox1.TabIndex = 0;
            // 
            // TorquePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 553);
            this.Controls.Add(this.splitContainer1);
            this.Name = "TorquePanel";
            this.Text = "TorquePanel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox_Roll;
        private System.Windows.Forms.CheckBox checkBox_Record;
        private System.Windows.Forms.Button btnClearListBox;
        private System.Windows.Forms.Button btnStopAcquire;
        private System.Windows.Forms.Button btnStartAcquire;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
    }
}