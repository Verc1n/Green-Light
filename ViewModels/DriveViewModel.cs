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
        //Setting up variables and commandsused by other pages such 
        //as the database page and conditions page
        //----------------------------------------
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
        //--------------------------------------------------------------------------


        //This function translates between the 'condition' object and the booleans stored in the
        //drive class indicating whether or not a given drive is selected
        //Takes as an input the selected drive conditions (clnSelectedDriveConditions),
        //which in the conditions page is bound to the collection view selected items property
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

        //This function works with the collection view in the conditions page
        //It aims to ensure that the conditions selected via the user interface are
        //always reflected in clnSelectedDriveConditions
        //It takes clnSelectedDriveConditions as an input and is triggered by the 'selection changed'
        //event of the collection view in the drive conditions view model
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

        //Just some background technical code to handle the property changed event
        //Pretty much unused, just needed to avoid throwing an error
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string strPropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
        #endregion
    }
}
