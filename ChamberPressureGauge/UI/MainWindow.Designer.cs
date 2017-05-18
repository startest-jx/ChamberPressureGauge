namespace ChamberPressureGauge
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menData = new System.Windows.Forms.ToolStripMenuItem();
            this.miStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miReset = new System.Windows.Forms.ToolStripMenuItem();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.miChart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.miCurReport = new System.Windows.Forms.ToolStripMenuItem();
            this.miOtherReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.tbConnet = new System.Windows.Forms.ToolStripButton();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbReset = new System.Windows.Forms.ToolStripButton();
            this.tbChart = new System.Windows.Forms.ToolStripButton();
            this.tbReport = new System.Windows.Forms.ToolStripButton();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNone = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timClock = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.staMain.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menConnect,
            this.menData,
            this.miView,
            this.menHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuMain.Size = new System.Drawing.Size(1244, 25);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // menConnect
            // 
            this.menConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnect,
            this.toolStripMenuItem1,
            this.miConfig,
            this.toolStripMenuItem2,
            this.miExit});
            this.menConnect.Name = "menConnect";
            this.menConnect.Size = new System.Drawing.Size(60, 21);
            this.menConnect.Text = "连接(&C)";
            // 
            // miConnect
            // 
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(151, 22);
            this.miConnect.Text = "开始连接(&C)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // miConfig
            // 
            this.miConfig.Name = "miConfig";
            this.miConfig.Size = new System.Drawing.Size(151, 22);
            this.miConfig.Text = "配置参数(&O)...";
            this.miConfig.Click += new System.EventHandler(this.EventConfig);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(151, 22);
            this.miExit.Text = "退出(&E)";
            // 
            // menData
            // 
            this.menData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStart,
            this.toolStripMenuItem3,
            this.miReset});
            this.menData.Name = "menData";
            this.menData.Size = new System.Drawing.Size(61, 21);
            this.menData.Text = "数据(&D)";
            // 
            // miStart
            // 
            this.miStart.Name = "miStart";
            this.miStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miStart.Size = new System.Drawing.Size(145, 22);
            this.miStart.Text = "开始测量";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 6);
            // 
            // miReset
            // 
            this.miReset.Name = "miReset";
            this.miReset.Size = new System.Drawing.Size(145, 22);
            this.miReset.Text = "复位(&R)";
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChart,
            this.toolStripMenuItem4,
            this.miCurReport,
            this.miOtherReport});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(60, 21);
            this.miView.Text = "查看(&V)";
            // 
            // miChart
            // 
            this.miChart.Name = "miChart";
            this.miChart.Size = new System.Drawing.Size(151, 22);
            this.miChart.Text = "图表(&C)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(148, 6);
            // 
            // miCurReport
            // 
            this.miCurReport.Name = "miCurReport";
            this.miCurReport.Size = new System.Drawing.Size(151, 22);
            this.miCurReport.Text = "当前报告(&R)";
            // 
            // miOtherReport
            // 
            this.miOtherReport.Name = "miOtherReport";
            this.miOtherReport.Size = new System.Drawing.Size(151, 22);
            this.miOtherReport.Text = "其他报告(&O)...";
            // 
            // menHelp
            // 
            this.menHelp.Name = "menHelp";
            this.menHelp.Size = new System.Drawing.Size(61, 21);
            this.menHelp.Text = "帮助(&H)";
            // 
            // tbMain
            // 
            this.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbConnet,
            this.tbStart,
            this.tbReset,
            this.tbChart,
            this.tbReport,
            this.tbExit});
            this.tbMain.Location = new System.Drawing.Point(0, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tbMain.Size = new System.Drawing.Size(1244, 87);
            this.tbMain.TabIndex = 1;
            this.tbMain.Text = "toolStrip1";
            // 
            // tbConnet
            // 
            this.tbConnet.AutoSize = false;
            this.tbConnet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbConnet.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_connect;
            this.tbConnet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbConnet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConnet.Name = "tbConnet";
            this.tbConnet.Size = new System.Drawing.Size(84, 84);
            this.tbConnet.Text = "toolStripButton2";
            this.tbConnet.ToolTipText = "开始连接";
            this.tbConnet.Click += new System.EventHandler(this.Connect);
            // 
            // tbStart
            // 
            this.tbStart.AutoSize = false;
            this.tbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStart.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_start_listening;
            this.tbStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(84, 84);
            this.tbStart.Text = "toolStripButton3";
            this.tbStart.ToolTipText = "开始测量";
            this.tbStart.Click += new System.EventHandler(this.Start);
            // 
            // tbReset
            // 
            this.tbReset.AutoSize = false;
            this.tbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReset.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_reset;
            this.tbReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReset.Name = "tbReset";
            this.tbReset.Size = new System.Drawing.Size(84, 84);
            this.tbReset.Text = "toolStripButton4";
            this.tbReset.ToolTipText = "复位";
            this.tbReset.Click += new System.EventHandler(this.Reset);
            // 
            // tbChart
            // 
            this.tbChart.AutoSize = false;
            this.tbChart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbChart.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_chart;
            this.tbChart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbChart.Name = "tbChart";
            this.tbChart.Size = new System.Drawing.Size(84, 84);
            this.tbChart.Text = "toolStripButton5";
            this.tbChart.ToolTipText = "查看图表";
            // 
            // tbReport
            // 
            this.tbReport.AutoSize = false;
            this.tbReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_report;
            this.tbReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(84, 84);
            this.tbReport.Text = "toolStripButton6";
            this.tbReport.ToolTipText = "查看当前报告";
            // 
            // tbExit
            // 
            this.tbExit.AutoSize = false;
            this.tbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExit.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_close;
            this.tbExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExit.Name = "tbExit";
            this.tbExit.Size = new System.Drawing.Size(84, 84);
            this.tbExit.Text = "toolStripButton7";
            this.tbExit.ToolTipText = "退出";
            // 
            // staMain
            // 
            this.staMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblNone,
            this.lblTime});
            this.staMain.Location = new System.Drawing.Point(0, 631);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(1244, 22);
            this.staMain.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNone
            // 
            this.lblNone.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblNone.Name = "lblNone";
            this.lblNone.Size = new System.Drawing.Size(1229, 17);
            this.lblNone.Spring = true;
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 17);
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.txtLog);
            this.grpLog.Location = new System.Drawing.Point(6, 490);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(415, 138);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(403, 112);
            this.txtLog.TabIndex = 0;
            // 
            // timClock
            // 
            this.timClock.Interval = 1000;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(6, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 369);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通道监测";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(427, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 513);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图表";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 653);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "膛压仪测量数据接收终端";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.WinLoad);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.staMain.ResumeLayout(false);
            this.staMain.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menConnect;
        private System.Windows.Forms.ToolStripMenuItem miConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miConfig;
        private System.Windows.Forms.ToolStripMenuItem menData;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem menHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miStart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miReset;
        private System.Windows.Forms.ToolStripMenuItem miChart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miCurReport;
        private System.Windows.Forms.ToolStripMenuItem miOtherReport;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton tbConnet;
        private System.Windows.Forms.ToolStripButton tbStart;
        private System.Windows.Forms.ToolStripButton tbReset;
        private System.Windows.Forms.ToolStripButton tbChart;
        private System.Windows.Forms.ToolStripButton tbReport;
        private System.Windows.Forms.ToolStripButton tbExit;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timClock;
        private System.Windows.Forms.ToolStripStatusLabel lblNone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

