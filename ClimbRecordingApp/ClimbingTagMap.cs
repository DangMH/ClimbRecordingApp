using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;

namespace ClimbRecordingApp.BusinessLayer
{
    /// <summary>
    /// Table mapping Climbing Routes to the Appropriate Climb Tag.
    /// ID - ID of the table entry
    /// CLIMBING_ROUTE_ID - ID of the Climbing Route entry
    /// CLIMBING_TAG_ID - ID of the Climbing Tag entry
    /// </summary>
    /// <remarks>Derived from: http://stackoverflow.com/questions/1810356/how-to-implement-tag-system</remarks>
    public class ClimbingTagMap : IBusinessEntity
    {
        public ClimbingTagMap()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CLIMBING_ROUTE_ID { get; set; }
        public int CLIMBING_TAG_ID { get; set; }
    }
}
