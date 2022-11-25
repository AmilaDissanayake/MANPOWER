using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManPowerCore.Domain
{
    public class Promotions
    {
        [DBField("ID")]
        public int PromotionId { get; set; }

        [DBField("EMPLOYMENT_DETAIL_ID")]
        public int EmploymentDetailId { get; set; }

        [DBField("PREVIOUS_DESIGNATION_ID")]
        public int PreDesignationId { get; set; }

        [DBField("NEW_DESIGNATION_ID")]
        public int NewDesignationId { get; set; }

        [DBField("PROMOTED_DATE")]
        public DateTime PromotedDate { get; set; }

        [DBField("PROBATION_END_DATE")]
        public DateTime ProbationEndDate { get; set; }

        [DBField("CONFIRM_DATE")]
        public DateTime ConfirmDate { get; set; }

        [DBField("CONFIRM_BY")]
        public string ConfirmBy { get; set; }
    }
}
