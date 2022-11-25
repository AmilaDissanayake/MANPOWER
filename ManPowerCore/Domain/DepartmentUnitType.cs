using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class DepartmentUnitType
    {
        [DBField("ID")]
        public int DepartmentUnitTypeId{ get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }



        public List<DepartmentUnit> _DepartmentUnit { get; set; }

    }
}
