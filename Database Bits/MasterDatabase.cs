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

        readonly DriveCondition[] lstConditionsSource = [
                new DriveCondition {
                    strName = "Parallel_Parking",
                    strImageURL = "parallel_parking.png",
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Vertical_Parking",
                    strImageURL = "bvertical_parking.png",
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Diagonal_Parking",
                    strImageURL = "diagonal_parking.png",
                    strCategory = "Parking",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "No_Rain",
                    strImageURL = "no_rain.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Light_Rain",
                    strImageURL = "light_rain.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Moderate_Rain",
                    strImageURL = "moderate_rain.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Heavy_Rain",
                    strImageURL = "heavy_rain.png",
                    strCategory = "Weather",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Local_Roads",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Rural_Roads",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "City_Roads",
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
                    strName = "No_Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Light_Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Moderate_Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Heavy_Traffic",
                    strImageURL = "placeholder_graphic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                }];

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
            Database.CreateTablesAsync<DriveCondition, Account, Drive, GlobalVariables>().Wait();

            int count = Database.Table<DriveCondition>().CountAsync().GetAwaiter().GetResult();
            if(count==0)
            {
                foreach (DriveCondition condition in lstConditionsSource)
                {
                    Database.InsertAsync(condition).Wait();
                }
            }
        }

        static MasterDatabase _MasterDatabase;
        public async Task<MasterDatabase> GetDatabase()
        {
            if (_MasterDatabase == null)
            {
                _MasterDatabase = new MasterDatabase();
                await _MasterDatabase.Init();
            }
            return _MasterDatabase;
        }

        public async Task<List<DriveCondition>> GetConditionsAsync()
        {
            return Database.Table<DriveCondition>().ToListAsync().GetAwaiter().GetResult();
        }

        public async Task<List<Drive>> GetDrivesAsync()
        {
            return Database.Table<Drive>().ToListAsync().GetAwaiter().GetResult();
        }

        public async Task<int> SaveDriveAsync(Drive drive)
        {
            return Database.UpdateAsync(drive).GetAwaiter().GetResult();
        }

        public async Task<int> SaveConditionAsync(DriveCondition condition)
        {
            return Database.UpdateAsync(condition).GetAwaiter().GetResult();
        }                          
    }
}