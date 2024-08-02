using Green_Light.Models;
using System.Diagnostics;

namespace Green_Light;

public partial class LoginPage : ContentPage
{

    public LoginPage(Drive drive)
	{
		InitializeComponent();		
        Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
    }


    public void btnLoginClicked(object sender, EventArgs e)
	{
		
	}
}