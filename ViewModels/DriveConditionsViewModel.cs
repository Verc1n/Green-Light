﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using Green_Light.Database_Bits;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//Viewmodel class containing interactions for the Drive Condition class
//creates a collection of drive conditions out of the database table

namespace Green_Light.ViewModels
{
    public class DriveConditionsViewModel : INotifyPropertyChanged
    {
        static MasterDatabase masterdatabase = new MasterDatabase();
        public ObservableCollection<DriveCondition> clnDriveConditions { get; set; }
        public DriveConditionsViewModel(MasterDatabase masterDatabase)
        {
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();
            clnDriveConditions = new ObservableCollection<DriveCondition>(masterdatabase.GetConditionsAsync().GetAwaiter().GetResult());
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