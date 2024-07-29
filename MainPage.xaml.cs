using Green_Light.Models;
using System.Diagnostics;
using System.Timers;
using Green_Light.Database_Bits;
using System.Windows.Input;


namespace Green_Light
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer tmrDriveTimer;
        DateTime dtmStartTime;
        TimeSpan tspPausedTime;
        DateTime dtmPauseStart;
        MasterDatabase masterDatabase { get; set; }

        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            tspPausedTime = TimeSpan.Zero;
            masterDatabase = new MasterDatabase();
 
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TimeSpan ElapsedTime = (DateTime.Now - dtmStartTime) - tspPausedTime;
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
            Drive drvInProgressDrive = new Drive { tspDriveTime = (DateTime.Now - dtmStartTime) - tspPausedTime, dtmDriveDateTime=DateTime.Now };        
            masterDatabase.SaveDriveAsync(drvInProgressDrive);
            //Navigation.PushAsync(new LoginPage(drvInProgressDrive));
        }

        private void OnPauseButtonClicked(object sender, EventArgs e)
        {
            switch (btnPause.Source.ToString())
            {
                case "File: pause.png":
                    btnPause.Source = "play.png";
                    lblRecordingIndicator.TextColor = Colors.Red;
                    lblRecordingIndicator.Text = "Paused";
                    tmrDriveTimer.Enabled= false;
                    dtmPauseStart = DateTime.Now;
                    break;
                case "File: play.png":
                    btnPause.Source = "pause.png";
                    lblRecordingIndicator.TextColor = Colors.Green;
                    lblRecordingIndicator.Text = "Recording";
                    tspPausedTime = DateTime.Now - dtmPauseStart;
                    tmrDriveTimer.Enabled= true;
                    break;
            }
        }
    }

}
