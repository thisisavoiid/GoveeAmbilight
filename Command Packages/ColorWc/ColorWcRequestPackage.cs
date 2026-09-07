using GoveeAmbilight.Command_Packages;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public class ColorWcRequestPackage : IGoveeRequestPackage
    {
        [JsonPropertyName("msg")]
        public ColorWcMessage Message { get; set; }

        public ColorWcRequestPackage(ColorWcMessage message)
        {
            Message = message;
        }
    }
}