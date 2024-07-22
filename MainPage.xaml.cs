using System.Diagnostics;
using System.Timers;

namespace Green_Light
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer tmrDriveTimer;
        DateTime dtmStartTime;
        TimeSpan tspPausedTime;
        public MainPage()
        {
            InitializeComponent();
            tspPausedTime = TimeSpan.Zero;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TimeSpan ElapsedTime = (DateTime.Now - dtmStartTime) + tspPausedTime;
            MainThread.BeginInvokeOnMainThread(() =>{
                lblTimer.Text=$"Elapsed Time: {ElapsedTime:h\\:mm\\:ss}";
            });

        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {            
            btnStart.IsVisible = false;
            btnPause.IsVisible = true;
            btnStop.IsVisible = true;
            lblDrive.IsVisible= true;
            lblRecordingIndicator.IsVisible= true;
            lblTimer.IsVisible= true;

            tmrDriveTimer = new System.Timers.Timer(1000);
            tmrDriveTimer.Elapsed += OnTimedEvent;
            dtmStartTime = DateTime.Now;
            tmrDriveTimer.Start();
        }

        private void OnStopButtonClicked(object sender, EventArgs e)
        {
            tmrDriveTimer.Enabled=false;
            tmrDriveTimer.Dispose();
        }

        private void OnPauseButtonClicked(object sender, EventArgs e)
        {
            switch (btnPause.Source.ToString())
            {
                case "File: pause.png":
                    btnPause.Source = "play.png";
                    lblRecordingIndicator.TextColor = Colors.Red;
                    lblRecordingIndicator.Text = "Paused";
                    break;
                case "File: play.png":
                    btnPause.Source = "pause.png";
                    lblRecordingIndicator.TextColor = Colors.Green;
                    lblRecordingIndicator.Text = "Recording";
                    break;

            }
        }
    }

}
