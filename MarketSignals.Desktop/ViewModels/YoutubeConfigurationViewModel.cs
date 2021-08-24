using Prism.Commands;
using Prism.Mvvm;
using SignalSources.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MarketSignals.Desktop.ViewModels
{
    public static class SignalLevelConverter
    {
        public static string Convert(SignalLevel signalLevel)
        {
            switch (signalLevel)
            {
                case SignalLevel.Low:
                    return "Low";
                case SignalLevel.Mid:
                    return "Mid";
                case SignalLevel.High:
                    return "High";
                case SignalLevel.Critical:
                    return "Critical";
                default:
                    throw new System.Exception($"Could not convert {signalLevel} to Level");
            }
        }
        public static SignalLevel Convert(string level)
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
    }
    
    public class ExtendedSourceConfiguration
    {
        private SourceConfiguration sourceConfiguration;
        public SourceConfiguration SourceConfiguration
        {
            get
            {
                if(this.sourceConfiguration != null)
                {
                    this.sourceConfiguration.SignalLevel = SignalLevelConverter.Convert(this.Level);
                    this.sourceConfiguration.Active = this.IsActive == "Active" ? true : false;
                }
                return this.sourceConfiguration;
            }
            set => this.sourceConfiguration = value;
        }
        public bool Selected { get; set; }
        public string Level { get; set; }
        public string IsActive { get; set; }
        public ExtendedSourceConfiguration(SourceConfiguration sourceConfiguration)
        {
            this.SourceConfiguration = sourceConfiguration;
            this.IsActive = sourceConfiguration.Active ? "Active" : "Muted";
            this.Level = SignalLevelConverter.Convert(sourceConfiguration.SignalLevel);
        }
    }
    public class YoutubeConfigurationViewModel : BindableBase
    {
        private ObservableCollection<ExtendedSourceConfiguration> signalSources;
        public ObservableCollection<ExtendedSourceConfiguration> SignalSources
        {
            get => this.signalSources;
            set => this.SetProperty(ref this.signalSources, value);
        }

        private bool selectedAll;
        public bool SelectedAll
        {
            get => this.selectedAll;
            set => this.SetProperty(ref this.selectedAll, value);
        }
        
        public YoutubeConfigurationViewModel(ISignalSourceConfiguration signalSourceConfiguration, IDataAccess<SourceConfiguration> dataAccess)
        {
            var sources = new List<SourceConfiguration>(signalSourceConfiguration.GetSourceConfigurations());
            this.SignalSources = new(sources.Select(sourceConf => new ExtendedSourceConfiguration(sourceConf)).ToList());
            this.AddCommand = new DelegateCommand(this.Add);
            this.SaveCommand = new DelegateCommand(this.Save);
            this.SelectAllCommand = new DelegateCommand(this.SelectAll);
            this.dataAccess = dataAccess;
            this.Levels = new List<string>() { "Critical", "High", "Mid", "Low" };
            this.States = new List<string> { "Active", "Muted" };
            
        }
        public void SelectAll()
        {
            foreach (var item in this.SignalSources)
            {
                item.Selected = this.selectedAll;
            }
            this.SignalSources = new(this.SignalSources);
        }
        public DelegateCommand SelectAllCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        private string _id;
        private readonly IDataAccess<SourceConfiguration> dataAccess;

        private ISignal signal;
        public ISignal Signal
        {
            get => this.signal;
            set => this.SetProperty(ref this.signal, value);
        }
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
        
        public IEnumerable<string> Levels { get; set; }
        public List<string> States { get; }

        private string selectedLevel;
        public string SelectedLevel
        {
            get => this.selectedLevel;
            set => this.SetProperty(ref this.selectedLevel, value);
        }
        private bool criticalLevelSelected;
        public bool CriticalLevelSelected
        {
            get => this.criticalLevelSelected;
            set => this.SetProperty(ref this.criticalLevelSelected, value);
        }
        private bool highLevelSelected;
        public bool HighLevelSelected
        {
            get => this.highLevelSelected;
            set => this.SetProperty(ref this.highLevelSelected, value);
        }
        private bool midLevelSelected;
        public bool MidLevelSelected
        {
            get => this.midLevelSelected;
            set => this.SetProperty(ref this.midLevelSelected, value);
        }
        private bool lowLevelSelected;
        public bool LowLevelSelected
        {
            get => this.lowLevelSelected;
            set => this.SetProperty(ref this.lowLevelSelected, value);
        }
        private string name;
        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }


        private void Add()
        {
            this.SignalSources.Add(new ExtendedSourceConfiguration(new SourceConfiguration { Id = Id, SignalLevel = SignalLevelConverter.Convert(this.SelectedLevel), Name = Name, Active = true }));
            this.dataAccess.Save(this.SignalSources.Select(x=>x.SourceConfiguration));
        }
        private void Save()
        {
            this.dataAccess.Save(this.SignalSources.Select(x=>x.SourceConfiguration));
        }
    }
}
