using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TaskTypeDAO
    {

        List<TaskType> GetAllTaskType(DBConnection dbConnection);
        TaskType GetTaskType(int id, DBConnection dbConnection);

    }

    public class TaskTypeDAOImpl : TaskTypeDAO
    {

        public List<TaskType> GetAllTaskType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskType>(dbConnection.dr);

        }

        public TaskType GetTaskType(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TaskType>(dbConnection.dr);

        }

    }    
}
