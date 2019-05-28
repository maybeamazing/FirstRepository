namespace DataAcquisition
{
    partial class MitsubishiFX3uPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.IpAddr = new System.Windows.Forms.TextBox();
            this.btnClearListBox = new System.Windows.Forms.Button();
            this.btnStopAcquire = new System.Windows.Forms.Button();
            this.btnStartAcquire = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Roll);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_Record);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.Port);
            this.splitContainer1.Panel1.Controls.Add(this.IpAddr);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearListBox);
            this.splitContainer1.Panel1.Controls.Add(this.btnStopAcquire);
            this.splitContainer1.Panel1.Controls.Add(this.btnStartAcquire);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(339, 442);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // checkBox_Roll
            // 
            this.checkBox_Roll.AutoSize = true;
            this.checkBox_Roll.Checked = true;
            this.checkBox_Roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Roll.Location = new System.Drawing.Point(290, 122);
            this.checkBox_Roll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_Roll.Name = "checkBox_Roll";
            this.checkBox_Roll.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Roll.TabIndex = 8;
            this.checkBox_Roll.Text = "滚动";
            this.checkBox_Roll.UseVisualStyleBackColor = true;
            // 
            // checkBox_Record
            // 
            this.checkBox_Record.AutoSize = true;
            this.checkBox_Record.Checked = true;
            this.checkBox_Record.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Record.Location = new System.Drawing.Point(231, 122);
            this.checkBox_Record.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_Record.Name = "checkBox_Record";
            this.checkBox_Record.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Record.TabIndex = 7;
            this.checkBox_Record.Text = "记录";
            this.checkBox_Record.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "端口";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "IP";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(200, 18);
            this.Port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(76, 21);
            this.Port.TabIndex = 4;
            // 
            // IpAddr
            // 
            this.IpAddr.Location = new System.Drawing.Point(59, 23);
            this.IpAddr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IpAddr.Name = "IpAddr";
            this.IpAddr.Size = new System.Drawing.Size(76, 21);
            this.IpAddr.TabIndex = 3;
            // 
            // btnClearListBox
            // 
            this.btnClearListBox.Location = new System.Drawing.Point(148, 116);
            this.btnClearListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClearListBox.Name = "btnClearListBox";
            this.btnClearListBox.Size = new System.Drawing.Size(68, 24);
            this.btnClearListBox.TabIndex = 2;
            this.btnClearListBox.Text = "清空";
            this.btnClearListBox.UseVisualStyleBackColor = true;
            this.btnClearListBox.Click += new System.EventHandler(this.btnClearListBox_Click);
            // 
            // btnStopAcquire
            // 
            this.btnStopAcquire.Location = new System.Drawing.Point(182, 68);
            this.btnStopAcquire.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStopAcquire.Name = "btnStopAcquire";
            this.btnStopAcquire.Size = new System.Drawing.Size(62, 27);
            this.btnStopAcquire.TabIndex = 1;
            this.btnStopAcquire.Text = "停止采集";
            this.btnStopAcquire.UseVisualStyleBackColor = true;
            this.btnStopAcquire.Click += new System.EventHandler(this.btnStopAcquire_Click);
            // 
            // btnStartAcquire
            // 
            this.btnStartAcquire.Location = new System.Drawing.Point(63, 68);
            this.btnStartAcquire.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartAcquire.Name = "btnStartAcquire";
            this.btnStartAcquire.Size = new System.Drawing.Size(71, 27);
            this.btnStartAcquire.TabIndex = 0;
            this.btnStartAcquire.Text = "开始采集";
            this.btnStartAcquire.UseVisualStyleBackColor = true;
            this.btnStartAcquire.Click += new System.EventHandler(this.btnStartAcquire_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(3, 3);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(337, 292);
            this.listBox1.TabIndex = 0;
            // 
            // MitsubishiFX3uPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 442);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MitsubishiFX3uPanel";
            this.Text = "MitsubishiFX3uPanel";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox_Roll;
        private System.Windows.Forms.CheckBox checkBox_Record;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Port;
        public System.Windows.Forms.TextBox IpAddr;
        private System.Windows.Forms.Button btnClearListBox;
        private System.Windows.Forms.Button btnStopAcquire;
        private System.Windows.Forms.Button btnStartAcquire;
        private System.Windows.Forms.ListBox listBox1;
    }
}