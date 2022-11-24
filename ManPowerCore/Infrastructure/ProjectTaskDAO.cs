using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProjectTaskDAO
    {
        List<ProjectTask> GetAllProjectTask(DBConnection dbConnection);
        ProjectTask GetProjectTask(int id, DBConnection dbConnection);

        List<ProjectTask> GetProjectTaskByTaskAllocationDetailId(int TaskAllocationDetailId, DBConnection dbConnection);
        List<ProjectTask> GetAllProjectTaskByProgramPlanId(int ProgramPlanId, DBConnection dbConnection);


    }


    public class ProjectTaskDAOImpl : ProjectTaskDAO
    {
        public List<ProjectTask> GetAllProjectTask(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }

        public ProjectTask GetProjectTask(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProjectTask>(dbConnection.dr);
        }

        public List<ProjectTask> GetProjectTaskByTaskAllocationDetailId(int TaskAllocationDetailId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE TASK_ALLOCATION_DETAIL_ID = " + TaskAllocationDetailId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }

        public List<ProjectTask> GetAllProjectTaskByProgramPlanId(int ProgramPlanId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_TASK WHERE PROGRAM_PLAN_ID = " + ProgramPlanId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectTask>(dbConnection.dr);
        }
    }
}
