using Green_Light.Models;
using System.Diagnostics;

namespace Green_Light;

public partial class LoginPage : ContentPage
{
	Drive Drive { get; set; }
    public LoginPage(Drive? drive)
	{
		InitializeComponent();		
        Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
		if(drive != null)
			Drive = drive;
		else
		{
			Drive = new Drive();
		}
    }


    public void btnLoginClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new ConditionsPage(Drive));
	}
}