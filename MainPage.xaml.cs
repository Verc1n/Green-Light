﻿using Green_Light.Models;
using System.Diagnostics;
using System.Timers;
using Green_Light.Database_Bits;
using System.Windows.Input;

//Codebehind for the main page
//Contains functions for timing a drive,
//and saving it to the database

namespace Green_Light
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer tmrDriveTimer;
        DateTime dtmStartTime;
        TimeSpan tspPausedTime = TimeSpan.Zero;
        DateTime dtmPauseStart;
        MasterDatabase masterDatabase { get; set; }
        GlobalVariables globalVariables { get; set; }

        public MainPage()
        {
            InitializeComponent();
            tspPausedTime = TimeSpan.Zero;
            masterDatabase = new MasterDatabase();
            globalVariables = masterDatabase.GetGlobalVariablesAsync().GetAwaiter().GetResult();
            lblDayHours.Text=string.Format("{0} Hours", globalVariables.tspTotalDayTime.Hours);
            lblNightHours.Text=string.Format("{0} Hours", globalVariables.tspTotalNightTime.Hours);
        }

        //This function is called by the timer object every second
        //Calculates the elapsed time (subtracts paused time) and updates the label
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TimeSpan ElapsedTime = (DateTime.Now - dtmStartTime) - tspPausedTime;
            MainThread.BeginInvokeOnMainThread(() =>{
                lblTimer.Text=$"Elapsed Time: {ElapsedTime:h\\:mm\\:ss}";
            });

        }

        //Changes the page so that the recording indicator, elapsed time and control buttons are now visible
        //Initiates the timer and hides itself
        //Controlled by the big green play button on main page
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

        //Basically opposite of start button - returns the Main page to its initial state
        //Stops the timer
        //Saves the drive to the database
        //Pushes the user to the conditions page
        private void OnStopButtonClicked(object sender, EventArgs e)
        {
            tmrDriveTimer.Enabled=false;
            tmrDriveTimer.Dispose();
            btnStart.IsVisible = true;
            btnPause.IsVisible = false;
            btnStop.IsVisible = false;
            lblDrive.IsVisible = false;
            lblRecordingIndicator.IsVisible = false;
            lblTimer.IsVisible = false;
            lblTimer.Text = "0:00:00";
            TimeSpan tspElapsedTime = (DateTime.Now - dtmStartTime) - tspPausedTime;
            Drive drvInProgressDrive = new Drive { tspDriveTime = tspElapsedTime, dtmDriveDateTime=DateTime.Now };
            if (drvInProgressDrive.dtmDriveDateTime.Hour >= 8 && drvInProgressDrive.dtmDriveDateTime.Hour <= 20)
            {
                drvInProgressDrive.strImageUrl = "sun.png";
                globalVariables.tspTotalDayTime += tspElapsedTime;
            }
            else
            {
                drvInProgressDrive.strImageUrl = "moon.png";
                globalVariables.tspTotalNightTime+= tspElapsedTime;
            }
            globalVariables.intNumTotalDrives++;
            masterDatabase.UpdateGlobalVariablesAsync(globalVariables);
            masterDatabase.SaveDriveAsync(drvInProgressDrive);
            Navigation.PushAsync(new ConditionsPage(drvInProgressDrive));
        }

        //This functionality is controlled by a switch case
        //If the drive is currently recording:
        //  The icon changes to a resume button, the timer is paused
        //  and a timestamp is taken to keep track of how long it is paused for
        //If the drive is currently paused
        //  The icon changes to a pause button, the timer is restarted
        //  and a timespan is updated with how long the drive has been paused for (used to calculate elapsed time)
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
                    tspPausedTime += DateTime.Now - dtmPauseStart;
                    tmrDriveTimer.Enabled= true;
                    break;
            }
        }
    }

}
