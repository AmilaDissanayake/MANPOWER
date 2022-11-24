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
    public interface ProjectStatusController
    {

        int SaveProjectStatus(ProjectStatus projectStatus);

        int UpdateProjectStatus(ProjectStatus projectStatus);

        List<ProjectStatus> GetAllProjectStatus(bool withProgramPlan);

        ProjectStatus GetProjectStatus(int id, bool withProgramPlan);
    }

    public class ProjectStatusControllerImpl : ProjectStatusController
    {

        DBConnection dBConnection;
        ProjectStatusDAO projectStatusDAO = DAOFactory.CreateProjectStatusDAO();



        public int SaveProjectStatus(ProjectStatus ProjectStatus)
        {

            try
            {
                dBConnection = new DBConnection();
                return projectStatusDAO.SaveProjectStatus(ProjectStatus, dBConnection);
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

        public int UpdateProjectStatus(ProjectStatus ProjectStatus)
        {


            try
            {
                dBConnection = new DBConnection();
                var ProjectStatuss = projectStatusDAO.UpdateProjectStatus(ProjectStatus, dBConnection);
                return ProjectStatuss;
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


        public List<ProjectStatus> GetAllProjectStatus(bool withProgramPlan)
           
        {
            try
            {
                dBConnection = new DBConnection();
                List<ProjectStatus> list = projectStatusDAO.GetAllProjectStatus(dBConnection);

                if (withProgramPlan)
                {

                    ProgramPlanDAO _ProgramPlanDAO = DAOFactory.CreateProgramPlanDAO();
                    foreach (var item in list)
                    {
                        item._ProgramPlan = _ProgramPlanDAO.GetAllProgramPlanByProjectStatusId(item.ProjectStatusId, dBConnection);
                    }

                }

                return list;

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

        public ProjectStatus GetProjectStatus(int id, bool withProgramPlan)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProjectStatusDAO DAO = DAOFactory.CreateProjectStatusDAO();
                 ProjectStatus _ProjectStatus = DAO.GetProjectStatus(id, dbConnection);

                if (withProgramPlan)
                {
                    ProgramPlanDAO _ProgramPlanController = DAOFactory.CreateProgramPlanDAO();
                    _ProjectStatus._ProgramPlan = _ProgramPlanController.GetAllProgramPlanByProjectStatusId(_ProjectStatus.ProjectStatusId, dbConnection);

                }


                return _ProjectStatus;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }

    }
}
