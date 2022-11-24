using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class DME21Model
    {
        public int type { get; set; }

        public string workPlace { get; set; }

        public string workDuty { get; set; }

        public DateTime? startTime{ get; set; }

        public DateTime? endTime{ get; set; }

        public string workRemarks { get; set; }
    }
}
