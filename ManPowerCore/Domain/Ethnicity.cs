using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class Ethnicity
    {
        [DBField("ID")]
        public int EthnicityId{ get; set; }

        [DBField("NAME")]
        public string EthnicityName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
