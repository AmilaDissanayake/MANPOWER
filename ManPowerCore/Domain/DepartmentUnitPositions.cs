using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class DepartmentUnitPositions
    {
        [DBField("ID")]
        public int DepartmetUnitPossitionsId { get; set; }

        [DBField("SYSTEM_USER_ID")]
        public int SystemUserId { get; set; }

        [DBField("POSSITIONS_ID")]
        public int PossitionsId { get; set; }

        [DBField("DEPARTMENT_UNIT_ID")]
        public int DepartmentUnitId { get; set; }

        [DBField("PARENT_ID")]
        public int ParentId { get; set; }

        public List<TaskAllocation> _TaskAllocation { get; set; }
        public List<ProgramAssignee> _ProgramAssignee { get; set; }
        public SystemUser _SystemUser { get; set; } = new SystemUser();
        public Possitions _Possitions { get; set; } = new Possitions();
        public DepartmentUnit _DepartmentUnit { get; set; } = new DepartmentUnit();

      
    }
}
