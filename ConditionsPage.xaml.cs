using Green_Light.Database_Bits;
using Green_Light.Models;
using Green_Light.ViewModels;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Green_Light;


public partial class ConditionsPage : ContentPage
{
	Dictionary<DriveCondition, string> ConditionDriveBindings;
	Drive drvInProgress;
    public ConditionsPage(Drive drive)
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		lblDriveTime.Text = string.Format("{0} hours {1} minutes", (int)drive.tspDriveTime.TotalHours, (int)drive.tspDriveTime.TotalMinutes);
        BindingContext = new DriveConditionsViewModel(masterDatabase);
		drvInProgress = drive;
	}

	public void btnSubmitClicked(object sender, EventArgs e)
	{
		if (pkrSupervisor.SelectedItem==null)
		{
			Debug.WriteLine("Hello");
			return;
		}
		else
		{
			//drvInProgress.
		}
	}
}