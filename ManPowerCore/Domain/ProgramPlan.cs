using ManPowerCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Domain
{
    public class ProgramPlan
    {


        [DBField("ID")]
        public int ProgramPlanId { get; set; }

        [DBField("PROJECT_STATUS_ID")]
        public int ProjectStatusId { get; set; }

        [DBField("PROGRAM_CATEGORY_ID")]
        public int ProgramCategoryId { get; set; }

        [DBField("PROGRAM_TARGET_ID")]
        public int ProgramTargetId { get; set; }


        [DBField("DATE")]
        public DateTime Date { get; set; }

        [DBField("LOCATION")]
        public string Location { get; set; }

        [DBField("OUTCOME")]
        public int Outcome { get; set; }

        [DBField("OUTPUT")]
        public int Output { get; set; }

        [DBField("ACTUAL_OUTPUT")]
        public int ActualOutput { get; set; }

        [DBField("IS_APPROVED")]
        public int IsApproved { get; set; }

        [DBField("APPROVED_BY")]
        public string ApprovedBy { get; set; }

        [DBField("APPROVED_DATE")]
        public DateTime ApprovedDate { get; set; }

        [DBField("TOTAL_ESTIMATED_AMOUNT")]
        public float TotalEstimatedAmount { get; set; }

        [DBField("APPROVED_AMOUNT")]
        public float ApprovedAmount { get; set; }

        [DBField("ACTUAL_AMOUNT")]
        public float ActualAmount { get; set; }

        [DBField("MALE_COUNT")]
        public int MaleCount { get; set; }

        [DBField("FEMALE_COUNT")]
        public int FemaleCount { get; set; }

        [DBField("COORDINATER")]
        public string Coordinater { get; set; }

        [DBField("REMARK")]
        public string Remark { get; set; }

        [DBField("PROGRAM_NAME")]
        public string ProgramName { get; set; }

        [DBField("FINANCIAL_SOURCE")]
        public string FinancialSource { get; set; }

        //SAVE
        //UPDATE
        //GETBYID
        //IF DEF ->GET ALL

        //---------------------
        //GET_PROGRAM_ATTENDANCE_BY 
        //GET_PROGRAM_BUDGET


        public List<ProgramAttendence> _ProgramAttendence { get; set; } 
        public List<ProgramBudget> _ProgramBudget { get; set; }
        public List<ProjectTask> _ProjectTask { get; set; }

        public ProgramCategory _ProgramCategory { get; set; } = new ProgramCategory();
        public ProjectStatus _ProjectStatus { get; set; } = new ProjectStatus();
        public ProgramTarget _ProgramTarget { get; set; } = new ProgramTarget();


    }
}
