using SignalSources.Interfaces;
using System.Collections.Generic;

namespace SignalSources.Taapi
{
    public class IndicatorsProvider : IIndicatorsProvider
    {
        public List<string> GetIndicators()
        {
            return new List<string> {
                nameof(Indicators.CommodityChannelIndex),
                nameof(Indicators.ChaikinMoneyFlow),
                nameof(Indicators.DirectionalMovementIndex),
                nameof(Indicators.Doji),
                nameof(Indicators.ExponentialMovingAverage),
                nameof(Indicators.FibonacciRetracement),
                nameof(Indicators.HullMovingAverage),
                nameof(Indicators.IchimokuCloud)
             };
        }
    }
}
