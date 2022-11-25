using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class DepartmentUnit
    {
        [DBField("ID")]
        public int DepartmentUnitId { get; set; }

        [DBField("DEPARTMENT_UNIT_TYPE_ID")]
        public int DepartmentUnitTypeId { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }

        [DBField("FAX")]
        public string Fax { get; set; }

        [DBField("ADDRESS_LINE1")]
        public string AddressLine1 { get; set; }

        [DBField("ADDRESS_LINE2")]
        public string AddressLine2 { get; set; }

        [DBField("ADDRESS_LINE3")]
        public string AddressLine3 { get; set; }

        [DBField("PARENT_ID")]
        public int ParentId { get; set; }

        public List<DepartmentUnitPositions> _DepartmentUnitPositions { get; set; }
        public DepartmentUnitType _DepartmentUnitType { get; set; } = new DepartmentUnitType();
    }
}
