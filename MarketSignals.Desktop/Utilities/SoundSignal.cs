using MarketSignals.Desktop.Utilities.Interfaces;
using System;
using System.Windows.Media;

namespace MarketSignals.Desktop.Utilities
{
    public class SoundSignal : ISoundSignal
    {
        private MediaPlayer m_mediaPlayer;
        public SoundSignal()
        {
            this.m_mediaPlayer = new();
        }
        public void Play()
        {
            var path = new Uri("file_example_MP3_700KB.mp3", UriKind.Relative);
            this.m_mediaPlayer.Open(path);
            this.m_mediaPlayer.Play();
        }
    }
}
