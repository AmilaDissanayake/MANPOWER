using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Dependant
    {
        [DBField("ID")]
        public int DependantId { get; set; }

        [DBField("DEPENDENT_TYPE_ID")]
        public int DependantTypeId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmpId { get; set; }

        [DBField("FIRST_NAME")]
        public string FirstName { get; set; }

        [DBField("LAST_NAME")]
        public string LastName { get; set; }

        [DBField("NIC")]
        public string DependantNIC { get; set; }

        [DBField("PASSPORT_NO")]
        public string DependantPassportNo { get; set; }

        [DBField("BIRTH_CERTIFICATE_NUMBER")]
        public int BirthCertificateNumber { get; set; }

        [DBField("DATE_OF_BIRTH")]
        public DateTime Dob { get; set; }

        [DBField("RELATIONSHIP")]
        public string RelationshipToEmp { get; set; }

        [DBField("SPECIAL_REMARKS")]
        public string Remarks { get; set; }

        [DBField("MARRIAGE_DATE")]
        public DateTime MarriageDate { get; set; }

        [DBField("MARRIAGE_CERTIFICATE_NUMBER")]
        public int MarriageCertificateNo { get; set; }

        [DBField("WORKING_COMPANY")]
        public string WorkingCompany { get; set; }

        [DBField("CITY")]
        public string City { get; set; }


        //public Employee _Employee { get; set; } = new Employee();
    }
}
