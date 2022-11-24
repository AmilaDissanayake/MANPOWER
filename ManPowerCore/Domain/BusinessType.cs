using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class BusinessType
    {
        [DBField("ID")]
        public int BusinessTypeId { get; set; }

        [DBField("NAME")]
        public string BusinessTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int Is_Active { get; set; }
    }
}
