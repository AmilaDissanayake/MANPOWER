using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramTarget
    {


        [DBField("ID")]
        public int ProgramTargetId { get; set; }

        [DBField("PROGRAM_TYPE_ID")]
        public int ProgramTypeId { get; set; }

        [DBField("PROGRAM_ID")]
        public int ProgramId { get; set; }

        [DBField("TITLE")]
        public string Title { get; set; }

        [DBField("DESCRIPTION")]
        public string Description { get; set; }

        [DBField("START_DATE")]
        public DateTime StartDate { get; set; }

        [DBField("END_DATE")]
        public DateTime EndDate { get; set; }

        [DBField("OUTCOME")]
        public int Outcome { get; set; }

        [DBField("VOTE_NUMBER")]
        public string VoteNumber { get; set; }

        [DBField("NO_OF_PROJECTS")]
        public int NoOfProjects { get; set; }

        [DBField("ESTIMATED_AMOUNT")]
        public float EstimatedAmount { get; set; }

        [DBField("TARGET_YEAR")]
        public int TargetYear { get; set; }

        [DBField("TARGET_MONTH")]
        public int TargetMonth { get; set; }

        [DBField("OUTPUT")]
        public int Output { get; set; }

        [DBField("INSTRACTIONS")]
        public string Instractions { get; set; }

        [DBField("IS_RECOMMENDED")]
        public int IsRecommended { get; set; }

        [DBField("RECOMMENDED_BY")]
        public int RecommendedBy { get; set; }

        [DBField("RECOMMENDED_DATE")]
        public DateTime RecommendedDate { get; set; }


        public Program _Program { get; set; } = new Program();
        public ProgramType _ProgramType { get; set; } = new ProgramType();
        public List<ProgramAssignee> _ProgramAssignee { get; set; } = new List<ProgramAssignee>();
        public List<ProgramPlan> _ProgramPlan { get; set; } = new List<ProgramPlan>();

    }
}
