using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using Green_Light.Database_Bits;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Green_Light.ViewModels
{
    public class DriveConditionsDatabaseAccessViewModel
    {
        static MasterDatabase _MasterDatabase;
        
        async Task<MasterDatabase> GetDatabase()
        {
            if (_MasterDatabase == null)
            {
                _MasterDatabase = new MasterDatabase();
                await _MasterDatabase.Init();
            }
            return _MasterDatabase;
        }
        public ObservableCollection<DriveCondition> clnDriveConditions { get; private set; }
        public ObservableCollection<DriveCondition> clnSelectedDriveConditions { get; private set; }

        public DriveConditionsDatabaseAccessViewModel()
        {
            MasterDatabase masterdatabase = GetDatabase().Result;
            Debug.WriteLine("Accessing the viewmodel");
            clnDriveConditions = new ObservableCollection<DriveCondition>(masterdatabase.GetConditionsAsync().Result);
        }        
    }
}
