using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class Religion
    {
        [DBField("ID")]
        public int ReligionId { get; set; }

        [DBField("NAME")]
        public string ReligionName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
