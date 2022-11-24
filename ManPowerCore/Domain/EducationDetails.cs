using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class EducationDetails
    {
        [DBField("ID")]
        public int EducationDetailsId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [DBField("EDUCATION_TYPE_ID")]
        public int EducationTypeId { get; set; }

        [DBField("INSTITUTE")]
        public string StudiedInstitute { get; set; }

        [DBField("ATTEMPT")]
        public int NoOfAttempts { get; set; }

        [DBField("YEAR")]
        public int ExamYear { get; set; }

        [DBField("INDEX")]
        public string ExamIndex { get; set; }

        [DBField("SUBJECT")]
        public string ExamSubject { get; set; }

        [DBField("STREAM")]
        public string ExamStream { get; set; }

        [DBField("GRADE")]
        public string ExamGrade { get; set; }

        [DBField("STATUS")]
        public string ExamStatus { get; set; }

        //public Employee _Employee { get; set; } = new Employee();
    }
}
