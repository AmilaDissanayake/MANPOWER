using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface PromotionsDAO
    {
        List<Promotions> GetAllPromotions(DBConnection dbConnection);

        Promotions GetPromotionsById(int id, DBConnection dbConnection);

        int SavePromotions(Promotions promotions, DBConnection dbConnection);

        int UpdatePromotions(Promotions promotions, DBConnection dbConnection);
    }

    public class PromotionsDAOImpl : PromotionsDAO
    {
        public int SavePromotions(Promotions promotions, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO PROMOTIONS(EMPLOYMENT_DETAIL_ID,PREVIOUS_DESIGNATION_ID,NEW_DESIGNATION_ID,"+
                "PROMOTED_DATE,PROBATION_END_DATE,CONFIRM_DATE,CONFIRM_BY)" +
                " VALUES(@EmploymentDetailId,@PreDesignationId,@NewDesignationId,@PromotedDate,@ProbationEndDate,@ConfirmDate,@ConfirmBy)";



            dbConnection.cmd.Parameters.AddWithValue("@EmploymentDetailId", promotions.EmploymentDetailId);
            dbConnection.cmd.Parameters.AddWithValue("@PreDesignationId", promotions.PreDesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@NewDesignationId", promotions.NewDesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@PromotedDate", promotions.PromotedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ProbationEndDate", promotions.ProbationEndDate);
            dbConnection.cmd.Parameters.AddWithValue("@ConfirmDate", promotions.ConfirmDate);
            dbConnection.cmd.Parameters.AddWithValue("@ConfirmBy", promotions.ConfirmBy);


            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public int UpdatePromotions(Promotions promotions, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE PROMOTIONS SET EMPLOYMENT_DETAIL_ID = @EmploymentDetailId, PREVIOUS_DESIGNATION_ID = @PreDesignationId " +
                "NEW_DESIGNATION_ID = @NewDesignationId, PROMOTED_DATE = @PromotedDate, PROBATION_END_DATE = @ProbationEndDate,CONFIRM_DATE = @ConfirmDate" +
                "CONFIRM_BY = @ConfirmBy WHERE ID = @PromotionId ";

            dbConnection.cmd.Parameters.AddWithValue("@PromotionId", promotions.PromotionId);
            dbConnection.cmd.Parameters.AddWithValue("@EmploymentDetailId", promotions.EmploymentDetailId);
            dbConnection.cmd.Parameters.AddWithValue("@PreDesignationId", promotions.PreDesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@NewDesignationId", promotions.NewDesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@PromotedDate", promotions.PromotedDate);
            dbConnection.cmd.Parameters.AddWithValue("@ProbationEndDate", promotions.ProbationEndDate);
            dbConnection.cmd.Parameters.AddWithValue("@ConfirmDate", promotions.ConfirmDate);
            dbConnection.cmd.Parameters.AddWithValue("@ConfirmBy", promotions.ConfirmBy);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public List<Promotions> GetAllPromotions(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROMOTIONS ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Promotions>(dbConnection.dr);

        }

        public Promotions GetPromotionsById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM PROMOTIONS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Promotions>(dbConnection.dr);

        }
    }
}

