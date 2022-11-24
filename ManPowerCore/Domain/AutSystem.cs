using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class AutSystem
    {
        [DBField("ID")]
        public int AutSystemId { get; set; }

        [DBField("NAME")]
        public string SystemName { get; set; }
    }
}
