using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Green_Light.Models;

namespace Green_Light.Database_Bits
{
    public class MasterDatabase
    {
        SQLiteAsyncConnection Database;

        public MasterDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            var result = await Database.CreateTableAsync<DriveCondition>();
        }

        public async Task<List<DriveCondition>> GetConditionsAsync()
        {
            await Init();
            return await Database.Table<DriveCondition>().ToListAsync();
        }

        public async Task<int> SaveConditionAsync(DriveCondition condition)
        {
            await Init();
            return await Database.UpdateAsync(condition);
        }       
    }
}
