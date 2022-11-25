using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class SystemUser
    {
        [DBField("ID")]
        public int SystemUserId { get; set; }

        [DBField("DESIGNATION_ID")]
        public int DesignationId { get; set; }

        [DBField("USER_TYPE_ID")]
        public int UserTypeId { get; set; }

        [DBField("EMP_NUMBER")]
        public int EmpNumber { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }

        [DBField("CONTACT_NUMBER")]
        public int ContactNumber { get; set; }

        [DBField("USER_NAME")]
        public string UserName { get; set; }

        [DBField("USER_PWD")]
        public string UserPwd { get; set; }

        [DBField("RESET_CODE")]
        public string ResetCode{ get; set; }

        [DBField("VALIDITY_PERIOD")]
        public string ValidityPeriod { get; set; }

        [DBField("RESET_CODE_VALIDITY_PERIOD")]
        public string ResetCodeValidityPeriod { get; set; }

        [DBField("INVALIDE_LOGIN_COUNT")]
        public int InvalideLoginCount { get; set; }

        [DBField("LAST_LOGIN_DATE")]
        public DateTime LastLoginDate { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }

        [DBField("CREATED_USER")]
        public string CreatedUser { get; set; }

        [DBField("CREATED_DATE")]
        public DateTime CreatedDate { get; set; }


        public List<DepartmentUnitPositions> _DepartmentUnitPositions { get; set; }
        public UserType _UserType { get; set; } = new UserType();
        public Designation _Designation { get; set; } = new Designation();
        

    }
}
