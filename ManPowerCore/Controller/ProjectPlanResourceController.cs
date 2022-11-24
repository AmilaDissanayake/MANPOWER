using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface ProjectPlanResourceController
    {
        int SaveProjectPlanResource(ProjectPlanResource projectPlanResource);
    }

    public class ProjectPlanResourceControllerImpl : ProjectPlanResourceController
    {
        DBConnection dBConnection;
        ProjectPlanResourceDAO ProjectPlanResourceDAO = DAOFactory.CreateProjectPlanResourceDAO();

        public int SaveProjectPlanResource(ProjectPlanResource projectPlanResource)
        {

            try
            {
                dBConnection = new DBConnection();
                return ProjectPlanResourceDAO.SaveProjectPlanResource(projectPlanResource, dBConnection);
            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}
