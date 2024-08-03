using Green_Light.Database_Bits;
using Green_Light.ViewModels;
namespace Green_Light;

//Codebehind for the database page
//Takes the database as an input and sets up binding
//Used to build a collection view of all drives

public partial class DatabasePage : ContentPage
{
	public DatabasePage()
	{
		MasterDatabase masterDatabase = new MasterDatabase();
		InitializeComponent();
		BindingContext = new DriveViewModel(masterDatabase);
	}
}