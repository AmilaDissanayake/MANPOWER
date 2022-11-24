using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramType
    {

        [DBField("ID")]
        public int ProgramTypeId { get; set; }

        [DBField("NAME")]
        public string ProgramTypeName { get; set; }

        [DBField("IS_ACTIVE")]
        public int IsActive { get; set; }



        public List<ProgramTarget> _ProgramTarget { get; set; }
        public List<Program> _Program { get; set; } = new List<Program>();

    }
}
