using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Tools.Configuration;

namespace ChamberPressureGauge.UI
{
    public partial class ConfigWindow : Form
    {
        public Configuration Config { set; get; }
        public ConfigWindow(ref Configuration config)
        {
            InitializeComponent();
            Config = config;
            LoadFromConfig();
        }

        private void LoadFromConfig()
        {
            try
            {
                // 载入连接信息
                var commandPanel = (JObject)Config.Connect["CommandPanel"];
                var dataPanel = (JObject)Config.Connect["DataPanel"];
                txtCmdIP.Text = commandPanel["IPAddress"].ToString();
                txtCmdPort.Text = commandPanel["Port"].ToString();
                txtCmdTimeOut.Text = commandPanel["TimeOut"].ToString();
                txtCmdBufferSize.Text = commandPanel["BufferSize"].ToString();
                txtDataIP.Text = dataPanel["IPAddress"].ToString();
                txtDataPort.Text = dataPanel["Port"].ToString();
                txtDataTimeOut.Text = dataPanel["TimeOut"].ToString();
                txtDataBufferSize.Text = dataPanel["BufferSize"].ToString();
                // 载入测量信息
                var autoTrigger = (JObject)Config.Measure["AutoTrigger"];
                var manualTrigger = (JObject)Config.Measure["ManualTrigger"];
                cbDefaultMeasureMode.SelectedIndex = Config.Measure["DefaultMode"].ToString() == "AutoTrigger" ? 0 : 1;
                cbDefaultPressureChannel.SelectedIndex = (int)autoTrigger["DefaultPressureChannel"];
                cbDefaultDigitalChannel.SelectedIndex = (int)autoTrigger["DefaultDigitalChannel"];
                rbTriggerConditionThreshold.Checked = autoTrigger["Condition"].ToString() == "Threshold";
                rbTriggerConditionIncrement.Checked = autoTrigger["Condition"].ToString() == "Increment";
                txtTriggerConditionValue.Value = (decimal)autoTrigger["Value"];
                txtAutoMeasureTime.Value = (decimal)autoTrigger["MeasureTime"];
                txtManualMeasureTime.Value = (decimal)manualTrigger["MeasureTime"];
                // 载入数据信息
                var mappingRule = (JArray)Config.Data["ChannelMappingRule"];
                foreach (var t in mappingRule)
                {
                    var u = (JObject)t;
                    var logicalChannel = Convert.ToInt32(u["LogicalChannel"]) + 1;
                    var bit = u["Bit"];
                    lstChannelMap.Items.Add($"{logicalChannel} => {bit}");
                }
                // 载入图表信息
                cbChartQuality.SelectedIndex = (int)Config.Chart["Quality"];
                txtChartPointCount.Text = Config.Chart["PointCount"].ToString();
                // 载入报告信息
                var content = (JObject)Config.Report["Content"];
                var build = (JObject)Config.Report["Build"];
                chkTitle.Checked = (int)content["ShowTitle"] != 0;
                txtTitle.Text = content["Title"].ToString();
                chkAuthor.Checked = (int)content["ShowAuthor"] != 0;
                txtAuthor.Text = content["Author"].ToString();
                chkSubject.Checked = (int)content["ShowSubject"] != 0;
                txtSubject.Text = content["Subject"].ToString();

                chkDate.Checked = (int)content["ShowDate"] != 0;
                chkTrigger.Checked = (int)content["ShowTrigger"] != 0;
                chkPressure.Checked = (int)content["ShowPressure"] != 0;
                chkDigital.Checked = (int)content["ShowDigital"] != 0;
                chkChart.Checked = (int)content["ShowChart"] != 0;
                txtBuildPath.Text = build["Path"].ToString();
                chkAutoOpen.Checked = (int)build["AutoOpen"] != 0;
            }
            catch
            {
                MessageBox.Show(@"配置文件已损坏，请修复后重启程序.");
                Close();
            }
        }

        private void SaveToConfig()
        {
            try
            {
                // 保存连接信息
                var commandPanel = (JObject)Config.Connect["CommandPanel"];
                var dataPanel = (JObject)Config.Connect["DataPanel"];
                commandPanel["IPAddress"] = txtCmdIP.Text;
                commandPanel["Port"] = int.Parse(txtCmdPort.Text);
                commandPanel["TimeOut"] = int.Parse(txtCmdTimeOut.Text);
                commandPanel["BufferSize"] = int.Parse(txtCmdBufferSize.Text);
                dataPanel["IPAddress"] = txtDataIP.Text;
                dataPanel["Port"] = int.Parse(txtDataPort.Text);
                dataPanel["TimeOut"] = int.Parse(txtDataTimeOut.Text);
                dataPanel["BufferSize"] = int.Parse(txtDataBufferSize.Text);
                // 保存测量信息
                var autoTrigger = (JObject)Config.Measure["AutoTrigger"];
                var manualTrigger = (JObject)Config.Measure["ManualTrigger"];
                Config.Measure["DefaultMode"] = cbDefaultMeasureMode.SelectedIndex == 0 ? "AutoTrigger" : "ManualTrigger";
                autoTrigger["DefaultPressureChannel"] = cbDefaultPressureChannel.SelectedIndex;
                autoTrigger["DefaultDigitalChannel"] = cbDefaultDigitalChannel.SelectedIndex;
                autoTrigger["Condition"] = rbTriggerConditionThreshold.Checked ? "Threshold" : "Increment";
                autoTrigger["Value"] = txtTriggerConditionValue.Value;
                autoTrigger["MeasureTime"] = txtAutoMeasureTime.Value;
                manualTrigger["MeasureTime"] = txtManualMeasureTime.Value;
                // 保存数据信息
                var mappingRule = (JArray)Config.Data["ChannelMappingRule"];
                mappingRule.Clear();
                foreach (var t in lstChannelMap.Items)
                {
                    var u = t.ToString();
                    GetMappingFromString(u, out string logicalChannel, out string bit);
                    var v = new JObject
                    {
                        ["LogicalChannel"] = int.Parse(logicalChannel) - 1,
                        ["Bit"] = int.Parse(bit)
                    };
                    mappingRule.Add(v);
                }
                // 保存图表信息
                Config.Chart["Quality"] = cbChartQuality.SelectedIndex;
                Config.Chart["PointCount"] = int.Parse(txtChartPointCount.Text);
                // 保存报告信息
                var content = (JObject)Config.Report["Content"];
                var build = (JObject)Config.Report["Build"];
                content["ShowTitle"] = chkTitle.Checked ? 1 : 0;
                content["Title"] = txtTitle.Text;
                content["ShowAuthor"] = chkAuthor.Checked ? 1 : 0;
                content["Author"] = txtAuthor.Text;
                content["ShowSubject"] = chkSubject.Checked ? 1 : 0;
                content["Subject"] = txtSubject.Text;

                content["ShowDate"] = chkDate.Checked ? 1 : 0;
                content["ShowTrigger"] = chkTrigger.Checked ? 1 : 0;
                content["ShowPressure"] = chkPressure.Checked ? 1 : 0;
                content["ShowDigital"] = chkDigital.Checked ? 1 : 0;
                content["ShowChart"] = chkChart.Checked ? 1 : 0;

                build["Path"] = txtBuildPath.Text;
                build["AutoOpen"] = chkAutoOpen.Checked ? 1 : 0;
            }
            catch
            {
                MessageBox.Show(@"配置信息异常，保存失败.");
            }
            
        }

        private static void GetMappingFromString(string str, out string channel, out string bit)
        {
            var splitArray = str.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
            channel = splitArray[0].Trim();
            bit = splitArray[1].Trim();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            SaveToConfig();
            Config.SaveToFile();
            Close();
        }

        private void btnRuleAdd_Click(object sender, EventArgs e)
        {
            if (cbChannel.SelectedIndex == -1 || cbBit.SelectedIndex == -1)
            {
                MessageBox.Show(@"请选择映射通道/位.", @"错误");
                return;
            }
            var itemString = $"{cbChannel.SelectedItem} => {cbBit.SelectedItem}";
            lstChannelMap.Items.Add(itemString);
        }

        private void btnRuleDel_Click(object sender, EventArgs e)
        {
            lstChannelMap.Items.RemoveAt(lstChannelMap.SelectedIndex);
        }

        private void btnRuleEdit_Click(object sender, EventArgs e)
        {
            if (cbChannel.SelectedIndex == -1 || cbBit.SelectedIndex == -1)
            {
                MessageBox.Show(@"请选择映射通道/位.", @"错误");
                return;
            }
            var itemString = $"{cbChannel.SelectedItem} => {cbBit.SelectedItem}";
            lstChannelMap.Items[lstChannelMap.SelectedIndex] = itemString;
        }

        private void btnChooseDirectory_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                Description = @"请选择导出报告文件夹"
            };
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (string.IsNullOrEmpty(dialog.SelectedPath))
            {
                MessageBox.Show(@"文件夹路径不能为空", @"提示");
                return;
            }
            txtBuildPath.Text = dialog.SelectedPath;
        }

        private void lstChannelMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMappingFromString(lstChannelMap.SelectedItem.ToString(), out string logicalChannel, out string bit);
            cbChannel.SelectedItem = logicalChannel;
            cbBit.SelectedItem = bit;
        }
    }
}
