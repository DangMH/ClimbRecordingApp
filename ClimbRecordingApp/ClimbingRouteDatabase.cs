using ClimbRecordingApp.BusinessLayer;
using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;
using System.Collections.Generic;
using System.Linq;

namespace ClimbRecordingApp.DataLayer
{
    /// <summary>
    /// Class defining the interface required to query an SQLiteConnection.  Simply requires the subclass to implement the parameterized constructor (string path) to CreateTable with the desired class implementing IBusinessEntity.
    /// </summary>
    /// <remarks>Based on Open Source: https://github.com/xamarin/mobile-samples/tree/master/Tasky</remarks>
    public class ClimbingRouteDatabase : SQLiteConnection
    {
        /// <summary>
        /// Lock object for concurrent thread access
        /// </summary>
        private static object locker = new object();

        /// <summary>
        /// Connects/Creates a database based on ClimbingRoute
        /// </summary>
        /// <param name="path">Path to database file</param>
        public ClimbingRouteDatabase(string path)
            : base(path)
        {
            CreateTable<ClimbingRoute>();
            CreateTable<ClimbingTag>();
            CreateTable<ClimbingTagMap>();
        }

        /// <summary>
        /// Implementation for SQLiteConnection GetItems
        /// </summary>
        public IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in Table<T>() select i).ToList();
            }
        }

        /// <summary>
        /// Implementation for SQLiteConnection GetItem
        /// </summary>
        /// <param name="id">ID of the table entry</param>
        public T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
        }

        /// <summary>
        /// Implementation for SQLiteConnection SaveItem
        /// </summary>
        /// <param name="item">Value of item to save</param>
        public int SaveItem<T>(T item) where T : IBusinessEntity
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    Update(item);
                    return item.ID;
                }
                else
                {
                    return Insert(item);
                }
            }
        }

        /// <summary>
        /// Implementation for SQLiteConnection DeleteItem
        /// </summary>
        /// <param name="id">ID of the table entry</param>
        public int DeleteItem<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return Delete<T>(new T() { ID = id });
            }
        }
    }
}
