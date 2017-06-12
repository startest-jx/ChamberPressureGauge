namespace Controls.Channel
{
    partial class PressureChannelControl
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
            //this.lblNoDevice = new System.Windows.Forms.Label();
            this.txtCalibration = new System.Windows.Forms.NumericUpDown();
            this.cbRange = new System.Windows.Forms.ComboBox();
            this.gbTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalibration)).BeginInit();
            this.SuspendLayout();
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.agMain);
            this.gbTitle.Controls.Add(this.txtCalibration);
            this.gbTitle.Controls.Add(this.cbRange);
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
            // txtCalibration
            // 
            this.txtCalibration.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtCalibration.DecimalPlaces = 4;
            this.txtCalibration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.txtCalibration.Location = new System.Drawing.Point(130, 53);
            this.txtCalibration.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(94, 23);
            this.txtCalibration.TabIndex = 3;
            // 
            // cbRange
            // 
            this.cbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRange.FormattingEnabled = true;
            this.cbRange.Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbRange.Location = new System.Drawing.Point(130, 17);
            this.cbRange.Name = "cbRange";
            this.cbRange.Size = new System.Drawing.Size(95, 25);
            this.cbRange.TabIndex = 1;
            this.cbRange.SelectedIndexChanged += new System.EventHandler(this.cbRange_SelectedIndexChanged);
            // 
            // PressureChannelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTitle);
            this.Name = "PressureChannelControl";
            this.Size = new System.Drawing.Size(239, 85);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCalibration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.ComboBox cbRange;
        private System.Windows.Forms.NumericUpDown txtCalibration;
        //private System.Windows.Forms.Label lblNoDevice;
        private LiveCharts.WinForms.AngularGauge agMain;
    }
}
