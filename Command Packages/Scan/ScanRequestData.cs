using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record ScanRequestData
    {
        [JsonPropertyName("account_topic")]
        public string AccountTopic { get; set; } = "reserve";
    }
}
