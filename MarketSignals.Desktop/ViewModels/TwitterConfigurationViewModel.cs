using Prism.Commands;
using Prism.Mvvm;
using SignalSources.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarketSignals.Desktop.ViewModels
{
    internal class TwitterConfigurationViewModel : BindableBase
    {
        private ObservableCollection<SourceConfiguration> signalSources;
        public ObservableCollection<SourceConfiguration> SignalSources
        {
            get => this.signalSources;
            set => this.SetProperty(ref this.signalSources, value);
        }
        public TwitterConfigurationViewModel(ISignalSourceConfiguration signalSourceConfiguration, IDataAccess<SourceConfiguration> dataAccess)
        {
            this.SignalSources = new(signalSourceConfiguration.GetSourceConfigurations());
            this.AddCommand = new DelegateCommand(this.Add);
            this.dataAccess = dataAccess;
            this.Levels = new List<string>() { "Critical", "High", "Mid", "Low" };
        }
        public DelegateCommand AddCommand { get; private set; }

        private string _id;
        private readonly IDataAccess<SourceConfiguration> dataAccess;

        public string Id
        {
            get => this._id;
            set => this.SetProperty(ref this._id, value);
        }
        private SignalLevel signalLevel;
        public SignalLevel SignalLevel
        {
            get => this.signalLevel;
            set => this.SetProperty(ref this.signalLevel, value);
        }

        private IEnumerable<string> levels;
        public IEnumerable<string> Levels
        {
            get => this.levels;
            set => this.SetProperty(ref this.levels, value);
        }
        private string selectedLevel;
        public string SelectedLevel
        {
            get => this.selectedLevel;
            set => this.SetProperty(ref this.selectedLevel, value);
        }
        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        private SignalLevel Convert(string level)
        {
            switch (level)
            {
                case "Critical":
                    return SignalLevel.Critical;
                case "High":
                    return SignalLevel.High;
                case "Mid":
                    return SignalLevel.Mid;
                case "Low":
                    return SignalLevel.Low;
                default:
                    throw new System.Exception($"Could not convert {level} to SignalLevel");
            }
        }
        private void Add()
        {
            this.SignalSources.Add(new SourceConfiguration { Id = Id, SignalLevel = this.Convert(this.SelectedLevel), Name = Name });
            this.dataAccess.Save(this.SignalSources);
        }
    }
}

