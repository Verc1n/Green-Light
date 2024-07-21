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
    public class DriveConditionsViewModel 
    {
        static MasterDatabase masterdatabase = new MasterDatabase();
        public ObservableCollection<DriveCondition> clnDriveConditions { get; private set; }
        public ObservableCollection<DriveCondition> clnSelectedDriveConditions { get; private set; }

        public DriveConditionsViewModel(MasterDatabase masterDatabase)
        {
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();
            clnDriveConditions = new ObservableCollection<DriveCondition>(masterdatabase.GetConditionsAsync().GetAwaiter().GetResult());
        }
    }
}