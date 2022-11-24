using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Possitions
    {
        [DBField("ID")]
        public int PossitionId { get; set; }

        [DBField("NAME")]
        public string PositionName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }


        public List<DepartmentUnitPositions> _DepartmentUnitPositions { get; set; }
    }
}
