using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TaskAllocationDetailDAO
    {

        int SaveTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail, DBConnection dbConnection);
        int UpdateTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail, DBConnection dbConnection);
        List<TaskAllocationDetail> GetAllTaskAllocationDetail(DBConnection dbConnection);
        TaskAllocationDetail GetTaskAllocationDetail(int id, DBConnection dbConnection);
        List<TaskAllocationDetail> GetAllTaskAllocationDetailByTaskAllocationId(int taskAllocationId, DBConnection dbConnection);
        List<TaskAllocationDetail> GetTaskAllocationDetailByTaskTypeId(int TaskTypeId, DBConnection dbConnection);
        int DeleteTaskAllocationDetail(int id, DBConnection dbConnection);

    }


    public class TaskAllocationDetailDAOImpl : TaskAllocationDetailDAO
    {

        public int getMaxTaskAllocationDetailId(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM TASK_ALLOCATION_DETAIL";
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

        public int SaveTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO TASK_ALLOCATION_DETAIL(TASK_TYPE_ID,TASK_ALLOCATION_ID" +
                                            ",TASK_DESCRIPTION,WORK_LOCATION,IS_COMPLETED,NOT_COMPLETED_REASON,START_TIME,END_TIME,REMARKS,AMENDMENTS) " +
                                            "VALUES(@TaskTypeId,@TaskAllocationId,@TaskDescription,@WorkLocation,@Isconmpleated,@NotCompleatedReason,@StartTime,@EndTime,@TaskRemarks,@TaskAmendments) ";

                                          
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskTypeId", taskAllocationDetail.TaskTypeId);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskAllocationId", taskAllocationDetail.TaskAllocationId);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskDescription", taskAllocationDetail.TaskDescription);
                                            dbConnection.cmd.Parameters.AddWithValue("@WorkLocation", taskAllocationDetail.WorkLocation);
                                            dbConnection.cmd.Parameters.AddWithValue("@Isconmpleated", taskAllocationDetail.Isconmpleated);
                                            dbConnection.cmd.Parameters.AddWithValue("@NotCompleatedReason", taskAllocationDetail.NotCompleatedReason);
                                            dbConnection.cmd.Parameters.AddWithValue("@StartTime", taskAllocationDetail.StartTime);
                                            dbConnection.cmd.Parameters.AddWithValue("@EndTime", taskAllocationDetail.EndTime);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskRemarks", taskAllocationDetail.TaskRemarks);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskAmendments", taskAllocationDetail.TaskAmendments);


            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public int UpdateTaskAllocationDetail(TaskAllocationDetail taskAllocationDetail, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE TASK_ALLOCATION_DETAIL SET TASK_TYPE_ID = @TaskTypeId, TASK_ALLOCATION_ID = @TaskAllocationId, " +
                                           "TASK_DESCRIPTION = @TaskDescription, WORK_LOCATION = @WorkLocation, IS_COMPLETED = @Isconmpleated, NOT_COMPLETED_REASON=@NotCompleatedReason, START_TIME = @StartTime, END_TIME = @EndTime, REMARKS=@TaskRemarks, AMENDMENTS=@TaskAmendments WHERE ID = @TaskAllocationDetailId";
                                          
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskAllocationDetailId", taskAllocationDetail.TaskAllocationDetailId);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskTypeId", taskAllocationDetail.TaskTypeId);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskAllocationId", taskAllocationDetail.TaskAllocationId);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskDescription", taskAllocationDetail.TaskDescription);
                                            dbConnection.cmd.Parameters.AddWithValue("@WorkLocation", taskAllocationDetail.WorkLocation);
                                            dbConnection.cmd.Parameters.AddWithValue("@Isconmpleated", taskAllocationDetail.Isconmpleated);
                                            dbConnection.cmd.Parameters.AddWithValue("@NotCompleatedReason", taskAllocationDetail.NotCompleatedReason);
                                            dbConnection.cmd.Parameters.AddWithValue("@StartTime", taskAllocationDetail.StartTime);
                                            dbConnection.cmd.Parameters.AddWithValue("@EndTime", taskAllocationDetail.EndTime);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskRemarks", taskAllocationDetail.TaskRemarks);
                                            dbConnection.cmd.Parameters.AddWithValue("@TaskAmendments", taskAllocationDetail.TaskAmendments);





            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<TaskAllocationDetail> GetAllTaskAllocationDetail(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION_DETAIL ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocationDetail>(dbConnection.dr);

        }

        public TaskAllocationDetail GetTaskAllocationDetail(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION_DETAIL WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TaskAllocationDetail>(dbConnection.dr);

        }

        public List<TaskAllocationDetail> GetAllTaskAllocationDetailByTaskAllocationId(int taskAllocationId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION_DETAIL WHERE TASK_ALLOCATION_ID  = " + taskAllocationId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocationDetail>(dbConnection.dr);

        }

        public List<TaskAllocationDetail> GetTaskAllocationDetailByTaskTypeId(int TaskTypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION_DETAIL WHERE TASK_TYPE_ID  = " + TaskTypeId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocationDetail>(dbConnection.dr);

        }

        public int DeleteTaskAllocationDetail(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "DELETE FROM TASK_ALLOCATION_DETAIL WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return 1;

        }

    }

}



