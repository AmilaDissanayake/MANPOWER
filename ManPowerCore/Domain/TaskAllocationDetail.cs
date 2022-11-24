using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class TaskAllocationDetail
    {


        [DBField("ID")]
        public int TaskAllocationDetailId { get; set; }

        [DBField("TASK_TYPE_ID")]
        public int TaskTypeId { get; set; }

        [DBField("TASK_ALLOCATION_ID")]
        public int TaskAllocationId { get; set; }

        [DBField("TASK_DESCRIPTION")]
        public string TaskDescription { get; set; }

        [DBField("WORK_LOCATION")]
        public string WorkLocation { get; set; }

        [DBField("IS_COMPLETED")]
        public int Isconmpleated { get; set; }

        [DBField("NOT_COMPLETED_REASON")]
        public string NotCompleatedReason { get; set; }


        [DBField("START_TIME")]
        public DateTime StartTime { get; set; }

        [DBField("END_TIME")]
        public DateTime EndTime { get; set; }


        [DBField("REMARKS")]
        public string TaskRemarks { get; set; }

        [DBField("AMENDMENTS")]
        public string TaskAmendments { get; set; }




        public List<ProjectTask> _ProjectTask { get; set; }
        public TaskType _TaskType { get; set; } = new TaskType();
        public TaskAllocation _TaskAllocation { get; set; } = new TaskAllocation();


    }
}
