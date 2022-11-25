using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Beneficiary
    {
        [DBField("ID")]
        public int BeneficiaryId { get; set; }

        [DBField("BENEFICIARY_TYPE_ID")]
        public int BeneficiaryTypeId { get; set; }

        [DBField("DISTRICT")]
        public string District { get; set; }

        [DBField("DIVISIONAL_SECRETERY")]
        public string DivisionalSecretery { get; set; }
    }
}
