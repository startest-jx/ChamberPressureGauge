namespace Controls.Chart
{
    partial class MyChart
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
            this.lvChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // lvChart
            // 
            this.lvChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvChart.Location = new System.Drawing.Point(0, 0);
            this.lvChart.Name = "lvChart";
            this.lvChart.Size = new System.Drawing.Size(333, 275);
            this.lvChart.TabIndex = 0;
            this.lvChart.Text = "cartesianChart1";
            // 
            // MyChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvChart);
            this.Name = "MyChart";
            this.Size = new System.Drawing.Size(333, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart lvChart;
    }
}
