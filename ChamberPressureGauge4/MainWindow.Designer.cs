namespace ChamberPressureGauge
{
    partial class Main
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
            this.menMain = new System.Windows.Forms.MenuStrip();
            this.miConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miSConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miData = new System.Windows.Forms.ToolStripMenuItem();
            this.miTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.miReset = new System.Windows.Forms.ToolStripMenuItem();
            this.miResult = new System.Windows.Forms.ToolStripMenuItem();
            this.miChart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.查看当前报告RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取现有报告EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staMain = new System.Windows.Forms.StatusStrip();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menMain
            // 
            this.menMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConnect,
            this.miData,
            this.miResult});
            this.menMain.Location = new System.Drawing.Point(0, 0);
            this.menMain.Name = "menMain";
            this.menMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menMain.Size = new System.Drawing.Size(600, 25);
            this.menMain.TabIndex = 0;
            this.menMain.Text = "menuStrip1";
            // 
            // miConnect
            // 
            this.miConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miConfig,
            this.toolStripMenuItem2,
            this.miSConnect,
            this.toolStripMenuItem1,
            this.miExit});
            this.miConnect.Name = "miConnect";
            this.miConnect.Size = new System.Drawing.Size(60, 21);
            this.miConnect.Text = "连接(&C)";
            // 
            // miConfig
            // 
            this.miConfig.Name = "miConfig";
            this.miConfig.Size = new System.Drawing.Size(142, 22);
            this.miConfig.Text = "配置参数(&O)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 6);
            // 
            // miSConnect
            // 
            this.miSConnect.Name = "miSConnect";
            this.miSConnect.Size = new System.Drawing.Size(142, 22);
            this.miSConnect.Text = "开始连接(&C)";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(142, 22);
            this.miExit.Text = "退出(&E)";
            // 
            // miData
            // 
            this.miData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miTest,
            this.toolStripMenuItem3,
            this.miReset});
            this.miData.Name = "miData";
            this.miData.Size = new System.Drawing.Size(61, 21);
            this.miData.Text = "数据(&D)";
            // 
            // miTest
            // 
            this.miTest.Name = "miTest";
            this.miTest.Size = new System.Drawing.Size(139, 22);
            this.miTest.Text = "开始测量(&T)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(136, 6);
            // 
            // miReset
            // 
            this.miReset.Name = "miReset";
            this.miReset.Size = new System.Drawing.Size(139, 22);
            this.miReset.Text = "复位(&R)";
            // 
            // miResult
            // 
            this.miResult.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChart,
            this.toolStripMenuItem4,
            this.查看当前报告RToolStripMenuItem,
            this.读取现有报告EToolStripMenuItem});
            this.miResult.Name = "miResult";
            this.miResult.Size = new System.Drawing.Size(60, 21);
            this.miResult.Text = "结果(&R)";
            // 
            // miChart
            // 
            this.miChart.Name = "miChart";
            this.miChart.Size = new System.Drawing.Size(164, 22);
            this.miChart.Text = "查看图表(&C)";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(161, 6);
            // 
            // 查看当前报告RToolStripMenuItem
            // 
            this.查看当前报告RToolStripMenuItem.Name = "查看当前报告RToolStripMenuItem";
            this.查看当前报告RToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.查看当前报告RToolStripMenuItem.Text = "查看当前报告(&R)";
            // 
            // 读取现有报告EToolStripMenuItem
            // 
            this.读取现有报告EToolStripMenuItem.Name = "读取现有报告EToolStripMenuItem";
            this.读取现有报告EToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.读取现有报告EToolStripMenuItem.Text = "读取现有报告(&E)";
            // 
            // staMain
            // 
            this.staMain.Location = new System.Drawing.Point(0, 340);
            this.staMain.Name = "staMain";
            this.staMain.Size = new System.Drawing.Size(600, 22);
            this.staMain.TabIndex = 1;
            // 
            // tbMain
            // 
            this.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.tbMain.Location = new System.Drawing.Point(0, 25);
            this.tbMain.Name = "tbMain";
            this.tbMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tbMain.Size = new System.Drawing.Size(600, 87);
            this.tbMain.TabIndex = 2;
            this.tbMain.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_connect;
            this.btnConnect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(84, 84);
            this.btnConnect.Text = "toolStripButton1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_start_listening;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(84, 84);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_reset;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 84);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_chart;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(84, 84);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_report;
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(84, 84);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::ChamberPressureGauge.Properties.Resources.toolbar_close;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(84, 84);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 222);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据结果";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(253, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 222);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图表结果";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 362);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.staMain);
            this.Controls.Add(this.menMain);
            this.MainMenuStrip = this.menMain;
            this.Name = "Main";
            this.Text = "膛压仪发射参数测试仪";
            this.menMain.ResumeLayout(false);
            this.menMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menMain;
        private System.Windows.Forms.ToolStripMenuItem miConnect;
        private System.Windows.Forms.ToolStripMenuItem miData;
        private System.Windows.Forms.ToolStripMenuItem miConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miSConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miResult;
        private System.Windows.Forms.StatusStrip staMain;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripMenuItem miTest;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miReset;
        private System.Windows.Forms.ToolStripMenuItem miChart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem 查看当前报告RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取现有报告EToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

