using Green_Light.ViewModels;
namespace Green_Light;

public partial class DatabasePage : ContentPage
{
	public DatabasePage()
	{
		InitializeComponent();
		BindingContext = new DriveViewModel();
	}
}