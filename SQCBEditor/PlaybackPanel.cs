using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.Diagnostics;
using System.IO;
using NAudio.Vorbis;

namespace SQCBEditor
{
    public partial class PlaybackPanel : UserControl
    {
        private WaveOut wavePlayer;
        private VorbisWaveReader vorbisWaveReader;
        private Stream stream;
        public PlaybackPanel()
        {
            InitializeComponent();
            EnableButtons(false);
            Disposed += SimplePlaybackPanel_Disposed;
            timer1.Interval = 250;
            timer1.Tick += OnTimerTick;
        }

        private static string FormatTimeSpan(TimeSpan ts)
        {
            return string.Format("{0:D2}:{1:D2}", (int)ts.TotalMinutes, ts.Seconds);
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            if (vorbisWaveReader != null)
            {
                labelNowTime.Text = FormatTimeSpan(vorbisWaveReader.CurrentTime);
                labelTotalTime.Text = FormatTimeSpan(vorbisWaveReader.TotalTime);
            }
        }

        void SimplePlaybackPanel_Disposed(object sender, EventArgs e)
        {
            CleanUp();
        }

        public void BeginPlayback(Stream dataStream)
        {
            Debug.Assert(wavePlayer == null);
            stream = dataStream;
            wavePlayer = new WaveOut();
            vorbisWaveReader = new VorbisWaveReader(dataStream);
            wavePlayer.Volume = volumeSlider1.Volume;
            wavePlayer.Init(vorbisWaveReader);
            wavePlayer.PlaybackStopped += OnPlaybackStopped;
            wavePlayer.Play();
            EnableButtons(true);
            timer1.Enabled = true; // timer for updating current time label
        }

        private void EnableButtons(bool playing)
        {
            buttonPlay.Enabled = !playing;
            buttonStop.Enabled = playing;
        }

        void OnPlaybackStopped(object sender, EventArgs e)
        {
            // we want to be always on the GUI thread and be able to change GUI components
            Debug.Assert(!InvokeRequired, "PlaybackStopped on wrong thread");
            // we want it to be safe to clean up input stream and playback device in the handler for PlaybackStopped
            CleanUp();
            EnableButtons(false);
            timer1.Enabled = false;
            labelNowTime.Text = "00:00";
        }

        public void CleanUp()
        {
            if (vorbisWaveReader != null)
            {
                vorbisWaveReader.Dispose();
                vorbisWaveReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
            if (stream != null)
            {
                stream.Dispose();
                stream = null;
            }
        }

        private void OnButtonStopClick(object sender, EventArgs e)
        {
            wavePlayer.Stop();
            // don't set button states now, we'll wait for our PlaybackStopped to come
        }

        private void OnVolumeSliderChanged(object sender, EventArgs e)
        {
            if (vorbisWaveReader != null)
            {
                wavePlayer.Volume = volumeSlider1.Volume;
            }
        }

    }
}
