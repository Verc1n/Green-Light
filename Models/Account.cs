using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Light.Models
{
    class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string strName { get; set; }
        public int intPIN { get; set; }
        public bool bolIsSupervisor { get; set; }
    }
}
