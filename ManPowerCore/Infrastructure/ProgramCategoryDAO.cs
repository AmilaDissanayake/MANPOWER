using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramCategoryDAO
    {

        List<ProgramCategory> GetAllProgramCategory(DBConnection dbConnection);

        ProgramCategory GetProgramCategory(int id, DBConnection dbConnection);

        int SaveProgramCategory(ProgramCategory programCategory, DBConnection dbConnection);

        int UpdateProgramCategory(ProgramCategory programCategory, DBConnection dbConnection);

    }

    public class ProgramCategoryDAOImpl : ProgramCategoryDAO
    {

        public int getMaxProgramCategoryId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM PROGRAM_CATEGORY";
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

        public int SaveProgramCategory(ProgramCategory programCategory, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramCategoryId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_CATEGORY(ID,NAME,IS_ACTIVE) " +

                                            "VALUES(@id,@ProgramCategoryNamem,@IsActive)";



                                
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryName", programCategory.ProgramCategoryName);
                                dbConnection.cmd.Parameters.AddWithValue("@IsActive", programCategory.IsActive);
                               

            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramCategory(ProgramCategory programCategory, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_CATEGORY SET NAME = @ProgramCategoryName, IS_ACTIVE = @IsActive  WHERE ID = @ProgramCategoryId ";



                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryId", programCategory.ProgramCategoryId);
                                    dbConnection.cmd.Parameters.AddWithValue("@ProgramCategoryName", programCategory.ProgramCategoryName);
                                    dbConnection.cmd.Parameters.AddWithValue("@IsActive", programCategory.IsActive);



            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramCategory> GetAllProgramCategory(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_CATEGORY ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramCategory>(dbConnection.dr);

        }

        public ProgramCategory GetProgramCategory(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_CATEGORY WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramCategory>(dbConnection.dr);

        }

    }
}
