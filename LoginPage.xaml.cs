using Green_Light.Models;
using Microsoft.UI.Xaml.Controls.Primitives;
using System.Diagnostics;
using Windows.ApplicationModel.Chat;

//This is the codebehind for the login page
//Appears before the rest of the app, and only allows access if the password is correct  

namespace Green_Light;

public partial class LoginPage : ContentPage
{
    public LoginPage()
	{
		InitializeComponent();		
        Routing.RegisterRoute(nameof(ConditionsPage), typeof(ConditionsPage));
    }

	//This event handles the login click
	//If the username and password are correct, it pushes the user to the home screen
	//Otherwise, it displays an appropriate error message
    public void btnLoginClicked(object sender, EventArgs e)
	{
		if (ntyUsernameEntry.Text != "admin")
			DisplayAlert("Failed", "Incorrect Username", "Ok");
		else if (ntyPasswordEntry.Text != "admin")
			DisplayAlert("Failed", "Incorrect Password", "Ok");
		else
			Application.Current.MainPage = new AppShell(); 			
	}
}