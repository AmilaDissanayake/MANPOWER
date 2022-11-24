using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class MarketType
    {
        [DBField("ID")]
        public int MarketTypeId { get; set; }

        [DBField("NAME")]
        public string MarketTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int Is_Active { get; set; }
    }
}
