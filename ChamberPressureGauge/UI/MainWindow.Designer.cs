namespace ChamberPressureGauge.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNone = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timClock = new System.Windows.Forms.Timer(this.components);
            this.gbTotalChannel = new System.Windows.Forms.GroupBox();
            this.gbMeasure = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDigitalTriggerChannel = new System.Windows.Forms.ComboBox();
            this.cbTriggerMode = new System.Windows.Forms.ComboBox();
            this.lblTriggerMode = new System.Windows.Forms.Label();
            this.lblTriggerChannel = new System.Windows.Forms.Label();
            this.cbPressureTriggerChannel = new System.Windows.Forms.ComboBox();
            this.tcChannel = new System.Windows.Forms.TabControl();
            this.tpPressure = new System.Windows.Forms.TabPage();
            this.pcc6 = new Controls.Channel.PressureChannelControl();
            this.pcc5 = new Controls.Channel.PressureChannelControl();
            this.pcc4 = new Controls.Channel.PressureChannelControl();
            this.pcc3 = new Controls.Channel.PressureChannelControl();
            this.pcc2 = new Controls.Channel.PressureChannelControl();
            this.pcc1 = new Controls.Channel.PressureChannelControl();
            this.tpDigital = new System.Windows.Forms.TabPage();
            this.dcc4 = new Controls.Channel.DigitalChannelControl();
            this.dcc3 = new Controls.Channel.DigitalChannelControl();
            this.dcc2 = new Controls.Channel.DigitalChannelControl();
            this.dcc1 = new Controls.Channel.DigitalChannelControl();
            this.tpSpeed = new System.Windows.Forms.TabPage();
            this.scc = new Controls.Channel.SpeedChannelControl();
            this.CountDown = new Controls.Other.CountDown();
            this.lblDisconnected = new System.Windows.Forms.Label();
            this.gbChart = new System.Windows.Forms.GroupBox();
            this.mcChart = new Controls.Chart.MyChart();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timChannelUpdate = new System.Timers.Timer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResultDigitalTriggerLast = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResultDigitalTriggerStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResultTotalTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.bwMeasure = new System.ComponentModel.BackgroundWorker();
            this.bwBuildReport = new System.ComponentModel.BackgroundWorker();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshTriggerChannel = new System.Windows.Forms.Button();
            this.tbConnet = new System.Windows.Forms.ToolStripButton();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbReset = new System.Windows.Forms.ToolStripButton();
            this.tbChart = new System.Windows.Forms.ToolStripButton();
            this.tbReport = new System.Windows.Forms.ToolStripButton();
            this.tbConfig = new System.Windows.Forms.ToolStripButton();
            this.tbExit = new System.Windows.Forms.ToolStripButton();
            this.miConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miStart = new System.Windows.Forms.ToolStripMenuItem();
            this.miReset = new System.Windows.Forms.ToolStripMenuItem();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miChart = new System.Windows.Forms.ToolStripMenuItem();
            this.miReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tbImport = new System.Windows.Forms.ToolStripButton();
            this.tbExport = new System.Windows.Forms.ToolStripButton();
            this.menuMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.staMain.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.gbTotalChannel.SuspendLayout();
            this.gbMeasure.SuspendLayout();
            this.tcChannel.SuspendLayout();
            this.tpPressure.SuspendLayout();
            this.tpDigital.SuspendLayout();
            this.tpSpeed.SuspendLayout();
            this.gbChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timChannelUpdate)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.menuMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuMain.Size = new System.Drawing.Size(1043, 25);
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
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 6);
            // 
            // menData
            // 
            this.menData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStart,
            this.toolStripMenuItem3,
            this.miReset,
            this.toolStripMenuItem5,
            this.miImport,
            this.miExport});
            this.menData.Name = "menData";
            this.menData.Size = new System.Drawing.Size(61, 21);
            this.menData.Text = "数据(&D)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // miView
            // 
            this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChart,
            this.toolStripMenuItem4,
            this.miReport});
            this.miView.Name = "miView";
            this.miView.Size = new System.Drawing.Size(60, 21);
            this.miView.Text = "查看(&V)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(113, 6);
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
            this.tbImport,
            this.tbExport,
            this.tbConfig,
            this.tbExit});
            this.tbMain.Location = new System.Drawing.Point(0, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tbMain.Size = new System.Drawing.Size(1043, 87);
            this.tbMain.TabIndex = 1;
            this.tbMain.Text = "toolStrip1";
            // 
            // staMain
            // 
            this.staMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblNone,
            this.lblTime});
            this.staMain.Location = new System.Drawing.Point(0, 697);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(1043, 22);
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
            this.lblNone.Size = new System.Drawing.Size(1028, 17);
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
            this.grpLog.Location = new System.Drawing.Point(12, 554);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(509, 138);
            this.grpLog.TabIndex = 3;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "日志";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 19);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(503, 116);
            this.txtLog.TabIndex = 0;
            // 
            // timClock
            // 
            this.timClock.Interval = 1000;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // gbTotalChannel
            // 
            this.gbTotalChannel.Controls.Add(this.gbMeasure);
            this.gbTotalChannel.Controls.Add(this.tcChannel);
            this.gbTotalChannel.Controls.Add(this.CountDown);
            this.gbTotalChannel.Controls.Add(this.lblDisconnected);
            this.gbTotalChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbTotalChannel.Location = new System.Drawing.Point(12, 115);
            this.gbTotalChannel.Name = "gbTotalChannel";
            this.gbTotalChannel.Size = new System.Drawing.Size(509, 436);
            this.gbTotalChannel.TabIndex = 4;
            this.gbTotalChannel.TabStop = false;
            this.gbTotalChannel.Text = "通道监测";
            // 
            // gbMeasure
            // 
            this.gbMeasure.Controls.Add(this.label7);
            this.gbMeasure.Controls.Add(this.cbDigitalTriggerChannel);
            this.gbMeasure.Controls.Add(this.cbTriggerMode);
            this.gbMeasure.Controls.Add(this.lblTriggerMode);
            this.gbMeasure.Controls.Add(this.lblTriggerChannel);
            this.gbMeasure.Controls.Add(this.cbPressureTriggerChannel);
            this.gbMeasure.Controls.Add(this.btnRefreshTriggerChannel);
            this.gbMeasure.Location = new System.Drawing.Point(3, 329);
            this.gbMeasure.Name = "gbMeasure";
            this.gbMeasure.Size = new System.Drawing.Size(503, 104);
            this.gbMeasure.TabIndex = 15;
            this.gbMeasure.TabStop = false;
            this.gbMeasure.Text = "测量属性";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(206, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "计量通道(数字量/计时):";
            // 
            // cbDigitalTriggerChannel
            // 
            this.cbDigitalTriggerChannel.BackColor = System.Drawing.Color.White;
            this.cbDigitalTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDigitalTriggerChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbDigitalTriggerChannel.FormattingEnabled = true;
            this.cbDigitalTriggerChannel.Location = new System.Drawing.Point(344, 68);
            this.cbDigitalTriggerChannel.Name = "cbDigitalTriggerChannel";
            this.cbDigitalTriggerChannel.Size = new System.Drawing.Size(121, 25);
            this.cbDigitalTriggerChannel.TabIndex = 10;
            this.cbDigitalTriggerChannel.SelectedIndexChanged += new System.EventHandler(this.cbDigitalTriggerChannel_SelectedIndexChanged);
            // 
            // cbTriggerMode
            // 
            this.cbTriggerMode.BackColor = System.Drawing.Color.White;
            this.cbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTriggerMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbTriggerMode.FormattingEnabled = true;
            this.cbTriggerMode.Items.AddRange(new object[] {
            "自动触发(推荐)",
            "手动触发",
            "外触发"});
            this.cbTriggerMode.Location = new System.Drawing.Point(73, 26);
            this.cbTriggerMode.Name = "cbTriggerMode";
            this.cbTriggerMode.Size = new System.Drawing.Size(121, 25);
            this.cbTriggerMode.TabIndex = 1;
            this.cbTriggerMode.SelectedIndexChanged += new System.EventHandler(this.cbTriggerMode_SelectedIndexChanged);
            // 
            // lblTriggerMode
            // 
            this.lblTriggerMode.AutoSize = true;
            this.lblTriggerMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerMode.Location = new System.Drawing.Point(8, 29);
            this.lblTriggerMode.Name = "lblTriggerMode";
            this.lblTriggerMode.Size = new System.Drawing.Size(59, 17);
            this.lblTriggerMode.TabIndex = 0;
            this.lblTriggerMode.Text = "触发方式:";
            // 
            // lblTriggerChannel
            // 
            this.lblTriggerChannel.AutoSize = true;
            this.lblTriggerChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTriggerChannel.Location = new System.Drawing.Point(206, 29);
            this.lblTriggerChannel.Name = "lblTriggerChannel";
            this.lblTriggerChannel.Size = new System.Drawing.Size(91, 17);
            this.lblTriggerChannel.TabIndex = 2;
            this.lblTriggerChannel.Text = "计量通道(压力):";
            // 
            // cbPressureTriggerChannel
            // 
            this.cbPressureTriggerChannel.BackColor = System.Drawing.Color.White;
            this.cbPressureTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPressureTriggerChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPressureTriggerChannel.FormattingEnabled = true;
            this.cbPressureTriggerChannel.Location = new System.Drawing.Point(344, 26);
            this.cbPressureTriggerChannel.Name = "cbPressureTriggerChannel";
            this.cbPressureTriggerChannel.Size = new System.Drawing.Size(121, 25);
            this.cbPressureTriggerChannel.TabIndex = 3;
            this.cbPressureTriggerChannel.SelectedIndexChanged += new System.EventHandler(this.cbTriggerChannel_SelectedIndexChanged);
            // 
            // tcChannel
            // 
            this.tcChannel.Controls.Add(this.tpPressure);
            this.tcChannel.Controls.Add(this.tpDigital);
            this.tcChannel.Controls.Add(this.tpSpeed);
            this.tcChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcChannel.Location = new System.Drawing.Point(3, 19);
            this.tcChannel.Name = "tcChannel";
            this.tcChannel.SelectedIndex = 0;
            this.tcChannel.Size = new System.Drawing.Size(503, 308);
            this.tcChannel.TabIndex = 0;
            // 
            // tpPressure
            // 
            this.tpPressure.BackColor = System.Drawing.Color.White;
            this.tpPressure.Controls.Add(this.pcc6);
            this.tpPressure.Controls.Add(this.pcc5);
            this.tpPressure.Controls.Add(this.pcc4);
            this.tpPressure.Controls.Add(this.pcc3);
            this.tpPressure.Controls.Add(this.pcc2);
            this.tpPressure.Controls.Add(this.pcc1);
            this.tpPressure.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpPressure.Location = new System.Drawing.Point(4, 26);
            this.tpPressure.Name = "tpPressure";
            this.tpPressure.Padding = new System.Windows.Forms.Padding(3);
            this.tpPressure.Size = new System.Drawing.Size(495, 278);
            this.tpPressure.TabIndex = 0;
            this.tpPressure.Text = "压力";
            // 
            // pcc6
            // 
            this.pcc6.Calibration = 0D;
            this.pcc6.Location = new System.Drawing.Point(250, 188);
            this.pcc6.Name = "pcc6";
            this.pcc6.OriginData = 0;
            this.pcc6.Range = 1;
            this.pcc6.Size = new System.Drawing.Size(239, 85);
            this.pcc6.TabIndex = 14;
            // 
            // pcc5
            // 
            this.pcc5.Calibration = 0D;
            this.pcc5.Location = new System.Drawing.Point(6, 188);
            this.pcc5.Name = "pcc5";
            this.pcc5.OriginData = 0;
            this.pcc5.Range = 1;
            this.pcc5.Size = new System.Drawing.Size(239, 85);
            this.pcc5.TabIndex = 13;
            // 
            // pcc4
            // 
            this.pcc4.Calibration = 0D;
            this.pcc4.Location = new System.Drawing.Point(250, 97);
            this.pcc4.Name = "pcc4";
            this.pcc4.OriginData = 0;
            this.pcc4.Range = 1;
            this.pcc4.Size = new System.Drawing.Size(239, 85);
            this.pcc4.TabIndex = 12;
            // 
            // pcc3
            // 
            this.pcc3.Calibration = 0D;
            this.pcc3.Location = new System.Drawing.Point(6, 97);
            this.pcc3.Name = "pcc3";
            this.pcc3.OriginData = 0;
            this.pcc3.Range = 1;
            this.pcc3.Size = new System.Drawing.Size(239, 85);
            this.pcc3.TabIndex = 11;
            // 
            // pcc2
            // 
            this.pcc2.Calibration = 0D;
            this.pcc2.Location = new System.Drawing.Point(250, 6);
            this.pcc2.Name = "pcc2";
            this.pcc2.OriginData = 0;
            this.pcc2.Range = 1;
            this.pcc2.Size = new System.Drawing.Size(239, 85);
            this.pcc2.TabIndex = 10;
            // 
            // pcc1
            // 
            this.pcc1.Calibration = 0D;
            this.pcc1.Location = new System.Drawing.Point(6, 6);
            this.pcc1.Name = "pcc1";
            this.pcc1.OriginData = 0;
            this.pcc1.Range = 1;
            this.pcc1.Size = new System.Drawing.Size(239, 85);
            this.pcc1.TabIndex = 9;
            // 
            // tpDigital
            // 
            this.tpDigital.Controls.Add(this.dcc4);
            this.tpDigital.Controls.Add(this.dcc3);
            this.tpDigital.Controls.Add(this.dcc2);
            this.tpDigital.Controls.Add(this.dcc1);
            this.tpDigital.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tpDigital.Location = new System.Drawing.Point(4, 26);
            this.tpDigital.Name = "tpDigital";
            this.tpDigital.Padding = new System.Windows.Forms.Padding(3);
            this.tpDigital.Size = new System.Drawing.Size(495, 278);
            this.tpDigital.TabIndex = 1;
            this.tpDigital.Text = "数字量/计时";
            this.tpDigital.UseVisualStyleBackColor = true;
            // 
            // dcc4
            // 
            this.dcc4.Location = new System.Drawing.Point(250, 97);
            this.dcc4.Name = "dcc4";
            this.dcc4.OriginData = 0;
            this.dcc4.Size = new System.Drawing.Size(239, 85);
            this.dcc4.TabIndex = 3;
            // 
            // dcc3
            // 
            this.dcc3.Location = new System.Drawing.Point(6, 97);
            this.dcc3.Name = "dcc3";
            this.dcc3.OriginData = 0;
            this.dcc3.Size = new System.Drawing.Size(239, 85);
            this.dcc3.TabIndex = 2;
            // 
            // dcc2
            // 
            this.dcc2.Location = new System.Drawing.Point(250, 6);
            this.dcc2.Name = "dcc2";
            this.dcc2.OriginData = 0;
            this.dcc2.Size = new System.Drawing.Size(239, 85);
            this.dcc2.TabIndex = 1;
            // 
            // dcc1
            // 
            this.dcc1.Location = new System.Drawing.Point(6, 6);
            this.dcc1.Name = "dcc1";
            this.dcc1.OriginData = 0;
            this.dcc1.Size = new System.Drawing.Size(239, 85);
            this.dcc1.TabIndex = 0;
            // 
            // tpSpeed
            // 
            this.tpSpeed.Controls.Add(this.scc);
            this.tpSpeed.Location = new System.Drawing.Point(4, 26);
            this.tpSpeed.Name = "tpSpeed";
            this.tpSpeed.Size = new System.Drawing.Size(495, 278);
            this.tpSpeed.TabIndex = 2;
            this.tpSpeed.Text = "速度";
            this.tpSpeed.UseVisualStyleBackColor = true;
            // 
            // scc
            // 
            this.scc.Location = new System.Drawing.Point(6, 6);
            this.scc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scc.Name = "scc";
            this.scc.OriginData = 0;
            this.scc.Size = new System.Drawing.Size(239, 85);
            this.scc.TabIndex = 0;
            // 
            // CountDown
            // 
            this.CountDown.AutoSize = true;
            this.CountDown.Location = new System.Drawing.Point(101, 71);
            this.CountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CountDown.Name = "CountDown";
            this.CountDown.Size = new System.Drawing.Size(302, 205);
            this.CountDown.TabIndex = 9;
            // 
            // lblDisconnected
            // 
            this.lblDisconnected.AutoSize = true;
            this.lblDisconnected.Font = new System.Drawing.Font("Cambria", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisconnected.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblDisconnected.Location = new System.Drawing.Point(40, 180);
            this.lblDisconnected.Name = "lblDisconnected";
            this.lblDisconnected.Size = new System.Drawing.Size(428, 75);
            this.lblDisconnected.TabIndex = 15;
            this.lblDisconnected.Text = "Disconnected";
            // 
            // gbChart
            // 
            this.gbChart.Controls.Add(this.mcChart);
            this.gbChart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbChart.Location = new System.Drawing.Point(527, 115);
            this.gbChart.Name = "gbChart";
            this.gbChart.Size = new System.Drawing.Size(506, 436);
            this.gbChart.TabIndex = 5;
            this.gbChart.TabStop = false;
            this.gbChart.Text = "图表";
            // 
            // mcChart
            // 
            this.mcChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcChart.Location = new System.Drawing.Point(3, 19);
            this.mcChart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mcChart.Name = "mcChart";
            this.mcChart.Size = new System.Drawing.Size(500, 414);
            this.mcChart.TabIndex = 0;
            this.mcChart.DataHover += new LiveCharts.Events.DataHoverHandler(this.ChartDataHover);
            // 
            // txtY
            // 
            this.txtY.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtY.Location = new System.Drawing.Point(39, 69);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(74, 23);
            this.txtY.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y:";
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtX.Location = new System.Drawing.Point(39, 40);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(74, 23);
            this.txtX.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "X:";
            // 
            // timChannelUpdate
            // 
            this.timChannelUpdate.Interval = 500D;
            this.timChannelUpdate.SynchronizingObject = this;
            this.timChannelUpdate.Elapsed += new System.Timers.ElapsedEventHandler(this.timChannelUpdate_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResultDigitalTriggerLast);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtResultDigitalTriggerStart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtResultTotalTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(527, 554);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "测量结果";
            // 
            // txtResultDigitalTriggerLast
            // 
            this.txtResultDigitalTriggerLast.Location = new System.Drawing.Point(79, 94);
            this.txtResultDigitalTriggerLast.Name = "txtResultDigitalTriggerLast";
            this.txtResultDigitalTriggerLast.Size = new System.Drawing.Size(100, 23);
            this.txtResultDigitalTriggerLast.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 40);
            this.label6.TabIndex = 12;
            this.label6.Text = "数字量/计时触发总时间:";
            // 
            // txtResultDigitalTriggerStart
            // 
            this.txtResultDigitalTriggerStart.Location = new System.Drawing.Point(79, 58);
            this.txtResultDigitalTriggerStart.Name = "txtResultDigitalTriggerStart";
            this.txtResultDigitalTriggerStart.Size = new System.Drawing.Size(100, 23);
            this.txtResultDigitalTriggerStart.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 34);
            this.label5.TabIndex = 10;
            this.label5.Text = "数字量/计时触发时间点:";
            // 
            // txtResultTotalTime
            // 
            this.txtResultTotalTime.Location = new System.Drawing.Point(79, 22);
            this.txtResultTotalTime.Name = "txtResultTotalTime";
            this.txtResultTotalTime.Size = new System.Drawing.Size(100, 23);
            this.txtResultTotalTime.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "总时间:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtX);
            this.groupBox2.Controls.Add(this.txtY);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(371, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(129, 112);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标值";
            // 
            // bwConnect
            // 
            this.bwConnect.WorkerSupportsCancellation = true;
            this.bwConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnect_DoWork);
            this.bwConnect.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwConnect_ProgressChanged);
            this.bwConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwConnect_RunWorkerCompleted);
            // 
            // bwMeasure
            // 
            this.bwMeasure.WorkerReportsProgress = true;
            this.bwMeasure.WorkerSupportsCancellation = true;
            this.bwMeasure.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMeasure_DoWork);
            this.bwMeasure.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMeasure_RunWorkerCompleted);
            // 
            // bwBuildReport
            // 
            this.bwBuildReport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwBuildReport_DoWork);
            this.bwBuildReport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwBuildReport_RunWorkerCompleted);
            // 
            // miExport
            // 
            this.miExport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_export;
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(152, 22);
            this.miExport.Text = "导出(&E)";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
            // 
            // btnRefreshTriggerChannel
            // 
            this.btnRefreshTriggerChannel.BackColor = System.Drawing.SystemColors.Control;
            this.btnRefreshTriggerChannel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefreshTriggerChannel.Image = global::ChamberPressureGauge.Properties.Resources.Refresh;
            this.btnRefreshTriggerChannel.Location = new System.Drawing.Point(473, 25);
            this.btnRefreshTriggerChannel.Name = "btnRefreshTriggerChannel";
            this.btnRefreshTriggerChannel.Size = new System.Drawing.Size(24, 24);
            this.btnRefreshTriggerChannel.TabIndex = 4;
            this.btnRefreshTriggerChannel.UseVisualStyleBackColor = false;
            this.btnRefreshTriggerChannel.Click += new System.EventHandler(this.btnRefreshTriggerChannel_Click);
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
            this.tbReport.ToolTipText = "生成报告";
            this.tbReport.Click += new System.EventHandler(this.Report);
            // 
            // tbConfig
            // 
            this.tbConfig.AutoSize = false;
            this.tbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbConfig.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_config;
            this.tbConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbConfig.Name = "tbConfig";
            this.tbConfig.Size = new System.Drawing.Size(84, 84);
            this.tbConfig.Text = "toolStripButton1";
            this.tbConfig.ToolTipText = "配置";
            this.tbConfig.Click += new System.EventHandler(this.ShowConfigWindow);
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
            // miConnect
            // 
            this.miConnect.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_connect;
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(151, 22);
            this.miConnect.Text = "开始连接(&C)";
            this.miConnect.Click += new System.EventHandler(this.Connect);
            // 
            // miConfig
            // 
            this.miConfig.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_config;
            this.miConfig.Name = "miConfig";
            this.miConfig.Size = new System.Drawing.Size(151, 22);
            this.miConfig.Text = "配置参数(&O)...";
            this.miConfig.Click += new System.EventHandler(this.ShowConfigWindow);
            // 
            // miExit
            // 
            this.miExit.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_close;
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(151, 22);
            this.miExit.Text = "退出(&E)";
            this.miExit.Click += new System.EventHandler(this.WinClosing);
            // 
            // miStart
            // 
            this.miStart.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_start_listening;
            this.miStart.Name = "miStart";
            this.miStart.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miStart.Size = new System.Drawing.Size(152, 22);
            this.miStart.Text = "开始测量";
            this.miStart.Click += new System.EventHandler(this.Start);
            // 
            // miReset
            // 
            this.miReset.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_reset;
            this.miReset.Name = "miReset";
            this.miReset.Size = new System.Drawing.Size(152, 22);
            this.miReset.Text = "复位(&R)";
            this.miReset.Click += new System.EventHandler(this.Reset);
            // 
            // miImport
            // 
            this.miImport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_import;
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(152, 22);
            this.miImport.Text = "导入(&I)";
            // 
            // miChart
            // 
            this.miChart.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_chart;
            this.miChart.Name = "miChart";
            this.miChart.Size = new System.Drawing.Size(116, 22);
            this.miChart.Text = "图表(&C)";
            // 
            // miReport
            // 
            this.miReport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_report;
            this.miReport.Name = "miReport";
            this.miReport.Size = new System.Drawing.Size(116, 22);
            this.miReport.Text = "报告(&R)";
            this.miReport.Click += new System.EventHandler(this.Report);
            // 
            // tbImport
            // 
            this.tbImport.AutoSize = false;
            this.tbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbImport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_import;
            this.tbImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(84, 84);
            this.tbImport.ToolTipText = "导入";
            // 
            // tbExport
            // 
            this.tbExport.AutoSize = false;
            this.tbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbExport.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_export;
            this.tbExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbExport.Name = "tbExport";
            this.tbExport.Size = new System.Drawing.Size(84, 84);
            this.tbExport.ToolTipText = "导出";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1043, 719);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbChart);
            this.Controls.Add(this.gbTotalChannel);
            this.Controls.Add(this.grpLog);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.gbTotalChannel.ResumeLayout(false);
            this.gbTotalChannel.PerformLayout();
            this.gbMeasure.ResumeLayout(false);
            this.gbMeasure.PerformLayout();
            this.tcChannel.ResumeLayout(false);
            this.tpPressure.ResumeLayout(false);
            this.tpDigital.ResumeLayout(false);
            this.tpSpeed.ResumeLayout(false);
            this.gbChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timChannelUpdate)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem miReport;
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
        private System.Windows.Forms.GroupBox gbTotalChannel;
        private System.Windows.Forms.GroupBox gbChart;
        private System.Timers.Timer timChannelUpdate;
        private System.Windows.Forms.TabControl tcChannel;
        private System.Windows.Forms.TabPage tpPressure;
        private System.Windows.Forms.TabPage tpDigital;
        private System.Windows.Forms.ComboBox cbPressureTriggerChannel;
        private System.Windows.Forms.Label lblTriggerChannel;
        private System.Windows.Forms.ComboBox cbTriggerMode;
        private System.Windows.Forms.Label lblTriggerMode;
        private System.Windows.Forms.Button btnRefreshTriggerChannel;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker bwConnect;
        private System.ComponentModel.BackgroundWorker bwMeasure;
        private System.Windows.Forms.ToolStripButton tbConfig;
        private Controls.Other.CountDown CountDown;
        private System.ComponentModel.BackgroundWorker bwBuildReport;
        private Controls.Channel.PressureChannelControl pcc6;
        private Controls.Channel.PressureChannelControl pcc5;
        private Controls.Channel.PressureChannelControl pcc4;
        private Controls.Channel.PressureChannelControl pcc3;
        private Controls.Channel.PressureChannelControl pcc2;
        private Controls.Channel.PressureChannelControl pcc1;
        private Controls.Channel.DigitalChannelControl dcc4;
        private Controls.Channel.DigitalChannelControl dcc3;
        private Controls.Channel.DigitalChannelControl dcc2;
        private Controls.Channel.DigitalChannelControl dcc1;
        private System.Windows.Forms.Label lblDisconnected;
        private Controls.Chart.MyChart mcChart;
        private System.Windows.Forms.GroupBox gbMeasure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtResultDigitalTriggerLast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResultDigitalTriggerStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResultTotalTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDigitalTriggerChannel;
        private System.Windows.Forms.TabPage tpSpeed;
        private Controls.Channel.SpeedChannelControl scc;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStripButton tbImport;
        private System.Windows.Forms.ToolStripButton tbExport;
    }
}

