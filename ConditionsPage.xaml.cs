using Green_Light.Database_Bits;
using Green_Light.ViewModels;
namespace Green_Light;

public partial class ConditionsPage : ContentPage
{
	MasterDatabase database;
	public ConditionsPage()
	{
		InitializeComponent();
		//BindingContext = new DriveConditionsViewModel();
		BindingContext = new DriveConditionsDatabaseAccessViewModel();
	}
}