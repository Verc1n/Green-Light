using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;

namespace Green_Light.Models
{
    class Drive
    {
        public DriveCondition[] cdnDriveConditions { get; set; }
        public DateTime dtmDriveDateTime { get; set; }
        public TimeSpan tspDriveTime { get; set; }
        public Account actSupervisor { get; set; }
    }
}
