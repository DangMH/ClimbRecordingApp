using ClimbRecordingApp.BusinessLayer.Contracts;
using ClimbRecordingApp.DataLayer.SQLite;
using System;

namespace ClimbRecordingApp.BusinessLayer
{
    public class ClimbingRoute : IBusinessEntity
    {
        public const int MAX_NAME_LENGTH = 25;

        public ClimbingRoute()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public bool IS_ROPE { get; set; }
        public bool IS_OUTDOORS { get; set; }
        public int UNIVERSAL_SCORE { get; set; }
        public DateTime DATE_SENT { get; set; }
        public DateTime DATE_SET_OR_FA { get; set; }
        [MaxLength(MAX_NAME_LENGTH)]
        public string LOCATION { get; set; }
        [MaxLength(MAX_NAME_LENGTH)]
        public string SETTER_OR_FA { get; set; }
        [MaxLength(MAX_NAME_LENGTH)]
        public string NAME { get; set; }
        
    }
}
