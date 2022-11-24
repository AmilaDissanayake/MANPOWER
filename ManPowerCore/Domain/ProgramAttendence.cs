using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramAttendence
    {

        [DBField("ID")]
        public int ProgramAttendenceId { get; set; }

        [DBField("PROGRAM_PLAN_ID")]
        public int ProgramPlanId { get; set; }

        [DBField("NAME")]
        public string ProgramAttendenceName { get; set; }

        [DBField("ADDRESS")]
        public string Address { get; set; }

        [DBField("NIC")]
        public string NIC { get; set; }

        [DBField("DOB")]
        public DateTime DOB { get; set; }

        [DBField("SEX")]
        public string Sex { get; set; }



        public ProgramPlan _ProgramPlan { get; set; } = new ProgramPlan();
       
    }
}
