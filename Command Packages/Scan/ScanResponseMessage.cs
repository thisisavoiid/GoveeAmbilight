
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record ScanResponseMessage
    {
        [JsonPropertyName("cmd")]
        public string Command { get; set; } = "scan";

        [JsonPropertyName("data")]
        public ScanResponseData Data { get; set; } = new ScanResponseData();
    }
}