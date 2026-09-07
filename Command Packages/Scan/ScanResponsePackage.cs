using GoveeAmbilight.Command_Packages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public class ScanResponsePackage : IGoveeResponsePackage
    {
        [JsonPropertyName("msg")]
        public ScanResponseMessage Message { get; set; } = new ScanResponseMessage();
    }
}