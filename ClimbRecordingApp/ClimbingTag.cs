using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;

namespace ClimbRecordingApp.BusinessLayer
{
    /// <summary>
    /// Class Representing a Climbing Tag Entry.
    /// ID - entry ID
    /// NAME - String representation of the tag "i.e., Slopers, Crimps, etc."
    /// </summary>
    public class ClimbingTag : IBusinessEntity
    {
        public const int MAX_TAG_LENGTH = 25;

        public ClimbingTag()
        {

        }

        /// <summary>
        /// ID of the table entry
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        /// <summary>
        /// String representation of the Climbing Tag
        /// </summary>
        [MaxLength(MAX_TAG_LENGTH)]
        public string NAME { get; set; }
    }
}
