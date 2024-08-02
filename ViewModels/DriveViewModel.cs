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
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

//Viewmodel class containing interactions for the Drive class
//Uses the Drive Conditions viewmodel to retrieve a collection of conditions
//Contains methods for translating between conditions and the boolean
//values contained in the drive class indicating whether a condition
//has been selected and managing the selection of conditions

namespace Green_Light.ViewModels
{
    public class DriveViewModel : ObservableObject
    {
        public Drive _Drive { get; set; }

        static MasterDatabase masterdatabase = new MasterDatabase();
        
        public DriveConditionsViewModel _DriveConditionsViewModel { get; set; }

        private ObservableCollection<DriveCondition> _clnDriveConditions;
        public ObservableCollection<DriveCondition> clnDriveConditions
        {
            get => _clnDriveConditions;
            set => SetProperty(ref _clnDriveConditions, value);
        }

        public ObservableCollection<DriveCondition> clnSelectedDriveConditions;

        public ObservableCollection<Drive> clnDrives { get; set; }

        
        public ICommand SetConditionsCommand { get; set; }

        public DriveViewModel(MasterDatabase masterDatabase)
        {
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();

            _Drive = new Drive();

            SetConditionsCommand = new Command(SetDriveConditionsAsync);

            _DriveConditionsViewModel = new DriveConditionsViewModel(masterDatabase);

            _clnDriveConditions = _DriveConditionsViewModel.clnDriveConditions;

            clnSelectedDriveConditions = new ObservableCollection<DriveCondition>();

            clnDrives = new ObservableCollection<Drive>(masterdatabase.GetDrivesAsync().GetAwaiter().GetResult());

        }
        
        public void SetDriveConditionsAsync()
        {
            Debug.WriteLine(clnSelectedDriveConditions.Count);
            Debug.WriteLine(clnSelectedDriveConditions[0].strName);
            foreach (DriveCondition condition in clnSelectedDriveConditions)
            {
                PropertyInfo property = typeof(Drive).GetProperty(condition.strName);

                if (property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(_Drive, true);
                }
            }
        }

        public void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Selection changed");
            var viewModel = new DriveViewModel(masterdatabase);

            if (viewModel != null)
            {
                viewModel.clnSelectedDriveConditions.Clear();
                foreach (var item in e.CurrentSelection.Cast<DriveCondition>())
                {
                    viewModel.clnSelectedDriveConditions.Add(item);
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
