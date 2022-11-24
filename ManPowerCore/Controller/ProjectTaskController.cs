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
    public interface ProjectTaskController
    {

        List<ProjectTask> GetAllProjectTask(bool withTaskAllocationDetail);
        ProjectTask GetProjectTask(int id, bool withTaskAllocationDetail);

    }

    public class ProjectTaskControllerImpl : ProjectTaskController
    {


        DBConnection dBConnection;
        ProjectTaskDAO projectTaskDAO = DAOFactory.CreateProjectTaskDAO();
        public List<ProjectTask> GetAllProjectTask(bool withTaskAllocationDetail)
        {
           
                try
                {
                    dBConnection = new DBConnection();
                    List<ProjectTask> list = projectTaskDAO.GetAllProjectTask(dBConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailDAO = DAOFactory.CreateTaskAllocationDetailDAO();
                    foreach (var item in list)
                    {
                        item._TaskAllocationDetail = _TaskAllocationDetailDAO.GetTaskAllocationDetail(item.ProjectTaskId, dBConnection);
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
        

        public ProjectTask GetProjectTask(int id, bool withTaskAllocationDetail)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ProjectTaskDAO DAO = DAOFactory.CreateProjectTaskDAO();
                ProjectTask _ProjectTask = DAO.GetProjectTask(id, dbConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailController = DAOFactory.CreateTaskAllocationDetailDAO();
                    _ProjectTask._TaskAllocationDetail = _TaskAllocationDetailController.GetTaskAllocationDetail(_ProjectTask.TaskAllocationDetailId, dbConnection);

                }

                return _ProjectTask;
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

