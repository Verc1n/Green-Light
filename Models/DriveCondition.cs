using SQLite;

namespace Green_Light.Models
{
    public class DriveCondition
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string strName { get; set; }
        public string strImageURL { get; set; }
        public string strCategory { get; set; }
        public DateTime dtmDateLastSelected { get; set; }
        public int intTimesSelected { get; set; }
    }
}
