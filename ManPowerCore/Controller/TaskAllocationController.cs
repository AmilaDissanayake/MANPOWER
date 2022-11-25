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
    public interface TaskAllocationController
    {

        int SaveTaskAllocation(TaskAllocation taskAllocation);

        int UpdateTaskAllocation(TaskAllocation taskAllocation);

        int UpdateTaskAllocationApproval(int id, int status, string officer, string remarks);

        List<TaskAllocation> GetAllTaskAllocation(bool withTaskAllocationDetail, bool withDepartmentUnitPositions, bool withProjectStatus, bool withTaskType);

        TaskAllocation GetTaskAllocation(int id, bool withTaskAllocationDetail, bool withDepartmentUnitPositions);

    }


    public class TaskAllocationControllerImpl : TaskAllocationController
    {

        DBConnection dBConnection;
        TaskAllocationDAO taskAllocationDAO = DAOFactory.CreateTaskAllocationDAO();


        public int SaveTaskAllocation(TaskAllocation taskAllocation)
        {

            try
            {
                int id = 0;

                foreach (var j in taskAllocation._TaskAllocationDetail)
                {
                    dBConnection = new DBConnection();
                    List<TaskAllocation> list = taskAllocationDAO.GetAllTaskAllocation(dBConnection);
                    if (list.Where(u => u.TaskYearMonth.Month == j.StartTime.Month 
                    && u.CreatedUser == taskAllocation.CreatedUser).Count() != 0)
                    {
                        foreach (var prop in list.Where(u => u.TaskYearMonth.Month == j.StartTime.Month && u.CreatedUser == taskAllocation.CreatedUser))
                        {
                            id = prop.TaskAllocationId;
                        }
                    }
                    else
                    {
                        dBConnection = new DBConnection();
                        id = taskAllocationDAO.SaveTaskAllocation(taskAllocation, dBConnection);
                    }
                }

                if (taskAllocation._TaskAllocationDetail.Count > 0)
                {
                    TaskAllocationDetailDAO taskAllocationDetail = DAOFactory.CreateTaskAllocationDetailDAO();
                    foreach (var i in taskAllocation._TaskAllocationDetail)
                    {
                        i.TaskAllocationId = id;
                        taskAllocationDetail.SaveTaskAllocationDetail(i, dBConnection);
                    }
                }

                return 1;
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

        public int UpdateTaskAllocation(TaskAllocation taskAllocation)
        {

            try
            {
                dBConnection = new DBConnection();
                var taskAllocations = taskAllocationDAO.UpdateTaskAllocation(taskAllocation, dBConnection);
                return taskAllocations;
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


        public int UpdateTaskAllocationApproval(int id, int status, string officer, string remarks)
        {

            try
            {
                dBConnection = new DBConnection();
                var taskAllocations = taskAllocationDAO.UpdateTaskAllocation(id, status, officer, remarks, dBConnection);
                return taskAllocations;
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


        public List<TaskAllocation> GetAllTaskAllocation(bool withTaskAllocationDetail, bool withDepartmentUnitPositions, bool withProjectStatus, bool withTaskType)
        {
            try
            {
                dBConnection = new DBConnection();
                List<TaskAllocation> list = taskAllocationDAO.GetAllTaskAllocation(dBConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailDAO = DAOFactory.CreateTaskAllocationDetailDAO();
                    foreach (var item in list)
                    {
                        item._TaskAllocationDetail = _TaskAllocationDetailDAO.GetAllTaskAllocationDetailByTaskAllocationId(item.TaskAllocationId, dBConnection);
                    }
                }


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsDAO = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    foreach (var item in list)
                    {
                        item._DepartmentUnitPositions = _DepartmentUnitPositionsDAO.GetDepartmentUnitPositions(item.TaskAllocationId, dBConnection);
                    }
                }

                if (withTaskAllocationDetail)
                {
                    ProjectStatusDAO _ProjectStatusDAO = DAOFactory.CreateProjectStatusDAO();
                    foreach (var item in list)
                    {
                        item._ProjectStatus = _ProjectStatusDAO.GetProjectStatus(item.TaskAllocationId, dBConnection);
                    }
                }

                if (withTaskType)
                {
                    TaskTypeDAO _TaskTypeDAO = DAOFactory.CreateTaskTypeDAO();
                    foreach (var item in list)
                    {
                        item._TaskType = _TaskTypeDAO.GetTaskType(item.TaskAllocationId, dBConnection);
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

        public TaskAllocation GetTaskAllocation(int id, bool withTaskAllocationDetail, bool withDepartmentUnitPositions)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TaskAllocationDAO DAO = DAOFactory.CreateTaskAllocationDAO();
                TaskAllocation _TaskAllocation = DAO.GetTaskAllocation(id, dbConnection);


                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailController = DAOFactory.CreateTaskAllocationDetailDAO();
                    _TaskAllocation._TaskAllocationDetail = _TaskAllocationDetailController.GetAllTaskAllocationDetailByTaskAllocationId(_TaskAllocation.TaskAllocationId, dbConnection);

                }


                if (withDepartmentUnitPositions)
                {
                    DepartmentUnitPositionsDAO _DepartmentUnitPositionsController = DAOFactory.CreateDepartmentUnitPositionsDAO();
                    _TaskAllocation._DepartmentUnitPositions = _DepartmentUnitPositionsController.GetDepartmentUnitPositions(_TaskAllocation.TaskAllocationId, dbConnection);

                }



                return _TaskAllocation;
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

