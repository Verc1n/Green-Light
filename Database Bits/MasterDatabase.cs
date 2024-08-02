using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Green_Light.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

//This class handles the connections to the database.
//Initialises the database, sets up defaults and provides
//functions for saving/retrieving data from the database
//The database contains tables for: conditions, drives, accounts
//and default variables

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
                    strImageURL = "local_roads.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Rural_Roads",
                    strImageURL = "rural_roads.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "City_Roads",
                    strImageURL = "city_roads.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Highways",
                    strImageURL = "highways.png",
                    strCategory = "Roads",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "No_Traffic",
                    strImageURL = "no_traffic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Light_Traffic",
                    strImageURL = "light_traffic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Moderate_Traffic",
                    strImageURL = "moderate_traffic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                },

                new DriveCondition
                {
                    strName = "Heavy_Traffic",
                    strImageURL = "heavy_traffic.png",
                    strCategory = "Traffic",
                    dtmDateLastSelected = DateTime.Now,
                    intTimesSelected = 0
                }];

        public MasterDatabase()
        {
        }


        //Initialises the database and adds default values
        //Called by everything that accesses the database
        //Ignored if the database is already initialised
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
        //Retrieves the database
        //Calls the Init function if the database is null
        public async Task<MasterDatabase> GetDatabase()
        {
            if (_MasterDatabase == null)
            {
                _MasterDatabase = new MasterDatabase();
                await _MasterDatabase.Init();
            }
            return _MasterDatabase;
        }

        //Retrieves the conditions table and casts it to a list
        public async Task<List<DriveCondition>> GetConditionsAsync()
        {
            return Database.Table<DriveCondition>().ToListAsync().GetAwaiter().GetResult();
        }

        //Retrieves the drives table and casts it to a list
        public async Task<List<Drive>> GetDrivesAsync()
        {
            return Database.Table<Drive>().ToListAsync().GetAwaiter().GetResult();
        }

        //Waits for Init, then saves a drive
        //If the drive is already in the database, updates the drive
        //Otherwise adds a new drive
        //Input: Drive
        public async Task<int> SaveDriveAsync(Drive drive)
        {
            await Init();
            if (drive.Id != 0)
            {
                return Database.UpdateAsync(drive).GetAwaiter().GetResult();
            }
            else
            {
                return Database.InsertAsync(drive).GetAwaiter().GetResult();
            }
            
        }

        //Updates the condition data
        //Input: Condition
        //Unlike the drive function, it is not possible to add a new condition so no extra 
        public async Task<int> SaveConditionAsync(DriveCondition condition)
        {
            return Database.UpdateAsync(condition).GetAwaiter().GetResult();
        }                          
    }
}