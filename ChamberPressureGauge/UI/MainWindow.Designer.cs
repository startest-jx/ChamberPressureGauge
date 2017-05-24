using ChamberPressureGauge.Controls;

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
            this.tcChannel = new System.Windows.Forms.TabControl();
            this.tpPressure = new System.Windows.Forms.TabPage();
            this.lblSecond = new System.Windows.Forms.Label();
            this.txtMeasuringTime = new System.Windows.Forms.TextBox();
            this.lblMeasuringTime = new System.Windows.Forms.Label();
            this.btnRefreshTriggerChannel = new System.Windows.Forms.Button();
            this.cbTriggerChannel = new System.Windows.Forms.ComboBox();
            this.lblTriggerChannel = new System.Windows.Forms.Label();
            this.cbTriggerMode = new System.Windows.Forms.ComboBox();
            this.lblTriggerMode = new System.Windows.Forms.Label();
            this.tpDigital = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.timChannelUpdate = new System.Timers.Timer();
            this.menuMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.staMain.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tcChannel.SuspendLayout();
            this.tpPressure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timChannelUpdate)).BeginInit();
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
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuMain.Size = new System.Drawing.Size(1239, 25);
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
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tbMain.Size = new System.Drawing.Size(1239, 87);
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
            this.tbExit.Click += new System.EventHandler(this.WinClosing);
            // 
            // staMain
            // 
            this.staMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblNone,
            this.lblTime});
            this.staMain.Location = new System.Drawing.Point(0, 707);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(1239, 22);
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
            this.lblNone.Size = new System.Drawing.Size(1224, 17);
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
            this.grpLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpLog.Location = new System.Drawing.Point(6, 566);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(628, 138);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Location = new System.Drawing.Point(6, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(612, 112);
            this.txtLog.TabIndex = 0;
            // 
            // timClock
            // 
            this.timClock.Interval = 1000;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcChannel);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(6, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(628, 445);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通道监测";
            // 
            // tcChannel
            // 
            this.tcChannel.Controls.Add(this.tpPressure);
            this.tcChannel.Controls.Add(this.tpDigital);
            this.tcChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcChannel.Location = new System.Drawing.Point(7, 21);
            this.tcChannel.Name = "tcChannel";
            this.tcChannel.SelectedIndex = 0;
            this.tcChannel.Size = new System.Drawing.Size(615, 418);
            this.tcChannel.TabIndex = 0;
            // 
            // tpPressure
            // 
            this.tpPressure.BackColor = System.Drawing.Color.White;
            this.tpPressure.Controls.Add(this.lblSecond);
            this.tpPressure.Controls.Add(this.txtMeasuringTime);
            this.tpPressure.Controls.Add(this.lblMeasuringTime);
            this.tpPressure.Controls.Add(this.btnRefreshTriggerChannel);
            this.tpPressure.Controls.Add(this.cbTriggerChannel);
            this.tpPressure.Controls.Add(this.lblTriggerChannel);
            this.tpPressure.Controls.Add(this.cbTriggerMode);
            this.tpPressure.Controls.Add(this.lblTriggerMode);
            this.tpPressure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpPressure.Location = new System.Drawing.Point(4, 26);
            this.tpPressure.Name = "tpPressure";
            this.tpPressure.Padding = new System.Windows.Forms.Padding(3);
            this.tpPressure.Size = new System.Drawing.Size(607, 388);
            this.tpPressure.TabIndex = 0;
            this.tpPressure.Text = "压力";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(566, 347);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(20, 17);
            this.lblSecond.TabIndex = 7;
            this.lblSecond.Text = "秒";
            // 
            // txtMeasuringTime
            // 
            this.txtMeasuringTime.Location = new System.Drawing.Point(485, 344);
            this.txtMeasuringTime.Name = "txtMeasuringTime";
            this.txtMeasuringTime.Size = new System.Drawing.Size(75, 23);
            this.txtMeasuringTime.TabIndex = 6;
            this.txtMeasuringTime.LostFocus += new System.EventHandler(this.txtMeasuringTime_LostFocus);
            // 
            // lblMeasuringTime
            // 
            this.lblMeasuringTime.AutoSize = true;
            this.lblMeasuringTime.Location = new System.Drawing.Point(420, 347);
            this.lblMeasuringTime.Name = "lblMeasuringTime";
            this.lblMeasuringTime.Size = new System.Drawing.Size(59, 17);
            this.lblMeasuringTime.TabIndex = 5;
            this.lblMeasuringTime.Text = "测量时间:";
            // 
            // btnRefreshTriggerChannel
            // 
            this.btnRefreshTriggerChannel.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshTriggerChannel.Image = global::ChamberPressureGauge.Properties.Resources.Refresh;
            this.btnRefreshTriggerChannel.Location = new System.Drawing.Point(390, 344);
            this.btnRefreshTriggerChannel.Name = "btnRefreshTriggerChannel";
            this.btnRefreshTriggerChannel.Size = new System.Drawing.Size(24, 24);
            this.btnRefreshTriggerChannel.TabIndex = 4;
            this.btnRefreshTriggerChannel.UseVisualStyleBackColor = false;
            this.btnRefreshTriggerChannel.Click += new System.EventHandler(this.btnRefreshTriggerChannel_Click);
            // 
            // cbTriggerChannel
            // 
            this.cbTriggerChannel.BackColor = System.Drawing.Color.White;
            this.cbTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerChannel.FormattingEnabled = true;
            this.cbTriggerChannel.Location = new System.Drawing.Point(263, 344);
            this.cbTriggerChannel.Name = "cbTriggerChannel";
            this.cbTriggerChannel.Size = new System.Drawing.Size(121, 25);
            this.cbTriggerChannel.TabIndex = 3;
            this.cbTriggerChannel.SelectedIndexChanged += new System.EventHandler(this.cbTriggerChannel_SelectedIndexChanged);
            // 
            // lblTriggerChannel
            // 
            this.lblTriggerChannel.AutoSize = true;
            this.lblTriggerChannel.Location = new System.Drawing.Point(198, 347);
            this.lblTriggerChannel.Name = "lblTriggerChannel";
            this.lblTriggerChannel.Size = new System.Drawing.Size(59, 17);
            this.lblTriggerChannel.TabIndex = 2;
            this.lblTriggerChannel.Text = "计量通道:";
            // 
            // cbTriggerMode
            // 
            this.cbTriggerMode.BackColor = System.Drawing.Color.White;
            this.cbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerMode.FormattingEnabled = true;
            this.cbTriggerMode.Items.AddRange(new object[] {
            "自动触发(推荐)",
            "手动触发",
            "外触发"});
            this.cbTriggerMode.Location = new System.Drawing.Point(71, 344);
            this.cbTriggerMode.Name = "cbTriggerMode";
            this.cbTriggerMode.Size = new System.Drawing.Size(121, 25);
            this.cbTriggerMode.TabIndex = 1;
            this.cbTriggerMode.SelectedIndexChanged += new System.EventHandler(this.cbTriggerMode_SelectedIndexChanged);
            // 
            // lblTriggerMode
            // 
            this.lblTriggerMode.AutoSize = true;
            this.lblTriggerMode.Location = new System.Drawing.Point(6, 347);
            this.lblTriggerMode.Name = "lblTriggerMode";
            this.lblTriggerMode.Size = new System.Drawing.Size(59, 17);
            this.lblTriggerMode.TabIndex = 0;
            this.lblTriggerMode.Text = "触发方式:";
            // 
            // tpDigital
            // 
            this.tpDigital.Location = new System.Drawing.Point(4, 26);
            this.tpDigital.Name = "tpDigital";
            this.tpDigital.Padding = new System.Windows.Forms.Padding(3);
            this.tpDigital.Size = new System.Drawing.Size(607, 388);
            this.tpDigital.TabIndex = 1;
            this.tpDigital.Text = "数字量/计时";
            this.tpDigital.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(640, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 589);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图表";
            // 
            // timChannelUpdate
            // 
            this.timChannelUpdate.Interval = 500D;
            this.timChannelUpdate.SynchronizingObject = this;
            this.timChannelUpdate.Elapsed += new System.Timers.ElapsedEventHandler(this.timChannelUpdate_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1239, 729);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinClosing);
            this.Load += new System.EventHandler(this.WinLoad);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.staMain.ResumeLayout(false);
            this.staMain.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tcChannel.ResumeLayout(false);
            this.tpPressure.ResumeLayout(false);
            this.tpPressure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timChannelUpdate)).EndInit();
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
        private System.Timers.Timer timChannelUpdate;
        private System.Windows.Forms.TabControl tcChannel;
        private System.Windows.Forms.TabPage tpPressure;
        private System.Windows.Forms.TabPage tpDigital;
        private System.Windows.Forms.ComboBox cbTriggerChannel;
        private System.Windows.Forms.Label lblTriggerChannel;
        private System.Windows.Forms.ComboBox cbTriggerMode;
        private System.Windows.Forms.Label lblTriggerMode;
        private System.Windows.Forms.Button btnRefreshTriggerChannel;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.TextBox txtMeasuringTime;
        private System.Windows.Forms.Label lblMeasuringTime;
    }
}

