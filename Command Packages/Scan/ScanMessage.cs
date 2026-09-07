using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record ScanMessage
    {
        [JsonPropertyName("cmd")]
        public string Command { get; set; } = "scan";

        [JsonPropertyName("data")]
        public ScanRequestData Data { get; set; } = new ScanRequestData();
    }
}
