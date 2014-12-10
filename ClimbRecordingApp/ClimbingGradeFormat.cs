using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;

namespace ClimbRecordingApp.BusinessLayer
{
    public class ClimbingGradeFormat : IBusinessEntity
    {
        public const int MAX_GRADE_FORMAT_TITLE_LENGTH = 25;

        public ClimbingGradeFormat()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public bool IS_ROPE { get; set; }
        [MaxLength(MAX_GRADE_FORMAT_TITLE_LENGTH)]
        public string TITLE { get; set; }
    }
}
