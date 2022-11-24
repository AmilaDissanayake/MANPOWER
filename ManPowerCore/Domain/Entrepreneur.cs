using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Entrepreneur : Beneficiary
    {
        [DBField("BENEFICIARY_ID")]
        public int BenificiaryId { get; set; }

        [DBField("MARKET_TYPE_ID")]
        public int MarketTypeId { get; set; }

        [DBField("BUSINESS_TYPE_ID")]
        public int BusinessTypeId { get; set; }

        [DBField("NATURE_OF_BUSINESS")]
        public string NatureOfBusiness { get; set; }

        [DBField("BUSINESS_START_DATE")]
        public DateTime BusinessStartDate { get; set; }

        [DBField("AVG_MONTHLY_INCOME")]
        public double AvgMonthlyIncome { get; set; }

        [DBField("NUMBER_OF_WORKERS")]
        public string NumberOfWorkers { get; set; }

        [DBField("CONTACT_NUMBER")]
        public string ContactNumber { get; set; }

        [DBField("BRN")]
        public string Brn { get; set; }

        [DBField("EMAIL")]
        public string Email { get; set; }
    }
}
