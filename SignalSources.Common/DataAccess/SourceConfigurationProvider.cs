using SignalSources.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SignalSources.Common.DataAccess
{
    public partial class SourceConfigurationProvider : IDataAccess<SourceConfiguration>
    {
        public class SourceConfigurationData
        {
            public List<SourceConfiguration> SourceConfigurations { get; set; }
        }
        private readonly string path;

        private SourceConfigurationProvider(string path)
        {
            this.path = path;
        }
        public IEnumerable<SourceConfiguration> GetSourceConfigurations()
        {

            string jsonString = File.ReadAllText(this.path);
            var ret = new List<SourceConfiguration>();
            var temp = JsonSerializer.Deserialize<SourceConfigurationData>(jsonString);
            ret = temp.SourceConfigurations.Where(x => x.Active == true).ToList();
            return ret;
        }
        public void Save(IEnumerable<SourceConfiguration> sourceConfigurations)
        {
            string jsonString = JsonSerializer.Serialize<SourceConfigurationData>(new SourceConfigurationData { SourceConfigurations = new List<SourceConfiguration>(sourceConfigurations) });
            File.WriteAllText(this.path, jsonString);
        }
    }
}
