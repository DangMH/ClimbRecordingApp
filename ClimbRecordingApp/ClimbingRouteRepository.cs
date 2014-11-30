using ClimbRecordingApp.BusinessLayer;
using ClimbRecordingApp.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;

namespace ClimbRecordingApp.DataAccessLayer
{
    /// <summary>
    /// Class abstraction of the database connections.  Provides an interface to retrieve Climbing Routes, Climbing Tags, and Climbing Tag Maps.  Could potentially store each table in different database files.  Applies The Singleton pattern and can only have one instance running at any time.
    /// </summary>
    /// <remarks>Based on Open Source: https://github.com/xamarin/mobile-samples/tree/master/Tasky</remarks>
    public class ClimbingRouteRepository
    {
        /// <summary>
        /// File extension of the database file
        /// </summary>
        private const string DB_FILE_EXTENSION = ".db3";
        /// <summary>
        /// Name of the database file
        /// </summary>
        private const string CLIMBING_ROUTE_DB_NAME = "ClimbingRouteDB";

        /// <summary>
        /// Climbing Route Database object
        /// </summary>
        private ClimbingRouteDatabase climbingRouteDB = null;

        /// <summary>
        /// Path of the database file
        /// </summary>
        protected static string CLIMBING_ROUTE_DB_LOCATION;
        /// <summary>
        /// Singleton instance
        /// </summary>
        protected static ClimbingRouteRepository INSTANCE;

        /// <summary>
        /// Constructor for the first initialization of the Singleton
        /// </summary>
        static ClimbingRouteRepository()
        {
            INSTANCE = new ClimbingRouteRepository();
        }

        /// <summary>
        /// Constructor to initialize database variables
        /// </summary>
        protected ClimbingRouteRepository()
        {
            // set the db locations
            CLIMBING_ROUTE_DB_LOCATION = GetDatabaseFilePath(CLIMBING_ROUTE_DB_NAME);

            climbingRouteDB = new ClimbingRouteDatabase(CLIMBING_ROUTE_DB_LOCATION);
        }

        /// <summary>
        /// Method to retrieve the database filepath from the platform currently running
        /// </summary>
        /// <param name="sqliteFilename">Name of the database file</param>
        public static string GetDatabaseFilePath(string sqliteFilename)
        {
#if SILVERLIGHT
			// Windows Phone expects a local path, not absolute
	        var path = sqliteFilename;
#else
#if __ANDROID__
            // Just use whatever directory SpecialFolder.Personal returns
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#else
			// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
			// (they don't want non-user-generated data in Documents)
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
#endif
            var path = Path.Combine(libraryPath, sqliteFilename);
#endif
            return path;
        }

        /// <summary>
        /// Method to get a Climbing Route from database
        /// </summary>
        /// <param name="id">ID of the Climbing Route entry</param>
        public static ClimbingRoute GetClimbingRoute(int id)
        {
            return INSTANCE.climbingRouteDB.GetItem<ClimbingRoute>(id);
        }

        /// <summary>
        /// Method to get all Climbing Route's from database
        /// </summary>
        public static IEnumerable<ClimbingRoute> GetClimbingRoutes()
        {
            return INSTANCE.climbingRouteDB.GetItems<ClimbingRoute>();
        }

        /// <summary>
        /// Method to save a Climbing Route to database
        /// </summary>
        /// <param name="climbingRoute">Climbing Route to save</param>
        public static int SaveClimbingRoute(ClimbingRoute climbingRoute)
        {
            return INSTANCE.climbingRouteDB.SaveItem<ClimbingRoute>(climbingRoute);
        }

        /// <summary>
        /// Method to remove a Climbing Route from database
        /// </summary>
        /// <param name="id">ID of the Climbing Route entry</param>
        public static int DeleteClimbingRoute(int id)
        {
            return INSTANCE.climbingRouteDB.Delete<ClimbingRoute>(id);
        }

        /// <summary>
        /// Method to get a Climbing Tag from database
        /// </summary>
        /// <param name="id">ID of the Climbing Tag entry</param>
        public static ClimbingTag GetClimbingTag(int id)
        {
            return INSTANCE.climbingRouteDB.GetItem<ClimbingTag>(id);
        }

        /// <summary>
        /// Method to get all Climbing Tag's from database
        /// </summary>
        public static IEnumerable<ClimbingTag> GetClimbingTags()
        {
            return INSTANCE.climbingRouteDB.GetItems<ClimbingTag>();
        }

        /// <summary>
        /// Method to save a Climbing Tag to database
        /// </summary>
        /// <param name="ClimbingTag">Climbing Tag to save</param>
        public static int SaveClimbingTag(ClimbingTag ClimbingTag)
        {
            return INSTANCE.climbingRouteDB.SaveItem<ClimbingTag>(ClimbingTag);
        }

        /// <summary>
        /// Method to remove a Climbing Tag from database
        /// </summary>
        /// <param name="id">ID of the Climbing Tag entry</param>
        public static int DeleteClimbingTag(int id)
        {
            return INSTANCE.climbingRouteDB.Delete<ClimbingTag>(id);
        }

        /// <summary>
        /// Method to get a Climbing Tag Map from database
        /// </summary>
        /// <param name="id">ID of the Climbing Tag Map entry</param>
        public static ClimbingTagMap GetClimbingTagMap(int id)
        {
            return INSTANCE.climbingRouteDB.GetItem<ClimbingTagMap>(id);
        }

        /// <summary>
        /// Method to get all Climbing Tag Map's from database
        /// </summary>
        public static IEnumerable<ClimbingTagMap> GetClimbingTagMaps()
        {
            return INSTANCE.climbingRouteDB.GetItems<ClimbingTagMap>();
        }

        /// <summary>
        /// Method to save a Climbing Tag Map to database
        /// </summary>
        /// <param name="ClimbingTagMap">Climbing Tag Map to save</param>
        public static int SaveClimbingTagMap(ClimbingTagMap ClimbingTagMap)
        {
            return INSTANCE.climbingRouteDB.SaveItem<ClimbingTagMap>(ClimbingTagMap);
        }

        /// <summary>
        /// Method to remove a Climbing Tag Map from database
        /// </summary>
        /// <param name="id">ID of the Climbing Tag Map entry</param>
        public static int DeleteClimbingTagMap(int id)
        {
            return INSTANCE.climbingRouteDB.Delete<ClimbingTagMap>(id);
        }
    }
}
