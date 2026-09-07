using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record struct ColorWcMessage(
        [property: JsonPropertyName("data")] ColorWcRequestData Data
        )
    {
        [JsonPropertyName("cmd")]
        public string Command { get; set; } = "colorwc";
    }
}