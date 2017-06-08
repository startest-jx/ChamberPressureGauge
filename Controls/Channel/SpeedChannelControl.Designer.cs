namespace Controls.Channel
{
    partial class SpeedChannelControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.agMain = new LiveCharts.WinForms.AngularGauge();
            this.lblNoDevice = new System.Windows.Forms.Label();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.agMain);
            this.gbTitle.Controls.Add(this.lblNoDevice);
            this.gbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbTitle.Location = new System.Drawing.Point(0, 0);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(239, 85);
            this.gbTitle.TabIndex = 0;
            this.gbTitle.TabStop = false;
            // 
            // agMain
            // 
            this.agMain.BackColorTransparent = true;
            this.agMain.Location = new System.Drawing.Point(6, 17);
            this.agMain.Name = "agMain";
            this.agMain.Size = new System.Drawing.Size(118, 115);
            this.agMain.TabIndex = 6;
            // 
            // lblNoDevice
            // 
            this.lblNoDevice.AutoSize = true;
            this.lblNoDevice.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoDevice.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNoDevice.Location = new System.Drawing.Point(122, -11);
            this.lblNoDevice.Name = "lblNoDevice";
            this.lblNoDevice.Size = new System.Drawing.Size(203, 43);
            this.lblNoDevice.TabIndex = 5;
            this.lblNoDevice.Text = "NO DEVICE";
            // 
            // DigitalChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTitle);
            this.Name = "DigitalChannelControl";
            this.Size = new System.Drawing.Size(239, 85);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.Label lblNoDevice;
        private LiveCharts.WinForms.AngularGauge agMain;
    }
}
