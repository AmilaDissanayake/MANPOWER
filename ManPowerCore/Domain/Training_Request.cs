using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Training_Request
    {
        [DBField("ID")]
        public int TrainingRequestId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int Employee_Id { get; set; }

        [DBField("PROGRAM_DATE")]
        public DateTime? ProgramDate { get; set; }

        [DBField("PROGRAM_ID")]
        public int ProgramId { get; set; }

        [DBField("REQUESTED_DATE")]
        public DateTime? TrainingRequestName { get; set; }

        [DBField("IS_APPROVED")]
        public string IsApproved { get; set; }

        [DBField("APPROVED_BY")]
        public string ApprovedBy { get; set; }

        [DBField("APPROVED_DATE")]
        public DateTime? ApprovedDate { get; set; }

    }
}