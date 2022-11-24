using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface TaskAllocationDAO
    {

        int SaveTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection);

        int UpdateTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection);

        int UpdateTaskAllocation(int id, int status, string officer, string remarks,  DBConnection dbConnection);

        int DeleteTaskAllocation(int id, DBConnection dbConnection);

        List<TaskAllocation> GetAllTaskAllocation(DBConnection dbConnection);

        TaskAllocation GetTaskAllocation(int id, DBConnection dbConnection);

        List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId, DBConnection dbConnection);

    }

    public class TaskAllocationDAOImpl : TaskAllocationDAO
    {

        public int getMaxTaskAllocationId(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM TASK_ALLOCATION";
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

        public int SaveTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO TASK_ALLOCATION(DEPARTMENT_UNIT_POSSITIONS_ID,TASK_YEAR_MONTH" +
                                            ",CREATED_DATE,CREATED_USER,STATUS_ID,RECOMMENDED_BY,RECOMMENDED_DATE,APPROVED_BY,APPROVED_DATE) " +
                                            "VALUES(@DepartmetUnitPossitionsId,@TaskYearMonth,@CreatedDate,@CreatedUser,@StatusId," +
                                            "@RecommendedBy,@RecommendedDate,@ApprovedBy,@ApprovedDate) SELECT SCOPE_IDENTITY() ";



            
            dbConnection.cmd.Parameters.AddWithValue("@DepartmetUnitPossitionsId", taskAllocation.DepartmetUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@TaskYearMonth", taskAllocation.TaskYearMonth);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", taskAllocation.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", taskAllocation.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", taskAllocation.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", taskAllocation.RecommendedBy);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", taskAllocation.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", taskAllocation.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", taskAllocation.ApprovedDate);

            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateTaskAllocation(TaskAllocation taskAllocation, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE TASK_ALLOCATION SET DEPARTMENT_UNIT_POSSITIONS_ID = @DepartmetUnitPossitionsId, TASK_YEAR_MONT = @TaskYearMonth " +
                                           ", CREATED_DATE = @CreatedDate, CREATED_USER = @CreatedUser, STATUS_ID = @StatusId, RECOMMENDED_BY = @RecommendedBy, " +
                                           "RECOMMENDED_DATE = @RecommendedDate, APPROVED_BY = @ApprovedBy, APPROVED_DATE = @ApprovedDate  WHERE ID = @TaskAllocationId ";

            dbConnection.cmd.Parameters.AddWithValue("@id", taskAllocation.TaskAllocationId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmetUnitPossitionsId", taskAllocation.DepartmetUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@TaskYearMonth", taskAllocation.TaskYearMonth);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", taskAllocation.CreatedDate);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedUser", taskAllocation.CreatedUser);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", taskAllocation.StatusId);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedBy", taskAllocation.RecommendedBy);
            dbConnection.cmd.Parameters.AddWithValue("@RecommendedDate", taskAllocation.RecommendedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", taskAllocation.ApprovedBy);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedDate", taskAllocation.ApprovedDate);

            return dbConnection.cmd.ExecuteNonQuery();
        }


        public int UpdateTaskAllocation(int id, int status, string officer, string remarks , DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE TASK_ALLOCATION SET STATUS_ID = @StatusId, APPROVED_BY = @ApprovedBy, COMMENTS = @ApprovalComments  WHERE ID = @id ";


            dbConnection.cmd.Parameters.AddWithValue("@id", id);
            dbConnection.cmd.Parameters.AddWithValue("@StatusId", status);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovedBy", officer);
            dbConnection.cmd.Parameters.AddWithValue("@ApprovalComments", remarks);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<TaskAllocation> GetAllTaskAllocation(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION ORDER BY TASK_YEAR_MONTH ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);

        }

        public TaskAllocation GetTaskAllocation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<TaskAllocation>(dbConnection.dr);

        }


        public List<TaskAllocation> GetAllTaskAllocationByDepartmentUnitPositionId(int departmentUnitPositionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM TASK_ALLOCATION WHERE DEPARTMENT_UNIT_POSSITIONS_ID = " + departmentUnitPositionId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<TaskAllocation>(dbConnection.dr);

        }

        public int DeleteTaskAllocation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "DELETE FROM TASK_ALLOCATION WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return 1;

        }

    }
}
