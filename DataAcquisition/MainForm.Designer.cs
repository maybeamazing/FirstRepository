namespace DataAcquisition
{
    partial class MainForm
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
            this.mainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddOmron501DataAquision = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnAddSiemens1200DataAquision = new System.Windows.Forms.Button();
            this.btnAddMitsubishiFX3uDataAquision = new System.Windows.Forms.Button();
            this.btnAddSiemens200DataAquision = new System.Windows.Forms.Button();
            this.btnAddEnergyConsumptionAquision = new System.Windows.Forms.Button();
            this.btnAddTorqueAquision = new System.Windows.Forms.Button();
            this.btnAddLabviewAquision = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainFlowLayoutPanel
            // 
            this.mainFlowLayoutPanel.AutoScroll = true;
            this.mainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            this.mainFlowLayoutPanel.Size = new System.Drawing.Size(1456, 488);
            this.mainFlowLayoutPanel.TabIndex = 0;
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
            this.splitContainer1.Panel1.BackgroundImage = global::DataAcquisition.Properties.Resources._1411450549371709000;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mainFlowLayoutPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1456, 642);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1452, 144);
            this.panel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnAddOmron501DataAquision, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddSiemens1200DataAquision, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddMitsubishiFX3uDataAquision, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddSiemens200DataAquision, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddEnergyConsumptionAquision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStartAll, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddTorqueAquision, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAddLabviewAquision, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1450, 141);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnAddOmron501DataAquision
            // 
            this.btnAddOmron501DataAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddOmron501DataAquision.Location = new System.Drawing.Point(1014, 3);
            this.btnAddOmron501DataAquision.Name = "btnAddOmron501DataAquision";
            this.btnAddOmron501DataAquision.Size = new System.Drawing.Size(147, 29);
            this.btnAddOmron501DataAquision.TabIndex = 1;
            this.btnAddOmron501DataAquision.Text = "添加欧姆龙501PLC";
            this.btnAddOmron501DataAquision.UseVisualStyleBackColor = true;
            this.btnAddOmron501DataAquision.Click += new System.EventHandler(this.btnAddOmron501DataAquision_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStartAll.Location = new System.Drawing.Point(1014, 109);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(147, 29);
            this.btnStartAll.TabIndex = 3;
            this.btnStartAll.Text = "全部开始";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // btnAddSiemens1200DataAquision
            // 
            this.btnAddSiemens1200DataAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSiemens1200DataAquision.Location = new System.Drawing.Point(289, 38);
            this.btnAddSiemens1200DataAquision.Name = "btnAddSiemens1200DataAquision";
            this.btnAddSiemens1200DataAquision.Size = new System.Drawing.Size(147, 37);
            this.btnAddSiemens1200DataAquision.TabIndex = 4;
            this.btnAddSiemens1200DataAquision.Text = "添加西门子S17200";
            this.btnAddSiemens1200DataAquision.UseVisualStyleBackColor = true;
            this.btnAddSiemens1200DataAquision.Click += new System.EventHandler(this.btnAddSiemens1200DataAquision_Click);
            // 
            // btnAddMitsubishiFX3uDataAquision
            // 
            this.btnAddMitsubishiFX3uDataAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddMitsubishiFX3uDataAquision.Location = new System.Drawing.Point(289, 3);
            this.btnAddMitsubishiFX3uDataAquision.Name = "btnAddMitsubishiFX3uDataAquision";
            this.btnAddMitsubishiFX3uDataAquision.Size = new System.Drawing.Size(147, 29);
            this.btnAddMitsubishiFX3uDataAquision.TabIndex = 0;
            this.btnAddMitsubishiFX3uDataAquision.Text = "添加三菱FX3uPLC";
            this.btnAddMitsubishiFX3uDataAquision.UseVisualStyleBackColor = true;
            this.btnAddMitsubishiFX3uDataAquision.Click += new System.EventHandler(this.btnAddMitsubishiFX3uDataAquision_Click);
            // 
            // btnAddSiemens200DataAquision
            // 
            this.btnAddSiemens200DataAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddSiemens200DataAquision.Location = new System.Drawing.Point(1014, 38);
            this.btnAddSiemens200DataAquision.Name = "btnAddSiemens200DataAquision";
            this.btnAddSiemens200DataAquision.Size = new System.Drawing.Size(147, 37);
            this.btnAddSiemens200DataAquision.TabIndex = 2;
            this.btnAddSiemens200DataAquision.Text = "添加西门子S7200";
            this.btnAddSiemens200DataAquision.UseVisualStyleBackColor = true;
            this.btnAddSiemens200DataAquision.Click += new System.EventHandler(this.btnAddSiemens200DataAquision_Click);
            // 
            // btnAddEnergyConsumptionAquision
            // 
            this.btnAddEnergyConsumptionAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddEnergyConsumptionAquision.Location = new System.Drawing.Point(287, 81);
            this.btnAddEnergyConsumptionAquision.Name = "btnAddEnergyConsumptionAquision";
            this.btnAddEnergyConsumptionAquision.Size = new System.Drawing.Size(151, 22);
            this.btnAddEnergyConsumptionAquision.TabIndex = 5;
            this.btnAddEnergyConsumptionAquision.Text = "添加能耗采集";
            this.btnAddEnergyConsumptionAquision.UseVisualStyleBackColor = true;
            this.btnAddEnergyConsumptionAquision.Click += new System.EventHandler(this.btnAddEnergyConsumptionAquision_Click);
            // 
            // btnAddTorqueAquision
            // 
            this.btnAddTorqueAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddTorqueAquision.Location = new System.Drawing.Point(1015, 81);
            this.btnAddTorqueAquision.Name = "btnAddTorqueAquision";
            this.btnAddTorqueAquision.Size = new System.Drawing.Size(144, 22);
            this.btnAddTorqueAquision.TabIndex = 6;
            this.btnAddTorqueAquision.Text = "添加扭矩采集";
            this.btnAddTorqueAquision.UseVisualStyleBackColor = true;
            this.btnAddTorqueAquision.Click += new System.EventHandler(this.btnAddTorqueAquision_Click);
            // 
            // btnAddLabviewAquision
            // 
            this.btnAddLabviewAquision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddLabviewAquision.Location = new System.Drawing.Point(283, 109);
            this.btnAddLabviewAquision.Name = "btnAddLabviewAquision";
            this.btnAddLabviewAquision.Size = new System.Drawing.Size(159, 29);
            this.btnAddLabviewAquision.TabIndex = 7;
            this.btnAddLabviewAquision.Text = "添加Labview采集";
            this.btnAddLabviewAquision.UseVisualStyleBackColor = true;
            this.btnAddLabviewAquision.Click += new System.EventHandler(this.btnAddLabviewAquision_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1456, 642);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "新智针对PLC的数据采集系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel mainFlowLayoutPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnAddMitsubishiFX3uDataAquision;
        private System.Windows.Forms.Button btnAddSiemens1200DataAquision;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddOmron501DataAquision;
        private System.Windows.Forms.Button btnAddSiemens200DataAquision;
        private System.Windows.Forms.Button btnAddEnergyConsumptionAquision;
        private System.Windows.Forms.Button btnAddTorqueAquision;
        private System.Windows.Forms.Button btnAddLabviewAquision;
    }
}