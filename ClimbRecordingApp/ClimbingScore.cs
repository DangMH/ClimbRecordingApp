using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;

namespace ClimbRecordingApp.BusinessLayer
{
    public class ClimbingScore : IBusinessEntity
    {
        public const int MAX_GRADE_FORMAT_LENGTH = 10;

        public ClimbingScore()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int UNIVERSAL_SCORE { get; set; }
        public int GRADE_FORMAT_ID { get; set; }
        [MaxLength(MAX_GRADE_FORMAT_LENGTH)]
        public string GRADE_FORMAT_STRING { get; set; }
    }
}
