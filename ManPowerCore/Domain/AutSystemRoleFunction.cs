using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class AutSystemRoleFunction
    {
        [DBField("AUT_SYSTEM_ID")]
        public int AutSystemId { get; set; }

        [DBField("USER_Type_ID")]
        public int UserTypeId { get; set; }

        [DBField("AUT_FUNCTION_ID")] 
        public int AutFunctionId { get; set; }
    }
}
