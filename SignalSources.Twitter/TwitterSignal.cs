using SignalSources.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalSources.Twitter
{
    public class TwitterSignal : ISignal
    {
        public TwitterSignal(DateTime date, string text, SignalLevel level, string profileName, List<string> hashtags, string url)
        {
            this.Date = date;
            this.text = text;
            this.Level = level;
            this.hashtags = hashtags;
            this.Url = url;
            this.Text = this.CreateText();
            this.From = profileName;
        }

        private string CreateText()
        {
            if(this.hashtags.Count > 0)
            {
                this.hashtags[0] = this.hashtags[0].Insert(0, "#");
            }
            var ret = new StringBuilder()
                .AppendFormat(this.text)
                .AppendJoin("# ", this.hashtags);
            return ret.ToString();
        }
        private List<string> hashtags;
        private string text;
        public string Url { get; }
        public DateTime Date { get; init; }

        public string Text { get; init; }

        public SignalLevel Level { get; set; }
        public string From { get; init; }
}
}
