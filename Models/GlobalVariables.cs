using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Light.Models
{
    internal class GlobalVariables
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public TimeSpan tspTotalDayTime { get; set; }
        public TimeSpan tspTotalNightTime { get; set; }
        public int intNumTotalDrives { get; set; }
    }
}
