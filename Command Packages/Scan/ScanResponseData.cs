using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record ScanResponseData
    {
        [JsonPropertyName("ip")]
        public string Ip { get; set; } = "";

        [JsonPropertyName("device")]
        public string Device { get; set; } = "";

        [JsonPropertyName("sku")]
        public string Sku { get; set; } = "";

        [JsonPropertyName("bleVersionHard")]
        public string BleVersionHard { get; set; } = "";

        [JsonPropertyName("bleVersionSoft")]
        public string BleVersionSoft { get; set; } = "";

        [JsonPropertyName("wifiVersionHard")]
        public string WifiVersionHard { get; set; } = "";

        [JsonPropertyName("wifiVersionSoft")]
        public string WifiVersionSoft { get; set; } = "";
    }
}