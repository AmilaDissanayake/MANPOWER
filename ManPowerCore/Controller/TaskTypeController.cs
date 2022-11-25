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
    public interface TaskTypeController
    {

        List<TaskType> GetAllTaskType(bool withTaskAllocationDetail);
        TaskType GetTaskType(int id, bool withTaskAllocationDetail);
    }

    public class TaskTypeControllerImpl : TaskTypeController
    {

        DBConnection dBConnection;
        TaskTypeDAO taskTypeDAO = DAOFactory.CreateTaskTypeDAO();

        public List<TaskType> GetAllTaskType(bool withTaskAllocationDetail)
        {
            try
            {
                dBConnection = new DBConnection();
                List<TaskType> list = taskTypeDAO.GetAllTaskType(dBConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailDAO = DAOFactory.CreateTaskAllocationDetailDAO();
                    foreach (var item in list)
                    {
                        item._TaskAllocationDetail = _TaskAllocationDetailDAO.GetTaskAllocationDetailByTaskTypeId(item.TaskTypeId, dBConnection);
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

        public TaskType GetTaskType(int id, bool withTaskAllocationDetail)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                TaskTypeDAO DAO = DAOFactory.CreateTaskTypeDAO();
                TaskType _TaskType = DAO.GetTaskType(id, dbConnection);

                if (withTaskAllocationDetail)
                {
                    TaskAllocationDetailDAO _TaskAllocationDetailController = DAOFactory.CreateTaskAllocationDetailDAO();
                    _TaskType._TaskAllocationDetail = _TaskAllocationDetailController.GetTaskAllocationDetailByTaskTypeId(_TaskType.TaskTypeId, dbConnection);

                }

                return _TaskType;
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
