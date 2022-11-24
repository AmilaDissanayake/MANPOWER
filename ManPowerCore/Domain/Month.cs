using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Month
    {
        public string monthName { get; set; }
        public int monthNumber { get; set; }

        List<Month> list = new List<Month>();
    }
}
