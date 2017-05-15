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
            this.tbConfig = new System.Windows.Forms.ToolStripButton();
            this.tbConnet = new System.Windows.Forms.ToolStripButton();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbReset = new System.Windows.Forms.ToolStripButton();
            this.tbChart = new System.Windows.Forms.ToolStripButton();
            this.tbReport = new System.Windows.Forms.ToolStripButton();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.menuMain.SuspendLayout();
            this.tbMain.SuspendLayout();
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
            this.menuMain.Size = new System.Drawing.Size(599, 25);
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
            this.miConnect.Size = new System.Drawing.Size(152, 22);
            this.miConnect.Text = "开始连接(&C)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // miConfig
            // 
            this.miConfig.Name = "miConfig";
            this.miConfig.Size = new System.Drawing.Size(152, 22);
            this.miConfig.Text = "配置参数(&O)...";
            this.miConfig.Click += new System.EventHandler(this.EventConfig);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(152, 22);
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
            this.tbConfig,
            this.tbConnet,
            this.tbStart,
            this.tbReset,
            this.tbChart,
            this.tbReport,
            this.tbExit});
            this.tbMain.Location = new System.Drawing.Point(0, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tbMain.Size = new System.Drawing.Size(599, 87);
            this.tbMain.TabIndex = 1;
            this.tbMain.Text = "toolStrip1";
            // 
            // tbConfig
            // 
            this.tbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbConfig.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_config;
            this.tbConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(84, 84);
            this.tbConfig.Text = "toolStripButton1";
            this.tbConfig.ToolTipText = "配置参数";
            this.tbConfig.Click += new System.EventHandler(this.EventConfig);
            // 
            // tbConnet
            // 
            this.tbConnet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbConnet.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_connect;
            this.tbConnet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbConnet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConnet.Name = "tbConnet";
            this.tbConnet.Size = new System.Drawing.Size(84, 84);
            this.tbConnet.Text = "toolStripButton2";
            this.tbConnet.ToolTipText = "开始连接";
            // 
            // tbStart
            // 
            this.tbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbStart.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_start_listening;
            this.tbStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(84, 84);
            this.tbStart.Text = "toolStripButton3";
            this.tbStart.ToolTipText = "开始测量";
            // 
            // tbReset
            // 
            this.tbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReset.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_reset;
            this.tbReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReset.Name = "tbReset";
            this.tbReset.Size = new System.Drawing.Size(84, 84);
            this.tbReset.Text = "toolStripButton4";
            this.tbReset.ToolTipText = "复位";
            // 
            // tbChart
            // 
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
            this.staMain.Location = new System.Drawing.Point(0, 347);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(599, 22);
            this.staMain.TabIndex = 2;
            this.staMain.Text = "statusStrip1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 369);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainWindow";
            this.Text = "膛压仪测量数据接收终端";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tbConfig;
        private System.Windows.Forms.ToolStripButton tbConnet;
        private System.Windows.Forms.ToolStripButton tbStart;
        private System.Windows.Forms.ToolStripButton tbReset;
        private System.Windows.Forms.ToolStripButton tbChart;
        private System.Windows.Forms.ToolStripButton tbReport;
        private System.Windows.Forms.ToolStripButton tbExit;
        private System.Windows.Forms.StatusStrip staMain;
    }
}

