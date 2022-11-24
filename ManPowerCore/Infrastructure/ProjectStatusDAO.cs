using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProjectStatusDAO
    {
        List<ProjectStatus> GetAllProjectStatus(DBConnection dbConnection);

        ProjectStatus GetProjectStatus(int id, DBConnection dbConnection);

        int SaveProjectStatus(ProjectStatus projectStatus, DBConnection dbConnection);

        int UpdateProjectStatus(ProjectStatus projectStatus, DBConnection dbConnection);

    }

    public class ProjectStatusDAOImpl : ProjectStatusDAO 
    {

        public int getMaxProjectStatusId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROJECT_STATUS";
            int orderId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (orderId == 0)
            {
                orderId = 1;
            }
            else
            {
                orderId += 1;
            }


            return orderId;
        }

        public int SaveProjectStatus(ProjectStatus projectStatus, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProjectStatusId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROJECT_STATUS(ID,NAME,IS_ACTIVE) VALUES(@id,@ProjectStatusName,@IsActive)";


                               
                                dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusName", projectStatus.ProjectStatusName);
                                dbConnection.cmd.Parameters.AddWithValue("@IsActive", projectStatus.IsActive);


            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProjectStatus(ProjectStatus projectStatus, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROJECT_STATUS SET NAME = @ProjectStatusName, IS_ACTIVE = @IsActive WHERE ID = @ProjectStatusId ";


                                dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusId", projectStatus.ProjectStatusId);
                                dbConnection.cmd.Parameters.AddWithValue("@ProjectStatusName", projectStatus.ProjectStatusName);
                                dbConnection.cmd.Parameters.AddWithValue("@IsActive", projectStatus.IsActive);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProjectStatus> GetAllProjectStatus(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_STATUS ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProjectStatus>(dbConnection.dr);

        }

        public ProjectStatus GetProjectStatus(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROJECT_STATUS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProjectStatus>(dbConnection.dr);

        }
    }
}
