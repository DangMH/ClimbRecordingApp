using System;
using System.Collections.Generic;

namespace ClimbRecordingApp.BusinessLayer
{
    public class ClimbRecordingApp
    {
        private ClimberStats climberStats = null;
        private Dictionary<string, int> formattedGradeToUniversalScore = null;
        private Dictionary<int, Dictionary<string, string>> universalScoreToFormattedGrade = null;

        public ClimberStats GetClimberStats(bool isRope, DateTime startDateSent, DateTime endDateSent, string location, string setterOrFA)
        {
            throw new System.NotImplementedException();
        }

        public void GetGradeFormats()
        {
            throw new System.NotImplementedException();
        }
    }
}
