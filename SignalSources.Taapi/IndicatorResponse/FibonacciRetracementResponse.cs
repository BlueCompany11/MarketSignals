using System;
namespace SignalSources.Taapi.IndicatorResponse
{
    public class FibonacciRetracementResponse
    {
        public double Value { get; set; }
        public string Trend { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public DateTimeOffset StartTimestamp { get; set; }
        public DateTimeOffset EndTimestamp { get; set; }

    }
}
