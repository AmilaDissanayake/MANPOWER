using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProjectPlanResource
    {
        [DBField("RESOURCE_PERSON_ID")]
        public int ResourcePersonId { get; set; }

        [DBField("PROGRAM_PLAN_ID")]
        public int ProgramPlanId { get; set; }

        [DBField("WORK_PLACE")]
        public string ProgramName { get; set; }

        [DBField("SUBJECT")]
        public int Subject { get; set; }
    }
}
