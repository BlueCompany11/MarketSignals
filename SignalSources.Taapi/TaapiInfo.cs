using SignalSources.Interfaces;
using System.Collections.Generic;

namespace SignalSources.Taapi
{
    public class TaapiInfo : ITaapiInfo
    {
        private readonly IIndicatorsProvider indicatorsProvider;
        private readonly IIntervalsProvider intervalsProvider;
        private readonly IPairNamesProvider pairNamesProvider;

        public TaapiInfo(IIndicatorsProvider indicatorsProvider, IIntervalsProvider intervalsProvider, IPairNamesProvider pairNamesProvider)
        {
            this.indicatorsProvider = indicatorsProvider;
            this.intervalsProvider = intervalsProvider;
            this.pairNamesProvider = pairNamesProvider;
        }
        public List<string> GetIndicators()
        {
            return this.indicatorsProvider.GetIndicators();
        }

        public List<string> GetIntervals()
        {
            return this.intervalsProvider.GetIntervals();
        }

        public List<string> GetPairNames()
        {
            return this.pairNamesProvider.GetPairNames();
        }
    }
}
