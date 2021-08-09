namespace SignalSources.Taapi.IndicatorResponse
{
    public class IchimokuCloudResponse
    {
        public double Conversion { get; set; }
        public double Base { get; set; }
        public double SpanA { get; set; }
        public double SpanB { get; set; }
        public double CurrentSpanA { get; set; }
        public double CurrentSpanB { get; set; }
        public double LaggingSpanA { get; set; }
        public double LaggingSpanB { get; set; }
    }
}
