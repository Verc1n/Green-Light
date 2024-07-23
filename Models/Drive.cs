using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Green_Light.Models;
using SQLite;

namespace Green_Light.Models
{
    public class Drive
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime dtmDriveDateTime { get; set; }
        public TimeSpan tspDriveTime { get; set; }
        public string actSupervisorName { get; set; }
        public bool isValidated { get; set; }
        
        //Storing attached drive conditions in a database-friendly way
        public bool Parallel_Parking { get; set; }
        public bool Vertical_Parking { get; set; }
        public bool Diagonal_Parking { get; set; }
        public bool No_Rain { get; set; }
        public bool Light_Rain { get; set; }
        public bool Moderate_Rain { get; set; }
        public bool Heavy_Rain { get; set; }
        public bool Local_Roads { get; set; }
        public bool Rural_Roads { get; set; }
        public bool City_Roads { get; set; }
        public bool Highways { get; set; }
        public bool No_Traffic { get; set; }
        public bool Light_Traffic { get; set; }
        public bool Moderate_Traffic { get; set; }
        public bool Heavy_Traffic { get; set; }

    }
}
