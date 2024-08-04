using Green_Light.Database_Bits;
using Green_Light.Models;
using Green_Light.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Windows.Input;

//Codebehind for the conditions page
//Contains logic for the submit button and some basic
//functionality to load the user's drive

namespace Green_Light;

public partial class ConditionsPage : ContentPage
{
	Drive drvInProgress;

    public ConditionsPage(Drive? drive)
	{        
        InitializeComponent();
        MasterDatabase masterDatabase = new MasterDatabase();
        lblDriveTime.Text = string.Format("{0} hours {1} minutes", (int)drive.tspDriveTime.TotalHours, (int)drive.tspDriveTime.TotalMinutes);
        BindingContext = new DriveViewModel(masterDatabase);
		drvInProgress = drive;
	}

    //When the submit button is clicked, adds the selected conditions to the drive in progress
    //Takes as an input the selected conditions in the collection view
    //Calls the SetDriveConditions function from the Drive view model
    //If there is no supervisor, returns.
	public void btnSubmitClicked(object sender, EventArgs e)
	{
        var _DriveViewModel = BindingContext as DriveViewModel;
        if (_DriveViewModel != null)
        {          
            if (pkrSupervisor.SelectedItem == null)
            {
                Debug.WriteLine("supervisor is null");
                return;
            }
            else
            {
                Debug.WriteLine(drvInProgress.No_Rain);
                _DriveViewModel.SetDriveConditionsAsync();
                Debug.WriteLine(drvInProgress.No_Rain);
            }
        }
        else
        {
            Debug.WriteLine("null drivemodel");
        }
	}


}