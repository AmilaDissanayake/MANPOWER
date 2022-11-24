using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class TaskAllocation
    {

        [DBField("ID")]
        public int TaskAllocationId { get; set; }

        [DBField("DEPARTMENT_UNIT_POSSITIONS_ID")]
        public int DepartmetUnitPossitionsId { get; set; }

        [DBField("TASK_YEAR_MONTH")]
        public DateTime TaskYearMonth { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }

        [DBField("CREATED_USER")]
        public string CreatedUser { get; set; }

        [DBField("STATUS_ID")]
        public int StatusId { get; set; }

        [DBField("RECOMMENDED_BY")]
        public string RecommendedBy { get; set; }

        [DBField("RECOMMENDED_DATE")]
        public DateTime RecommendedDate { get; set; }

        [DBField("APPROVED_BY")]
        public string ApprovedBy { get; set; }

        [DBField("APPROVED_DATE")]
        public string ApprovedDate { get; set; }

        [DBField("COMMENTS")]
        public string ApprovalComments { get; set; }



        public List<TaskAllocationDetail> _TaskAllocationDetail { get; set; } = new List<TaskAllocationDetail>();
        public DepartmentUnitPositions _DepartmentUnitPositions { get; set; } = new DepartmentUnitPositions();
        public ProjectStatus _ProjectStatus { get; set; } = new ProjectStatus();
        public TaskType _TaskType { get; set; } = new TaskType();



    }
}
