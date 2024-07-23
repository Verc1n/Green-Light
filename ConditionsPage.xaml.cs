using Green_Light.Database_Bits;
using Green_Light.Models;
using Green_Light.ViewModels;

namespace Green_Light;


public partial class ConditionsPage : ContentPage
{
    public ConditionsPage(Drive drive)
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		lblDriveTime.Text = string.Format("{0} hours {1} minutes", (int)drive.tspDriveTime.TotalHours, (int)drive.tspDriveTime.TotalMinutes);
        BindingContext = new DriveConditionsViewModel(masterDatabase);
	}
}