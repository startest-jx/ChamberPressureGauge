using System;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tools.Configuration
{
    public class Configuration
    {
        public string FileName { set; get; }
        private JObject _configTable;
        public JObject ConfigTable
        {
            set
            {
                _configTable = value;
                // 解析配置信息
                Connect = (JObject)_configTable["Connect"];
                Measure = (JObject)_configTable["Measure"];
                Data = (JObject)_configTable["Data"];
                Chart = (JObject)_configTable["Chart"];
                Report = (JObject)_configTable["Report"];
            }
            get
            {
                _configTable["Connect"] = Connect;
                _configTable["Measure"] = Measure;
                _configTable["Data"] = Data;
                _configTable["Chart"] = Chart;
                _configTable["Report"] = Report;
                return _configTable;
            }
        }
        public JObject Connect { set; get; }
        public JObject Measure { set; get; }
        private JObject _data;
        public JObject Data
        {
            set
            {
                _data = value;
                var mappingRuleArray = (JArray) _data["ChannelMappingRule"];
                MappingRule = new Hashtable();
                foreach (var t in mappingRuleArray)
                {
                    var channel = Convert.ToInt32(t["LogicalChannel"]);
                    var bit = Convert.ToInt32(t["Bit"]);
                    MappingRule[channel] = bit;
                }
            }
            get
            {
                var mappingRuleArray = new JArray();
                foreach(int t in MappingRule.Keys)
                {
                    var channel = t;
                    var bit = (int)MappingRule[t];
                    var u = new JObject
                    {
                        ["LogicalChannel"] = channel,
                        ["Bit"] = bit
                    };
                    mappingRuleArray.Add(u);
                }
                _data["ChannelMappingRule"] = mappingRuleArray;
                return _data;
            }
        }
        public JObject Chart { set; get; }
        public JObject Report { set; get; }

        private string HashString
        {
            set => ConfigTable = JsonConvert.DeserializeObject<JObject>(value);
            get => JsonConvert.SerializeObject(ConfigTable);
        }

        public Hashtable MappingRule { set; get; }

        public Configuration(string fileName) => FileName = fileName;

        public Configuration() { }

        public void LoadFromFile()
        {
            using (var sr = new StreamReader(FileName))
            {
                HashString = sr.ReadToEnd();
            }
        }

        public void SaveToFile()
        {
            using (var sw = new StreamWriter(FileName))
            {
                sw.Write(HashString);
            }
        }
    }
}
