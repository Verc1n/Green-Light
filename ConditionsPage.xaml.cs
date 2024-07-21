using Green_Light.Database_Bits;
using Green_Light.ViewModels;
namespace Green_Light;

public partial class ConditionsPage : ContentPage
{
	public ConditionsPage()
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		BindingContext = new DriveConditionsViewModel(masterDatabase);
	}
}