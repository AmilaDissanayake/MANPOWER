using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramAttendenceDAO
    {

        List<ProgramAttendence> GetAllProgramAttendence(DBConnection dbConnection);

        ProgramAttendence GetProgramAttendence(int id, DBConnection dbConnection);

        List<ProgramAttendence> GetAllProgramAttendenceByProgramPlanId(int ProgramAttendenceId, DBConnection dbConnection);

        int SaveProgramAttendence(ProgramAttendence programAttendence, DBConnection dbConnection);

        int UpdateProgramAttendence(ProgramAttendence programAttendence, DBConnection dbConnection);

        
    }

    public class ProgramAttendenceDAOImpl : ProgramAttendenceDAO
    {
        public int getMaxProgramAttendenceId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_ATTENDENCE";
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

        public int SaveProgramAttendence(ProgramAttendence programAttendence, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramAttendenceId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_ATTENDENCE(ID,PROGRAM_PLAN_ID,NAME,ADDRESS,NIC,DOB,SEX) " +
                                            "VALUES(@id,@ProgramPlanId,@ProgramAttendenceName,@Address,@NIC,@DOB,@Sex) ";



                                
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programAttendence.ProgramPlanId);
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramAttendenceName", programAttendence.ProgramAttendenceName);
                                dbConnection.cmd.Parameters.AddWithValue("@Address", programAttendence.Address);
                                dbConnection.cmd.Parameters.AddWithValue("@NIC", programAttendence.NIC);
                                dbConnection.cmd.Parameters.AddWithValue("@DOB", programAttendence.DOB);
                                dbConnection.cmd.Parameters.AddWithValue("@Sex", programAttendence.Sex);

            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramAttendence(ProgramAttendence programAttendence, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_ATTENDENCE SET PROGRAM_PLAN_ID = @ProgramPlanId, NAME = ProgramAttendenceName "+
                                           ", ADDRESS = @Address, NIC = @NIC, DOB = @DOB " +
                                           "', SEX = @Sex WHERE ID = @ProgramAttendenceId ";



                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramAttendenceId", programAttendence.ProgramAttendenceId);
                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programAttendence.ProgramPlanId);
                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramAttendenceName", programAttendence.ProgramAttendenceName);
                                            dbConnection.cmd.Parameters.AddWithValue("@Address", programAttendence.Address);
                                            dbConnection.cmd.Parameters.AddWithValue("@NIC", programAttendence.NIC);
                                            dbConnection.cmd.Parameters.AddWithValue("@DOB", programAttendence.DOB);
                                            dbConnection.cmd.Parameters.AddWithValue("@Sex", programAttendence.Sex);




            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramAttendence> GetAllProgramAttendence(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ATTENDENCE ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAttendence>(dbConnection.dr);

        }

        public ProgramAttendence GetProgramAttendence(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ATTENDENCE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramAttendence>(dbConnection.dr);

        }

        public List<ProgramAttendence> GetAllProgramAttendenceByProgramPlanId(int ProgramPlanId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_ATTENDENCE WHERE PROGRAM_PLAN_ID = " + ProgramPlanId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramAttendence>(dbConnection.dr);

        }

    }
}
