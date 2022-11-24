using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class BeneficiaryType
    {
        [DBField("ID")]
        public int BeneficiaryTypeId { get; set; }

        [DBField("NAME")]
        public string BeneficiaryTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
