using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class UserType
    {
        [DBField("ID")]
        public int UserTypeId { get; set; }

        [DBField("NAME")]
        public string UserTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }


        public List<SystemUser> _SystemUser { get; set; }
    }


}
