using SignalSources.Interfaces;
using System;

namespace SignalSources.Youtube
{
    public class YoutubeSignal : ISignal
    {
        public YoutubeSignal(DateTime date, string text, SignalLevel level,string url, string from)
        {
            this.Date = date;
            this.Text = text;
            this.Level = level;
            this.Url = url;
            this.From = from;
        }

        public DateTime Date { get; init; }

        public string Text { get; init; }

        public SignalLevel Level { get; set; }
        public string Url { get; init; }
        public string From { get; init; }
    }
}
