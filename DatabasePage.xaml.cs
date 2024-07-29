using Green_Light.Database_Bits;
using Green_Light.ViewModels;
namespace Green_Light;

public partial class DatabasePage : ContentPage
{
	public DatabasePage()
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		BindingContext = new DriveViewModel(masterDatabase);
	}
}