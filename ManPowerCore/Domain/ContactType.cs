using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Domain
{
    public class ContactType
    {
        [DBField("ID")]
        public int ContactTypeId { get; set; }

        [DBField("NAME")]
        public string ContactTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }
    }
}
