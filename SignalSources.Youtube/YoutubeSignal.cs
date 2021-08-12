using SignalSources.Interfaces;
using System;

namespace SignalSources.Youtube
{
    public class YoutubeSignal : ISignal
    {
        public YoutubeSignal(DateTime date, string text, SignalLevel level)
        {
            this.Date = date;
            this.Text = text;
            this.Level = level;
        }

        public DateTime Date { get; init; }

        public string Text { get; init; }

        public SignalLevel Level { get; set; }
        public string From { get; init; }
    }
}
