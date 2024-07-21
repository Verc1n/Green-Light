using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using Green_Light.ViewModels;
using Green_Light.Database_Bits;
using System.Collections.ObjectModel;

namespace Green_Light.ViewModels
{
    class DriveViewModel
    {
        static MasterDatabase masterdatabase = new MasterDatabase();
        public ObservableCollection<Drive> clnDrives { get; set; }

        public DriveViewModel(MasterDatabase masterDatabase)
        {
            masterdatabase = masterDatabase.GetDatabase().GetAwaiter().GetResult();
            clnDrives = new ObservableCollection<Drive>(masterdatabase.GetDrivesAsync().GetAwaiter.GetResult());
        }
    }
}
