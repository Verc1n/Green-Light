using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using Green_Light.ViewModels;
using Green_Light.Database_Bits;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Green_Light.ViewModels
{
    class DriveViewModel : INotifyPropertyChanged
    {
        public Drive _Drive { get; set; }
        static MasterDatabase masterdatabase = new MasterDatabase();
        public ObservableCollection<Drive> clnDrives { get; set; }
        public ObservableCollection<DriveCondition> clnSelectedDriveConditions { get; private set; }
        public ICommand SetConditionsCommand { get; set; }

        public DriveViewModel(MasterDatabase masterDatabase)
        {
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();
            _Drive = new Drive();
            //clnDrives = new ObservableCollection<Drive>(masterdatabase.GetDrivesAsync().GetAwaiter.GetResult());
            SetConditionsCommand = new Command<ObservableCollection<DriveCondition>>(SetDriveConditionsAsync);
        }
        
        public void SetDriveConditionsAsync(ObservableCollection<DriveCondition> selectedconditions)
        {
            foreach (DriveCondition condition in selectedconditions)
            {
                PropertyInfo property = typeof(Drive).GetProperty(condition.strName);

                if (property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(_Drive, true);
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string strPropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
        #endregion
    }
}
