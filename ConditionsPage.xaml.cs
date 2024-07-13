using Green_Light.ViewModels;
namespace Green_Light;

public partial class ConditionsPage : ContentPage
{
	public ConditionsPage()
	{
		InitializeComponent();
		BindingContext = new DriveConditionsViewModel();
	}
}