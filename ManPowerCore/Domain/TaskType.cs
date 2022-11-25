using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class TaskType
    {


        [DBField("ID")]
        public int TaskTypeId { get; set; }

        [DBField("NAME")]
        public string TaskTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }


        public List<TaskAllocationDetail> _TaskAllocationDetail { get; set; }

    }
}
