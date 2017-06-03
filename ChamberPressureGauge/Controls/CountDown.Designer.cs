namespace ChamberPressureGauge.Controls
{
    partial class CountDown
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
            this.txtCountDown = new System.Windows.Forms.TextBox();
            this.bwCountDown = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtCountDown
            // 
            this.txtCountDown.Font = new System.Drawing.Font("微软雅黑", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCountDown.Location = new System.Drawing.Point(3, 3);
            this.txtCountDown.Name = "txtCountDown";
            this.txtCountDown.Size = new System.Drawing.Size(210, 134);
            this.txtCountDown.TabIndex = 0;
            this.txtCountDown.Text = "0.00";
            // 
            // bwCountDown
            // 
            this.bwCountDown.WorkerSupportsCancellation = true;
            this.bwCountDown.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCountDown_DoWork);
            this.bwCountDown.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCountDown_RunWorkerCompleted);
            // 
            // CountDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCountDown);
            this.Name = "CountDown";
            this.Size = new System.Drawing.Size(216, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCountDown;
        private System.ComponentModel.BackgroundWorker bwCountDown;
    }
}
