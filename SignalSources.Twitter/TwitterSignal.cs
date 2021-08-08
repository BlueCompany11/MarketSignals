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
            this.profileName = profileName;
            this.hashtags = hashtags;
            this.url = url;
            this.Text = this.CreateText();
        }

        private string CreateText()
        {
            var ret = new StringBuilder()
                .Append(this.Date)
                .AppendFormat("User: {0} twitted {1} \n", this.profileName, this.text)
                .Append("Hashtags: ")
                .AppendJoin("# ", this.hashtags)
                .AppendFormat("\nUrl: {0}", this.url);
            return ret.ToString();
        }
        private string profileName;
        private List<string> hashtags;
        private string url;
        private string text;
        public DateTime Date { get; init; }

        public string Text { get; init; }

        public SignalLevel Level { get; init; }
        public string From { get; init; }
}
}
