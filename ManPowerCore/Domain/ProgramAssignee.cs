using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramAssignee
    {

        [DBField("ID")]
        public int ProgramAssigneeId { get; set; }

        [DBField("DESIGNATION_ID")]
        public int DesignationId { get; set; }

        [DBField("DEPARTMENT_UNIT_POSSITIONS_ID")]
        public int DepartmentUnitPossitionsId { get; set; }

        [DBField("PROGRAM_TARGET_ID")]
        public int ProgramTargetId { get; set; }



         public ProgramTarget _ProgramTarget { get; set; } = new ProgramTarget();
         public DepartmentUnitPositions _DepartmentUnitPositions { get; set; } = new DepartmentUnitPositions();
         public Designation _Designation { get; set; } = new Designation();

    }
}
