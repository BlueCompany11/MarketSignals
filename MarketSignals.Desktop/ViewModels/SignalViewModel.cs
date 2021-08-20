using Prism.Mvvm;

namespace MarketSignals.Desktop.ViewModels
{
    public class SignalViewModel : BindableBase
    {
        public string From { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }

        public SignalViewModel()
        {
            this.From = "Stock Guru";
            this.Date = "1 minute ago";
            this.Text = "PAY ATTENTION! This is the scary truth about Bitcoin";
        }
    }
}
