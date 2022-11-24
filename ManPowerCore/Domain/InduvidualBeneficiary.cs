using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class InduvidualBeneficiary : Beneficiary
    {
        [DBField("ID")]
        public int BenificiaryId { get; set; }

        [DBField("NIC")]
        public string Nic { get; set; }

        [DBField("NAME")]
        public string InduvidualBeneficiaryName { get; set; }

        [DBField("GENDER")]
        public string Gender { get; set; }

        [DBField("DATE_OF_BIRTH")]
        public DateTime DateOfBirth { get; set; }

        [DBField("PERSONAL_ADDRESS")]
        public string PersonalAddress { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }

        [DBField("JOB_PREFERENCE")]
        public string JobPreference { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("WHATSAPP_NUMBER")]
        public string WhatsappNumber { get; set; }

        [DBField("SCHOOL_NAME")]
        public string SchoolName { get; set; }

        [DBField("ADDRESS_OF_SCHOOL")]
        public string AddressOfSchool { get; set; }

        [DBField("GRADE")]
        public string Grade { get; set; }

        [DBField("PARENT_NIC")]
        public string ParentNic { get; set; }
    }
}
