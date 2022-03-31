using Newtonsoft.Json;

namespace WaterTransportAPI
{
    public class ApiConfigs
    {
        public class Config
        {
            public class Characteristic
            {
                [JsonProperty("Sys")]
                public string SystemChar { get; set; } = string.Empty;

                [JsonProperty("Tp")]
                public string TpChar { get; set; } = string.Empty;
            }

            [JsonProperty("Url")]
            public string Url { get; set; } = string.Empty;

            [JsonProperty("KeyName")]
            public string KeyName { get; set; } = string.Empty;

            [JsonProperty("KeyValue")]
            public string KeyValue { get; set; } = string.Empty;

            [JsonProperty("Schema")]
            public List<Characteristic> Schema { get; set; } = new List<Characteristic>();
        }

        [JsonProperty("DataSources")]
        public List<Config> ListConfigs { get; set; } = new List<Config>();

        [JsonProperty("Chars")]
        public string Chars { get; set; } = string.Empty;
    }
}