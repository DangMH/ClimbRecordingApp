using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ClimbRecordingApp.BusinessLayer
{
    public abstract class ClimbingGrade
    {
        public const int MAX_GRADE_FORMAT_LENGTH = 25;
        public const int MAX_GRADE_FORMAT_TITLE_LENGTH = 50;

        public abstract string GetGradeFormatString();

        public abstract static string GetGradeFormatTitle();
    }
}
