using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProjectPlanResourceDAO
    {
        int SaveProjectPlanResource(ProjectPlanResource projectPlanResource, DBConnection dbConnection);
    }

    public class ProjectPlanResourceDAOImpl : ProjectPlanResourceDAO
    {
        public int SaveProjectPlanResource(ProjectPlanResource projectPlanResource, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROJECT_PLAN_RESOURCE(RESOURCE_PERSON_ID,PROGRAM_PLAN_ID, WORK_PLACE, SUBJECT) values " +
                $"(?,?,?,?,?) ";


            dbConnection.cmd.Parameters.AddWithValue("RESOURCE_PERSON_ID", projectPlanResource.ResourcePersonId);
            dbConnection.cmd.Parameters.AddWithValue("PROGRAM_PLAN_ID", projectPlanResource.ProgramPlanId);
            dbConnection.cmd.Parameters.AddWithValue("WORK_PLACE", projectPlanResource.ProgramName);
            dbConnection.cmd.Parameters.AddWithValue("SUBJECT", projectPlanResource.Subject);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            dbConnection.cmd.ExecuteNonQuery();

            return 1;
        }
    }
}
