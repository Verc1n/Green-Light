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
        
        static async Task InitialiseDatabaseWithDefaults(MasterDatabase db)
        {
            var condition = await db.GetConditionsAsync();

            if (condition.Count == 0)
            {
                DriveCondition[] lstSource = {
                new DriveCondition
                {
                    strName = "Parallel Parking",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Vertical Parking",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Diagonal Parking",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Parking"
                },

                new DriveCondition
                {
                    strName = "No Rain",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Light Rain",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Moderate Rain",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Heavy Rain",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Local Roads",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Rural Roads",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "City Roads",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Highways",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "No Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Light Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Moderate Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Heavy Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                }};

                foreach (DriveCondition defaultcondition in lstSource)
                {
                    await db.SaveConditionAsync(defaultcondition);
                }
            }
        }
    }
}