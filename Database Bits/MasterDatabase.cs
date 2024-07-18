using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Green_Light.Models;
using System.Diagnostics;

namespace Green_Light.Database_Bits
{
    public class MasterDatabase
    {
        SQLiteAsyncConnection Database;

        DriveCondition[] lstConditionsSource = {
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

        public MasterDatabase()
        {
        }

        public async Task Init()
        {
            Debug.WriteLine("Init working");
            if (Database is not null)
            {
                Debug.WriteLine("1");
                return;
            }
            Debug.WriteLine("1.5");            
            Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            await Database.CreateTableAsync<DriveCondition>();
            Debug.WriteLine("2");

            int count = await Database.Table<DriveCondition>().CountAsync() ;
            if(count==0)
            {
                Debug.WriteLine("3");
                foreach (DriveCondition condition in lstConditionsSource)
                {
                    await Database.InsertAsync(condition);
                }
                Debug.WriteLine("4");
            }            
        }

        public async Task<List<DriveCondition>> GetConditionsAsync()
        {
            Debug.WriteLine("First func woking");
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