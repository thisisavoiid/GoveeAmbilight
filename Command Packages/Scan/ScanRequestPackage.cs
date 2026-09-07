using GoveeAmbilight.Command_Packages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public class ScanRequestPackage : IGoveeRequestPackage
    {
        [JsonPropertyName("msg")]
        public ScanMessage Message { get; set; } = new ScanMessage();
    }
}
