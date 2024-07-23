using Green_Light.Models;
using System.Diagnostics;

namespace Green_Light;

public partial class LoginPage : ContentPage
{
	Drive? drvUnfinishedDrive;

    public LoginPage(Drive drive)
	{
		InitializeComponent();
		if (drive is not null) 
		{
            drvUnfinishedDrive = drive;
        }		
        Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
    }


    public void btnLoginClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ConditionsPage(drvUnfinishedDrive));
	}
}