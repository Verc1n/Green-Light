using CommunityToolkit.Mvvm;
using System.ComponentModel;

namespace Green_Light.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [RelayCommand]
        public void UserEndTheCode(string code)
        {
            //Do something
        }
    }
}
