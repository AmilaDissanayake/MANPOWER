using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ProgramBudgetDAO
    {

        List<ProgramBudget> GetAllProgramBudget(DBConnection dbConnection);

        List<ProgramBudget> GetAllProgramBudgetByProgramPlanId(int ProgramBudgetId, DBConnection dbConnection);

        ProgramBudget GetProgramBudget(int id, DBConnection dbConnection);

        int SaveProgramBudget(ProgramBudget programBudget, DBConnection dbConnection);

        int UpdateProgramBudget(ProgramBudget programBudget, DBConnection dbConnection);
    }

    public class ProgramBudgetDAOImpl : ProgramBudgetDAO 
    {

        public int getMaxProgramBudgetId(DBConnection dbConnection)
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

        public int SaveProgramBudget(ProgramBudget programBudget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxProgramBudgetId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROGRAM_BUDGET(ID,PROGRAM_PLAN_ID,DESCRIPTION,ESTIMATED_AMOUNT,APPROVED_AMOUNT,ACTUAL_AMOUNT" +

                                            "VALUES(@id,@ProgramPlanId,@Description,@EstimatedAmount,@ApprovedAmoun,@ActualAmount) ";



                               
                                dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programBudget.ProgramPlanId);
                                dbConnection.cmd.Parameters.AddWithValue("@Description", programBudget.Description);
                                dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programBudget.EstimatedAmount);
                                dbConnection.cmd.Parameters.AddWithValue("@ApprovedAmount", programBudget.ApprovedAmount);
                                dbConnection.cmd.Parameters.AddWithValue("@ActualAmount", programBudget.ActualAmount);
                               

            dbConnection.cmd.ExecuteNonQuery();


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateProgramBudget(ProgramBudget programBudget, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROGRAM_BUDGET SET PROGRAM_PLAN_ID = @ProgramPlanId," +
                " DESCRIPTION = @Description, ESTIMATED_AMOUNT = @EstimatedAmount," +
                " APPROVED_AMOUNT = @ApprovedAmount, ACTUAL_AMOUNT = @ActualAmount' WHERE ID = @ProgramBudgetId ";



                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramBudgetId", programBudget.ProgramBudgetId);
                                            dbConnection.cmd.Parameters.AddWithValue("@ProgramPlanId", programBudget.ProgramPlanId);
                                            dbConnection.cmd.Parameters.AddWithValue("@Description", programBudget.Description);
                                            dbConnection.cmd.Parameters.AddWithValue("@EstimatedAmount", programBudget.EstimatedAmount);
                                            dbConnection.cmd.Parameters.AddWithValue("@ApprovedAmount", programBudget.ApprovedAmount);
                                            dbConnection.cmd.Parameters.AddWithValue("@ActualAmount", programBudget.ActualAmount);


            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProgramBudget> GetAllProgramBudget(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_BUDGET ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramBudget>(dbConnection.dr);

        }

        public ProgramBudget GetProgramBudget(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_BUDGET WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProgramBudget>(dbConnection.dr);

        }

        public List<ProgramBudget> GetAllProgramBudgetByProgramPlanId(int ProgramPlanId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROGRAM_BUDGET WHERE PROGRAM_PLAN_ID = " + ProgramPlanId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProgramBudget>(dbConnection.dr);

        }
    }  
}
