using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManPowerCore.Domain
{
    public class ContactMode
    {
        [DBField("ID")]
        public int ContactModeId { get; set; }

        [DBField("NAME")]
        public string ContactModeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }

        [DBField("AIIAS")]
        public int ContactAlias { get; set; }
    }
}
