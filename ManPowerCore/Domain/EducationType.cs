using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class EducationType
    {
        [DBField("ID")]
        public int EducationTypeId { get; set; }

        [DBField("NAME")]
        public string EducationTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
