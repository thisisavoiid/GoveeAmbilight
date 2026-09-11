using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace GoveeAmbilight
{
    public record struct GoveeColor
    {
        [JsonPropertyName("r")]
        public required long Red { get; set; } = 0;

        [JsonPropertyName("g")]
        public required long Green { get; set; } = 0;

        [JsonPropertyName("b")]
        public required long Blue { get; set; } = 0;

        [SetsRequiredMembers]
        public GoveeColor(long r, long g, long b)
        {
            this.Red = r;
            Green = g;
            Blue = b;
        }

        //public static GoveeColor operator +(GoveeColor a, GoveeColor b)
        //{
        //    GoveeColor result = new GoveeColor(
        //        a.Red + b.Red,
        //        a.Green + b.Green,
        //        a.Blue + b.Blue
        //    );

        //    return result;
        //}

        //public static GoveeColor operator /(GoveeColor color, int num)
        //{
        //    GoveeColor result = new GoveeColor(
        //        color.Red / num,
        //        color.Green / num,
        //        color.Blue / num
        //    );

        //    return result;
        //}

        //public static GoveeColor operator -(GoveeColor a, GoveeColor b)
        //{
        //    GoveeColor result = new GoveeColor(
        //        a.Red - b.Red,
        //        a.Green - b.Green,
        //        a.Blue - b.Blue
        //    );

        //    return result;
        //}
    }
}