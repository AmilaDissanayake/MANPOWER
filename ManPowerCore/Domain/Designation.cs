using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Designation
    {
        [DBField("ID")]
        public int DesignationId { get; set; }

        [DBField("NAME")]
        public string DesigntionName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }


        public List<SystemUser> _SystemUser { get; set; }
        public List<ProgramAssignee> _ProgramAssignee { get; set; }
    }
}
