using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Green_Light.Models
{
    //This class contains the basic setup information for the database
    //Referenced by the file "MasterDatabase.cs
    //Saves the database to the app data folder on the user's device
    class DatabaseConstants
    {
        public const string strFileName = "MasterDatabase.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, strFileName);
    }
}
