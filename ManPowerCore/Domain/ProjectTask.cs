using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProjectTask
    {

        [DBField("ID")]
        public int ProjectTaskId { get; set; }

        [DBField("PROGRAM_PLAN_ID")]
        public int ProgramPlanId { get; set; }

        [DBField("TASK_ALLOCATION_DETAIL_ID")]
        public int TaskAllocationDetailId { get; set; }


        public TaskAllocationDetail _TaskAllocationDetail { get; set; } = new TaskAllocationDetail();
        public ProgramPlan _ProgramPlan { get; set; } = new ProgramPlan();
    }
}
