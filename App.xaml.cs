
using Green_Light.Database_Bits;

//modified codebehind for the app launching
//Rather than the main page, the first page opened is the login page
namespace Green_Light
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
