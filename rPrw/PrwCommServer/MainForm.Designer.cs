namespace PrwCommServer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_StartService = new System.Windows.Forms.Button();
            this.button_StopService = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkBox_ListBoxAutoRoll = new System.Windows.Forms.CheckBox();
            this.button_Settings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_ClearLog = new System.Windows.Forms.Button();
            this.CheckBox_UseLog = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel_ServiceStatus = new System.Windows.Forms.LinkLabel();
            this.listBox_Log = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_StartService
            // 
            this.button_StartService.Location = new System.Drawing.Point(17, 50);
            this.button_StartService.Margin = new System.Windows.Forms.Padding(4);
            this.button_StartService.Name = "button_StartService";
            this.button_StartService.Size = new System.Drawing.Size(135, 46);
            this.button_StartService.TabIndex = 0;
            this.button_StartService.Text = "开启服务";
            this.button_StartService.UseVisualStyleBackColor = true;
            this.button_StartService.Click += new System.EventHandler(this.button_StartService_Click);
            // 
            // button_StopService
            // 
            this.button_StopService.Location = new System.Drawing.Point(160, 50);
            this.button_StopService.Margin = new System.Windows.Forms.Padding(4);
            this.button_StopService.Name = "button_StopService";
            this.button_StopService.Size = new System.Drawing.Size(135, 46);
            this.button_StopService.TabIndex = 1;
            this.button_StopService.Text = "关闭服务";
            this.button_StopService.UseVisualStyleBackColor = true;
            this.button_StopService.Click += new System.EventHandler(this.button_StopService_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_ListBoxAutoRoll);
            this.splitContainer1.Panel1.Controls.Add(this.button_Settings);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button_ClearLog);
            this.splitContainer1.Panel1.Controls.Add(this.CheckBox_UseLog);
            this.splitContainer1.Panel1.Controls.Add(this.button_StartService);
            this.splitContainer1.Panel1.Controls.Add(this.button_StopService);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.linkLabel_ServiceStatus);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox_Log);
            this.splitContainer1.Size = new System.Drawing.Size(588, 489);
            this.splitContainer1.SplitterDistance = 114;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 4;
            // 
            // checkBox_ListBoxAutoRoll
            // 
            this.checkBox_ListBoxAutoRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_ListBoxAutoRoll.AutoSize = true;
            this.checkBox_ListBoxAutoRoll.Checked = true;
            this.checkBox_ListBoxAutoRoll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ListBoxAutoRoll.Location = new System.Drawing.Point(444, 118);
            this.checkBox_ListBoxAutoRoll.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_ListBoxAutoRoll.Name = "checkBox_ListBoxAutoRoll";
            this.checkBox_ListBoxAutoRoll.Size = new System.Drawing.Size(59, 19);
            this.checkBox_ListBoxAutoRoll.TabIndex = 8;
            this.checkBox_ListBoxAutoRoll.Text = "滚动";
            this.checkBox_ListBoxAutoRoll.UseVisualStyleBackColor = true;
            // 
            // button_Settings
            // 
            this.button_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Settings.Location = new System.Drawing.Point(511, 59);
            this.button_Settings.Margin = new System.Windows.Forms.Padding(4);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(65, 29);
            this.button_Settings.TabIndex = 7;
            this.button_Settings.Text = "设置";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.button_Settings_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "PrwCommServer V1.03";
            // 
            // button_ClearLog
            // 
            this.button_ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ClearLog.Location = new System.Drawing.Point(511, 112);
            this.button_ClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.button_ClearLog.Name = "button_ClearLog";
            this.button_ClearLog.Size = new System.Drawing.Size(65, 29);
            this.button_ClearLog.TabIndex = 5;
            this.button_ClearLog.Text = "清空";
            this.button_ClearLog.UseVisualStyleBackColor = true;
            this.button_ClearLog.Click += new System.EventHandler(this.button_ClearLog_Click);
            // 
            // CheckBox_UseLog
            // 
            this.CheckBox_UseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBox_UseLog.AutoSize = true;
            this.CheckBox_UseLog.Checked = true;
            this.CheckBox_UseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_UseLog.Location = new System.Drawing.Point(372, 118);
            this.CheckBox_UseLog.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox_UseLog.Name = "CheckBox_UseLog";
            this.CheckBox_UseLog.Size = new System.Drawing.Size(59, 19);
            this.CheckBox_UseLog.TabIndex = 4;
            this.CheckBox_UseLog.Text = "日志";
            this.CheckBox_UseLog.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "服务状态：";
            // 
            // linkLabel_ServiceStatus
            // 
            this.linkLabel_ServiceStatus.AutoSize = true;
            this.linkLabel_ServiceStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_ServiceStatus.Location = new System.Drawing.Point(133, 18);
            this.linkLabel_ServiceStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel_ServiceStatus.Name = "linkLabel_ServiceStatus";
            this.linkLabel_ServiceStatus.Size = new System.Drawing.Size(129, 20);
            this.linkLabel_ServiceStatus.TabIndex = 2;
            this.linkLabel_ServiceStatus.TabStop = true;
            this.linkLabel_ServiceStatus.Text = "服务准备就绪";
            this.linkLabel_ServiceStatus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ServiceStatus_LinkClicked);
            // 
            // listBox_Log
            // 
            this.listBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Log.FormattingEnabled = true;
            this.listBox_Log.ItemHeight = 15;
            this.listBox_Log.Location = new System.Drawing.Point(0, 0);
            this.listBox_Log.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Log.Name = "listBox_Log";
            this.listBox_Log.Size = new System.Drawing.Size(588, 370);
            this.listBox_Log.TabIndex = 0;
            this.listBox_Log.DoubleClick += new System.EventHandler(this.listBox_Log_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 489);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "PrwCommServer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_StartService;
        private System.Windows.Forms.Button button_StopService;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox_Log;
        private System.Windows.Forms.Button button_ClearLog;
        private System.Windows.Forms.CheckBox CheckBox_UseLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Settings;
        private System.Windows.Forms.CheckBox checkBox_ListBoxAutoRoll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel_ServiceStatus;
    }
}

