using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using Green_Light.Database_Bits;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;

namespace Green_Light.ViewModels
{
    public class DriveConditionsDatabaseAccessViewModel
    {
        MasterDatabase Database;
        public ObservableCollection<DriveCondition> clnDriveConditions { get; private set; }
        public ObservableCollection<DriveCondition> clnSelectedDriveConditions { get; private set; }

        public DriveConditionsDatabaseAccessViewModel(MasterDatabase ConditionDatabase)
        {
            clnDriveConditions = new ObservableCollection<DriveCondition>(ConditionDatabase.GetConditionsAsync().Result);
        }        
    }
}
