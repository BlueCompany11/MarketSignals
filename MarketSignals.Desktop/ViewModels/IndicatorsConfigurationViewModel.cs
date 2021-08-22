using Prism.Commands;
using Prism.Mvvm;
using SignalSources.Interfaces;
using SignalSources.Taapi;
using System.Collections.Generic;
namespace MarketSignals.Desktop.ViewModels
{
    internal class IndicatorsConfigurationViewModel : BindableBase
    {
        public IndicatorsConfigurationViewModel(TaapiConnection connection, Orchestrator orchestrator, ITaapiInfo taapiInfo)
        {
            this.connection = connection;
            this.orchestrator = orchestrator;
            this.taapiInfo = taapiInfo;
            this.SendRequestCommand = new DelegateCommand(this.SendRequest);
            this.IndicatorNames = taapiInfo.GetIndicators();
            this.PairNames = taapiInfo.GetPairNames();
            this.Intervals = taapiInfo.GetIntervals();
        }
        public DelegateCommand SendRequestCommand { get; private set; }

        private async void SendRequest()
        {
            switch (this.selectedIndicator)
            {
                case nameof(Indicators.CommodityChannelIndex):
                    this.orchestrator.PutRequest(async () => {
                        var ret = await this.connection.GetCommodityChannelIndex(this.SelectedPair, this.SelectedInverval);
                        this.ReturnedValue = ret.Value.ToString();
                    });
                    break;
                case nameof(Indicators.ChaikinMoneyFlow):
                    this.orchestrator.PutRequest(async () => {
                        var ret = await this.connection.GetChaikinMoneyFlow(this.SelectedPair, this.SelectedInverval);
                        this.ReturnedValue = ret.Value.ToString();
                    });
                    break;
                case nameof(Indicators.Doji):
                    this.orchestrator.PutRequest(async () => {
                        var ret = await this.connection.GetDoji(this.SelectedPair, this.SelectedInverval);
                        this.ReturnedValue = ret.Value.ToString();
                    });
                    break;
                case nameof(Indicators.ExponentialMovingAverage):
                    this.orchestrator.PutRequest(async () => {
                        var ret = await this.connection.GetExponentialMovingAverage(this.SelectedPair, this.SelectedInverval);
                        this.ReturnedValue = ret.Value.ToString();
                    });
                    break;
                case nameof(Indicators.FibonacciRetracement):
                    this.orchestrator.PutRequest(async () => {
                        var ret = await this.connection.GetFibonacciRetracement(this.SelectedPair, this.SelectedInverval);
                        this.ReturnedValue = ret.Value.ToString();
                    });
                    break;
                default:
                    break;
            }
            
        }
        private string returnedValue;
        public string ReturnedValue
        {
            get => this.returnedValue;
            set => this.SetProperty(ref this.returnedValue, value);
        }
        private List<string> indicatorNames;
        public List<string> IndicatorNames
        {
            get => this.indicatorNames;
            set => this.SetProperty(ref this.indicatorNames, value);
        }
        public List<string> pairNames;
        public List<string> PairNames
        {
            get => this.pairNames;
            set => this.SetProperty(ref this.pairNames, value);
        }
        private string selectedPair;
        public string SelectedPair
        {
            get => this.selectedPair;
            set => this.SetProperty(ref this.selectedPair, value);
        }
        private string selectedIndicator;
        public string SelectedIndicator
        {
            get => this.selectedIndicator;
            set => this.SetProperty(ref this.selectedIndicator, value);
        }
        private List<string> intervals;
        public List<string> Intervals
        {
            get => this.intervals;
            set => this.SetProperty(ref this.intervals, value);
        }
        private string selectedInverval;
        private readonly TaapiConnection connection;
        private readonly Orchestrator orchestrator;
        private readonly ITaapiInfo taapiInfo;

        public string SelectedInverval
        {
            get => this.selectedInverval;
            set => this.SetProperty(ref this.selectedInverval, value);
        }

    }
}
