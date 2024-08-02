using SQLite;

//Class containing information about drives
//Contains the name, the associated icon, the category it belongs to,
//The date it was last selected (initialised to the day the database was created
//and the number of times the drive was selected

namespace Green_Light.Models
{
    public class DriveCondition
    {
        [PrimaryKey]
        public string strName { get; set; }
        public string strImageURL { get; set; }
        public string strCategory { get; set; }
        public DateTime dtmDateLastSelected { get; set; }
        public int intTimesSelected { get; set; }
    }
}
