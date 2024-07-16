using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Green_Light.Models;

namespace Green_Light.Database_Bits
{
    public class DriveConditionDatabase
    {
        SQLiteAsyncConnection Database;

        public DriveConditionDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            var result = await Database.CreateTableAsync<DriveCondition>();
        }

        public AsyncTableQuery Task<>
    }
}
