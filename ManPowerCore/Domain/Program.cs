using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class Program
    {

        [DBField("ID")]
        public int ProgramId { get; set; }

        [DBField("NAME")]
        public string ProgramName { get; set; }

        [DBField("PROGRAM_TYPE_ID")]
        public int ProgramType { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }


        public List<ProgramTarget> _ProgramTarget { get; set; }
        public ProgramType _ProgramType { get; set; } = new ProgramType();


    }
}
