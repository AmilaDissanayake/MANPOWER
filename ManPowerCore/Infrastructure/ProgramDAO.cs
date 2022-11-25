using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramDAO
    {

        List<Program> GetAllProgram(DBConnection dbConnection);

        Program GetProgram(int id, DBConnection dbConnection);

        int SaveProgram(Program program, DBConnection dbConnection);

        int UpdateProgram(Program program, DBConnection dbConnection);

    }

    public class ProgramDAOImpl : ProgramDAO
    {

        public int getMaxProgramId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM";
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

        public int SaveProgram(Program program, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM(ID,NAME,IS_ACTIVE) " +

                                           "VALUES(@id,@ProgramName,@IsActive)";


                               
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramName", program.ProgramName);
                                dbConnection.cmd.Parameters.AddWithValue("@IsActive", program.IsActive);


            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgram(Program program, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM SET NAME = @ProgramName, IS_ACTIVE = @IsActive  WHERE ID = @ProgramId ";


            dbConnection.cmd.Parameters.AddWithValue("@ProgramId", program.ProgramId);
            dbConnection.cmd.Parameters.AddWithValue("@ProgramName", program.ProgramName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", program.IsActive);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<Program> GetAllProgram(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Program>(dbConnection.dr);
        }

        public Program GetProgram(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Program>(dbConnection.dr);

        }
    }

}
