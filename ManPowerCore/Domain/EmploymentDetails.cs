using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManPowerCore.Domain
{
    public class EmploymentDetails
    {
        [DBField("ID")]
        public int EmploymentDetailId { get; set; }

        [DBField("DESIGNATION_ID")]
        public int DesignationId { get; set; }

        [DBField("CONTRACT_TYPE_ID")]
        public int ContractTypeId { get; set; }

        [DBField("EMPLOYEE_ID")]
        public int EmpID { get; set; }

        [DBField("COMPANY_NAME")]
        public string CompanyName { get; set; }

        [DBField("START_DATE")]
        public DateTime StartDate { get; set; }

        [DBField("END_DATE")]
        public DateTime EndDate { get; set; }

        [DBField("IS_RESIGNED")]
        public int IsResigned { get; set; }

        [DBField("RETIREMENT_DATE")]
        public DateTime RetirementDate { get; set; }

        [DBField("EPF_NUMBER")]
        public int Epf { get; set; }

        //public Employee _Employee { get; set; } = new Employee();
    }
}
