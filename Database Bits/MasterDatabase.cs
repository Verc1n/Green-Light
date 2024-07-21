using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Green_Light.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

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
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
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
            if (Database is not null)
            {
                return;
            }
            Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
            Database.CreateTableAsync<DriveCondition>().Wait();
              


            int count = Database.Table<DriveCondition>().CountAsync().GetAwaiter().GetResult();
            if(count==0)
            {
                foreach (DriveCondition condition in lstConditionsSource)
                {
                    Debug.WriteLine(condition.strName);
                    Database.InsertAsync(condition).Wait();
                }
            }
        }

        public async Task<List<DriveCondition>> GetConditionsAsync()
        {
            return Database.Table<DriveCondition>().ToListAsync().GetAwaiter().GetResult();
        }

        public async Task<int> SaveConditionAsync(DriveCondition condition)
        {
            return Database.UpdateAsync(condition).GetAwaiter().GetResult();
        }                          
    }
}