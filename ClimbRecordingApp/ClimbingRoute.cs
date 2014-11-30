using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;

namespace ClimbRecordingApp.BusinessLayer
{
    public class ClimbingRoute : IBusinessEntity
    {
        public ClimbingRoute()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
