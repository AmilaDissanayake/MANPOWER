using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramBudget
    {

        [DBField("ID")]
        public int ProgramBudgetId { get; set; }

        [DBField("PROGRAM_PLAN_ID")]
        public int ProgramPlanId { get; set; }

        [DBField("DESCRIPTION")]
        public string Description { get; set; }

        [DBField("ESTIMATED_AMOUNT")]
        public float EstimatedAmount { get; set; }

        [DBField("APPROVED_AMOUNT")]
        public float ApprovedAmount { get; set; }

        [DBField("ACTUAL_AMOUNT")]
        public float ActualAmount { get; set; }



        public ProgramPlan _ProgramPlan { get; set; } = new ProgramPlan();
    }
}
