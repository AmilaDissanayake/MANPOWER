using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProjectStatus
    {


        [DBField("ID")]
        public int ProjectStatusId { get; set; }

        [DBField("NAME")]
        public string ProjectStatusName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }



        public List<ProgramPlan> _ProgramPlan { get; set; }
    }
}
