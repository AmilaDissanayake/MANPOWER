using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramCategory
    {


        [DBField("ID")]
        public int ProgramCategoryId { get; set; }

        [DBField("NAME")]
        public string ProgramCategoryName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }



        public List<ProgramPlan> _ProgramPlan { get; set; }
    }
}
