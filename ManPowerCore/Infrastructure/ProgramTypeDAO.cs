using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramTypeDAO
    {
        List<ProgramType> GetAllProgramType(DBConnection dbConnection);

        ProgramType GetProgramType(int id, DBConnection dbConnection);

        int SaveProgramType(ProgramType programType, DBConnection dbConnection);

        int UpdateProgramType(ProgramType programType, DBConnection dbConnection);
    }

    public class ProgramTypeDAOImpl : ProgramTypeDAO 
    {

        public int getMaxProgramTypeId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_TYPE";
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

        public int SaveProgramType(ProgramType programType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramTypeId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_TYPE(ID,NAME,IS_ACTIVE) VALUES(@id,@ProgramTypeName,@IsActive)";


                                
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeName", programType.ProgramTypeName);
                                dbConnection.cmd.Parameters.AddWithValue("@IsActive", programType.IsActive);


            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramType(ProgramType programType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_TYPE SET NAME = @ProgramTypeName, IS_ACTIVE = @IsActive WHERE ID = @ProgramTypeId ";


                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeId", programType.ProgramTypeId);
                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramTypeName", programType.ProgramTypeName);
                                            dbConnection.cmd.Parameters.AddWithValue("@IsActive", programType.IsActive);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramType> GetAllProgramType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TYPE ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramType>(dbConnection.dr);

        }

        public ProgramType GetProgramType(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramType>(dbConnection.dr);

        }
    }
}
