using ChamberPressureGauge.Modules;

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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpCP6 = new System.Windows.Forms.GroupBox();
            this.txtPressure[0] = new ChamberPressureGauge.Modules.ChnLED();
            this.grpCP3 = new System.Windows.Forms.GroupBox();
            this.txtPressure[1] = new ChamberPressureGauge.Modules.ChnLED();
            this.grpCP5 = new System.Windows.Forms.GroupBox();
            this.txtPressure[2] = new ChamberPressureGauge.Modules.ChnLED();
            this.grpCP4 = new System.Windows.Forms.GroupBox();
            this.txtPressure[3] = new ChamberPressureGauge.Modules.ChnLED();
            this.grpCP2 = new System.Windows.Forms.GroupBox();
            this.txtPressure[4] = new ChamberPressureGauge.Modules.ChnLED();
            this.grpCP1 = new System.Windows.Forms.GroupBox();
            this.txtPressure[5] = new ChamberPressureGauge.Modules.ChnLED();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.cbPressure[0] = new System.Windows.Forms.ComboBox();
            this.cbPressure[1] = new System.Windows.Forms.ComboBox();
            this.cbPressure[2] = new System.Windows.Forms.ComboBox();
            this.cbPressure[3] = new System.Windows.Forms.ComboBox();
            this.cbPressure[4] = new System.Windows.Forms.ComboBox();
            this.cbPressure[5] = new System.Windows.Forms.ComboBox();
            this.menuMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.staMain.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpCP6.SuspendLayout();
            this.grpCP3.SuspendLayout();
            this.grpCP5.SuspendLayout();
            this.grpCP4.SuspendLayout();
            this.grpCP2.SuspendLayout();
            this.grpCP1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tbConnet,
            this.tbStart,
            this.tbReset,
            this.tbChart,
            this.tbReport,
            this.tbExit});
            this.tbMain.Location = new System.Drawing.Point(0, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
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
            this.staMain.Location = new System.Drawing.Point(0, 631);
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
            this.grpLog.Location = new System.Drawing.Point(6, 490);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(449, 138);
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
            this.txtLog.Size = new System.Drawing.Size(437, 112);
            this.txtLog.TabIndex = 0;
            // 
            // timClock
            // 
            this.timClock.Interval = 1000;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(6, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 369);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "通道监测";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(6, 210);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(437, 153);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数字量/计时";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpCP6);
            this.groupBox3.Controls.Add(this.grpCP3);
            this.groupBox3.Controls.Add(this.grpCP5);
            this.groupBox3.Controls.Add(this.grpCP4);
            this.groupBox3.Controls.Add(this.grpCP2);
            this.groupBox3.Controls.Add(this.grpCP1);
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 184);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "压力";
            // 
            // grpCP6
            // 
            this.grpCP6.Controls.Add(this.cbPressure[5]);
            this.grpCP6.Controls.Add(this.txtPressure[5]);
            this.grpCP6.Location = new System.Drawing.Point(222, 129);
            this.grpCP6.Name = "grpCP6";
            this.grpCP6.Size = new System.Drawing.Size(209, 48);
            this.grpCP6.TabIndex = 4;
            this.grpCP6.TabStop = false;
            this.grpCP6.Text = "通道 6";
            // 
            // txtPress4
            // 
            this.txtPressure[3].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[3].Location = new System.Drawing.Point(6, 20);
            this.txtPressure[3].Name = "txtPress4";
            this.txtPressure[3].ReadOnly = true;
            this.txtPressure[3].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[3].TabIndex = 3;
            this.txtPressure[3].TabStop = false;
            this.txtPressure[3].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpCP3
            // 
            this.grpCP3.Controls.Add(this.cbPressure[2]);
            this.grpCP3.Controls.Add(this.txtPressure[2]);
            this.grpCP3.Location = new System.Drawing.Point(6, 129);
            this.grpCP3.Name = "grpCP3";
            this.grpCP3.Size = new System.Drawing.Size(210, 48);
            this.grpCP3.TabIndex = 1;
            this.grpCP3.TabStop = false;
            this.grpCP3.Text = "通道 3";
            // 
            // txtPress3
            // 
            this.txtPressure[2].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[2].Location = new System.Drawing.Point(7, 21);
            this.txtPressure[2].Name = "txtPress3";
            this.txtPressure[2].ReadOnly = true;
            this.txtPressure[2].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[2].TabIndex = 2;
            this.txtPressure[2].TabStop = false;
            this.txtPressure[2].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpCP5
            // 
            this.grpCP5.Controls.Add(this.cbPressure[4]);
            this.grpCP5.Controls.Add(this.txtPressure[4]);
            this.grpCP5.Location = new System.Drawing.Point(222, 75);
            this.grpCP5.Name = "grpCP5";
            this.grpCP5.Size = new System.Drawing.Size(209, 48);
            this.grpCP5.TabIndex = 3;
            this.grpCP5.TabStop = false;
            this.grpCP5.Text = "通道 5";
            // 
            // txtPress5
            // 
            this.txtPressure[4].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[4].Location = new System.Drawing.Point(6, 20);
            this.txtPressure[4].Name = "txtPress5";
            this.txtPressure[4].ReadOnly = true;
            this.txtPressure[4].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[4].TabIndex = 4;
            this.txtPressure[4].TabStop = false;
            this.txtPressure[4].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpCP4
            // 
            this.grpCP4.Controls.Add(this.cbPressure[3]);
            this.grpCP4.Controls.Add(this.txtPressure[3]);
            this.grpCP4.Location = new System.Drawing.Point(222, 21);
            this.grpCP4.Name = "grpCP4";
            this.grpCP4.Size = new System.Drawing.Size(209, 48);
            this.grpCP4.TabIndex = 2;
            this.grpCP4.TabStop = false;
            this.grpCP4.Text = "通道 4";
            // 
            // txtPress6
            // 
            this.txtPressure[5].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[5].Location = new System.Drawing.Point(6, 20);
            this.txtPressure[5].Name = "txtPress6";
            this.txtPressure[5].ReadOnly = true;
            this.txtPressure[5].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[5].TabIndex = 5;
            this.txtPressure[5].TabStop = false;
            this.txtPressure[5].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpCP2
            // 
            this.grpCP2.Controls.Add(this.cbPressure[1]);
            this.grpCP2.Controls.Add(this.txtPressure[1]);
            this.grpCP2.Location = new System.Drawing.Point(7, 75);
            this.grpCP2.Name = "grpCP2";
            this.grpCP2.Size = new System.Drawing.Size(209, 48);
            this.grpCP2.TabIndex = 1;
            this.grpCP2.TabStop = false;
            this.grpCP2.Text = "通道 2";
            // 
            // txtPress2
            // 
            this.txtPressure[1].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[1].Location = new System.Drawing.Point(6, 20);
            this.txtPressure[1].Name = "txtPress2";
            this.txtPressure[1].ReadOnly = true;
            this.txtPressure[1].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[1].TabIndex = 1;
            this.txtPressure[1].TabStop = false;
            this.txtPressure[1].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpCP1
            // 
            this.grpCP1.Controls.Add(this.cbPressure[0]);
            this.grpCP1.Controls.Add(this.txtPressure[0]);
            this.grpCP1.Location = new System.Drawing.Point(7, 21);
            this.grpCP1.Name = "grpCP1";
            this.grpCP1.Size = new System.Drawing.Size(209, 48);
            this.grpCP1.TabIndex = 0;
            this.grpCP1.TabStop = false;
            this.grpCP1.Text = "通道 1";
            // 
            // txtPress1
            // 
            this.txtPressure[0].Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure[0].Location = new System.Drawing.Point(6, 20);
            this.txtPressure[0].Name = "txtPress1";
            this.txtPressure[0].ReadOnly = true;
            this.txtPressure[0].Size = new System.Drawing.Size(112, 22);
            this.txtPressure[0].TabIndex = 0;
            this.txtPressure[0].TabStop = false;
            this.txtPressure[0].TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstData);
            this.groupBox2.Location = new System.Drawing.Point(461, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(771, 513);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图表";
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.ItemHeight = 12;
            this.lstData.Location = new System.Drawing.Point(7, 21);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(758, 484);
            this.lstData.TabIndex = 0;
            // 
            // cbPress1
            // 
            this.cbPressure[0].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[0].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[0].FormattingEnabled = true;
            this.cbPressure[0].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[0].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[0].Name = "cbPress1";
            this.cbPressure[0].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[0].TabIndex = 1;
            // 
            // cbPress2
            // 
            this.cbPressure[1].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[1].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[1].FormattingEnabled = true;
            this.cbPressure[1].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[1].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[1].Name = "cbPress2";
            this.cbPressure[1].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[1].TabIndex = 2;
            // 
            // cbPress3
            // 
            this.cbPressure[2].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[2].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[2].FormattingEnabled = true;
            this.cbPressure[2].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[2].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[2].Name = "cbPress3";
            this.cbPressure[2].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[2].TabIndex = 3;
            // 
            // cbPress4
            // 
            this.cbPressure[3].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[3].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[3].FormattingEnabled = true;
            this.cbPressure[3].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[3].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[3].Name = "cbPress4";
            this.cbPressure[3].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[3].TabIndex = 4;
            // 
            // cbPress5
            // 
            this.cbPressure[4].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[4].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[4].FormattingEnabled = true;
            this.cbPressure[4].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[4].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[4].Name = "cbPress5";
            this.cbPressure[4].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[4].TabIndex = 6;
            // 
            // cbPress6
            // 
            this.cbPressure[5].DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressure[5].FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbPressure[5].FormattingEnabled = true;
            this.cbPressure[5].Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbPressure[5].Location = new System.Drawing.Point(125, 21);
            this.cbPressure[5].Name = "cbPress6";
            this.cbPressure[5].Size = new System.Drawing.Size(60, 20);
            this.cbPressure[5].TabIndex = 7;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 653);
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
            this.groupBox3.ResumeLayout(false);
            this.grpCP6.ResumeLayout(false);
            this.grpCP6.PerformLayout();
            this.grpCP3.ResumeLayout(false);
            this.grpCP3.PerformLayout();
            this.grpCP5.ResumeLayout(false);
            this.grpCP5.PerformLayout();
            this.grpCP4.ResumeLayout(false);
            this.grpCP4.PerformLayout();
            this.grpCP2.ResumeLayout(false);
            this.grpCP2.PerformLayout();
            this.grpCP1.ResumeLayout(false);
            this.grpCP1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpCP6;
        private ChnLED[] txtPressure = new ChnLED[6];
        private System.Windows.Forms.GroupBox grpCP3;
        //private ChnLED txtPress3;
        private System.Windows.Forms.GroupBox grpCP5;
        //private ChnLED txtPress5;
        private System.Windows.Forms.GroupBox grpCP4;
        //private ChnLED txtPress6;
        private System.Windows.Forms.GroupBox grpCP2;
        //private ChnLED txtPress2;
        private System.Windows.Forms.GroupBox grpCP1;
        //private ChnLED txtPress1;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.ComboBox[] cbPressure = new System.Windows.Forms.ComboBox[6];
        //private System.Windows.Forms.ComboBox cbPress6;
        //private System.Windows.Forms.ComboBox cbPress3;
        //private System.Windows.Forms.ComboBox cbPress5;
        //private System.Windows.Forms.ComboBox cbPress4;
        //private System.Windows.Forms.ComboBox cbPress2;
    }
}

