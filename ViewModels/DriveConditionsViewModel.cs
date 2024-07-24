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
using System.Reflection;

namespace Green_Light.ViewModels
{
    public class DriveConditionsViewModel 
    {
        public Drive Drive { get; set; }
        static MasterDatabase masterdatabase = new MasterDatabase();
        public ObservableCollection<DriveCondition> clnDriveConditions { get; private set; }
        public ObservableCollection<DriveCondition> clnSelectedDriveConditions { get; private set; }
        public DriveConditionsViewModel(MasterDatabase masterDatabase)
        {
            Drive = new Drive();
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();
            clnDriveConditions = new ObservableCollection<DriveCondition>(masterdatabase.GetConditionsAsync().GetAwaiter().GetResult());
        }
       public void SetDriveConditionsAsync(ObservableCollection<DriveCondition> selectedconditions)
        {
            foreach (DriveCondition condition in selectedconditions)
            {
                PropertyInfo property = typeof(Drive).GetProperty(condition.strName);

                if (property != null && property.PropertyType == typeof(bool))
                {
                    property.SetValue(Drive, true);
                }
            }
        }
    }
}