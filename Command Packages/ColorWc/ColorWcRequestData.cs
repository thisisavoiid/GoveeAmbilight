using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record struct ColorWcRequestData(
        [property: JsonPropertyName("color")] GoveeColor Color,
        [property: JsonPropertyName("colorTemInKelvin")] int ColorTemInKelvin
    );
}