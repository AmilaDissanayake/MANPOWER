using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class CompanyVecansyRegistationDetails
    {

        [DBField("ID")]
        public int CompanyVacansyRegistationDetailsId { get; set; }

        [DBField("DATE")]
        public DateTime Date { get; set; }

        [DBField("ADDRESS")]
        public string Address { get; set; }

        [DBField("WEBSITE_LINK")]
        public string WebSiteLink { get; set; }

        [DBField("BR_NUMBER")]
        public string BusinessRegistationNumber { get; set; }

        [DBField("JOB_POSITION")]
        public string JobPosition { get; set; }

        [DBField("CAREER_PATH")]
        public string CareerPath { get; set; }

        [DBField("SALARY_LEVEL")]
        public string SalaryLevel { get; set; }

        [DBField("NUMBER_OF_VACANCY")]
        public int NumberOfVacancy { get; set; }

        [DBField("NAME")]
        public string Name { get; set; }

        [DBField("POSITION")]
        public string Position { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("WHATSAPP_NUMBER")]
        public string WhatsappNumber { get; set; }

        [DBField("LEVELS")]
        public string Levels { get; set; }

        [DBField("Email")]
        public string Email { get; set; }



    }
}
