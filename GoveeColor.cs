using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record struct GoveeColor
    {
        [JsonPropertyName("r")]
        public required int Red { get; set; } = 0;

        [JsonPropertyName("g")]
        public required int Green { get; set; } = 0;

        [JsonPropertyName("b")]
        public required int Blue { get; set; } = 0;

        [SetsRequiredMembers]
        public GoveeColor(int r, int g, int b)
        {
            this.Red = r;
            Green = g;
            Blue = b;
        }
    }
}