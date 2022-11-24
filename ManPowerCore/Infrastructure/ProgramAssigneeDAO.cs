using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramAssigneeDAO
    {
        List<ProgramAssignee> GetAllProgramAssignee(DBConnection dbConnection);
        ProgramAssignee GetProgramAssignee(int id, DBConnection dbConnection);
        int SaveProgramAssignee(ProgramAssignee programAssignee, DBConnection dbConnection);
        int UpdateProgramAssignee(ProgramAssignee programAssignee, DBConnection dbConnection);
        List<ProgramAssignee> GetAllProgramAssigneeByProgramTargetId(int programTargetId, DBConnection dbConnection);
        List<ProgramAssignee> GetAllProgramAssigneeByDepartmentPossitionId(int departmentPossitionId, DBConnection dbConnection);
        List<ProgramAssignee> GetAllProgramAssigneeByDepartmentUnitPositionId(int DepartmetUnitPossitionsId, DBConnection dBConnection);
        List<ProgramAssignee> GetAllProgramAssigneeByDesignationId(int designationId, DBConnection dbConnection);
    }

    public class ProgramAssigneeDAOImpl : ProgramAssigneeDAO
    {


        public int getMaxProgramAssigneeId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_ASSIGNEE";
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

        public int SaveProgramAssignee(ProgramAssignee programAssignee, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramAssigneeId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_ASSIGNEE(DESIGNATION_ID,DEPARTMENT_UNIT_POSSITIONS_ID,PROGRAM_TARGET_ID) " +
                                           "VALUES(@DesignationId,@DepartmentUnitPossitionsId,@ProgramTargetId) ";


            dbConnection.cmd.Parameters.AddWithValue("@DesignationId", programAssignee.DesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentUnitPossitionsId", programAssignee.DepartmentUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programAssignee.ProgramTargetId);

            dbConnection.cmd.ExecuteNonQuery();

            return 1;
        }

        public int UpdateProgramAssignee(ProgramAssignee programAssignee, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_ASSIGNEE SET DESIGNATION_ID = @DesignationId," +
                                            " DEPARTMENT_UNIT_POSSITIONS_ID = @DepartmentUnitPossitionsId," +
                                            " PROGRAM_TARGET_ID = ProgramTargetId WHERE ID = @ProgramAssigneeId ";


            dbConnection.cmd.Parameters.AddWithValue("@ProgramAssigneeId", programAssignee.ProgramAssigneeId);
            dbConnection.cmd.Parameters.AddWithValue("@DesignationId", programAssignee.DesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@DepartmentUnitPossitionsId", programAssignee.DepartmentUnitPossitionsId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramTargetId", programAssignee.ProgramTargetId);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramAssignee> GetAllProgramAssignee(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE ORDER BY DESIGNATION_ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAssignee>(dbConnection.dr);

        }

        public ProgramAssignee GetProgramAssignee(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramAssignee>(dbConnection.dr);

        }

        public List<ProgramAssignee> GetAllProgramAssigneeByProgramTargetId(int programTargetId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE WHERE PROGRAM_TARGET_ID = " + programTargetId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAssignee>(dbConnection.dr);

        }

        public List<ProgramAssignee> GetAllProgramAssigneeByDepartmentUnitPositionId(int departmentPossitionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE WHERE DEPARTMENT_UNIT_POSSITIONS_ID = " + departmentPossitionId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAssignee>(dbConnection.dr);

        }

        public List<ProgramAssignee> GetAllProgramAssigneeByDepartmentPossitionId(int departmentPossitionId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE WHERE DEPARTMENT_UNIT_POSSITIONS_ID = " + departmentPossitionId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAssignee>(dbConnection.dr);
        }

        public List<ProgramAssignee> GetAllProgramAssigneeByDesignationId(int designationId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ASSIGNEE WHERE DESIGNATION_ID = " + designationId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAssignee>(dbConnection.dr);
        }
    }
}
