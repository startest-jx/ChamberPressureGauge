namespace ChamberPressureGauge.Controls
{
    partial class PressureChannel
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
            this.btnDecrease = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.txtCalibration = new System.Windows.Forms.TextBox();
            this.lblCalibration = new System.Windows.Forms.Label();
            this.txtChannelData = new ChamberPressureGauge.Controls.ChannelData();
            this.cbRange = new System.Windows.Forms.ComboBox();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.btnDecrease);
            this.gbTitle.Controls.Add(this.btnIncrease);
            this.gbTitle.Controls.Add(this.txtCalibration);
            this.gbTitle.Controls.Add(this.lblCalibration);
            this.gbTitle.Controls.Add(this.txtChannelData);
            this.gbTitle.Controls.Add(this.cbRange);
            this.gbTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbTitle.Location = new System.Drawing.Point(0, 0);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(230, 85);
            this.gbTitle.TabIndex = 0;
            this.gbTitle.TabStop = false;
            // 
            // btnDecrease
            // 
            this.btnDecrease.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDecrease.Location = new System.Drawing.Point(185, 48);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(40, 28);
            this.btnDecrease.TabIndex = 5;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.Increase);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIncrease.Location = new System.Drawing.Point(145, 48);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(40, 28);
            this.btnIncrease.TabIndex = 4;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.Decrease);
            // 
            // txtCalibration
            // 
            this.txtCalibration.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCalibration.Location = new System.Drawing.Point(59, 53);
            this.txtCalibration.Name = "txtCalibration";
            this.txtCalibration.Size = new System.Drawing.Size(78, 23);
            this.txtCalibration.TabIndex = 3;
            this.txtCalibration.LostFocus += new System.EventHandler(this.txtCalibration_LostFocus);
            // 
            // lblCalibration
            // 
            this.lblCalibration.AutoSize = true;
            this.lblCalibration.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCalibration.Location = new System.Drawing.Point(6, 56);
            this.lblCalibration.Name = "lblCalibration";
            this.lblCalibration.Size = new System.Drawing.Size(47, 17);
            this.lblCalibration.TabIndex = 2;
            this.lblCalibration.Text = "校准值:";
            // 
            // txtChannelData
            // 
            this.txtChannelData.Font = new System.Drawing.Font("Axure Handwriting", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannelData.Location = new System.Drawing.Point(6, 20);
            this.txtChannelData.Name = "txtChannelData";
            this.txtChannelData.ReadOnly = true;
            this.txtChannelData.Size = new System.Drawing.Size(131, 22);
            this.txtChannelData.TabIndex = 0;
            this.txtChannelData.TabStop = false;
            this.txtChannelData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbRange
            // 
            this.cbRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbRange.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbRange.FormattingEnabled = true;
            this.cbRange.Items.AddRange(new object[] {
            "1 MPa",
            "2 MPa",
            "5 MPa",
            "10 MPa",
            "40 MPa"});
            this.cbRange.Location = new System.Drawing.Point(145, 17);
            this.cbRange.Name = "cbRange";
            this.cbRange.Size = new System.Drawing.Size(80, 25);
            this.cbRange.TabIndex = 1;
            this.cbRange.SelectedIndexChanged += new System.EventHandler(this.cbRange_SelectedIndexChanged);
            // 
            // PressureChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbTitle);
            this.Name = "PressureChannel";
            this.Size = new System.Drawing.Size(230, 85);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTitle;
        private ChannelData txtChannelData;
        private System.Windows.Forms.ComboBox cbRange;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.TextBox txtCalibration;
        private System.Windows.Forms.Label lblCalibration;
        private System.Windows.Forms.Button btnDecrease;
    }
}
