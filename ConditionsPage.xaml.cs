using Green_Light.Database_Bits;
using Green_Light.Models;
using Green_Light.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Green_Light;


public partial class ConditionsPage : ContentPage
{
	Dictionary<DriveCondition, string> ConditionDriveBindings;
	Drive drvInProgress;
    public ObservableCollection<DriveCondition> clnSelectedConditions = new ObservableCollection<DriveCondition>();
    public ConditionsPage(Drive drive)
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		lblDriveTime.Text = string.Format("{0} hours {1} minutes", (int)drive.tspDriveTime.TotalHours, (int)drive.tspDriveTime.TotalMinutes);
        BindingContext = new DriveViewModel(masterDatabase);
		drvInProgress = drive;

	}

	public void btnSubmitClicked(object sender, EventArgs e)
	{
		var _DriveViewModel = BindingContext as DriveViewModel;
        if (_DriveViewModel != null)
        {
            if (pkrSupervisor.SelectedItem == null)
            {
                Debug.WriteLine("Hello");
                return;
            }
            else
            {
                _DriveViewModel.SetDriveConditionsAsync(clnSelectedConditions);
            }
        }
	}
}