using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EntrepreneurDAO
    {
        int SaveEntrepreneur(Entrepreneur entrepreneur, DBConnection dbConnection);

        List<Entrepreneur> GetAllEntrepreneur(DBConnection dbConnection);

        List<Entrepreneur> GetAllEntrepreneurFilter(string runBrn, DBConnection dbConnection);
    }

    public class EntrepreneurDAOImpl : EntrepreneurDAO
    {

        public int SaveEntrepreneur(Entrepreneur entrepreneur, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(BENEFICIARY_TYPE_ID,DISTRICT,DIVISIONAL_SECRETERY) " +
                                           "VALUES(@BeneficiaryTypeId,@District,@DivisionalSecretery) SELECT SCOPE_IDENTITY() ";

            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryTypeId", 1);
            dbConnection.cmd.Parameters.AddWithValue("@District", entrepreneur.District);
            dbConnection.cmd.Parameters.AddWithValue("@DivisionalSecretery", entrepreneur.DivisionalSecretery);


            entrepreneur.BeneficiaryId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());

            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "INSERT INTO ENTREPRENEUR(BENEFICIARY_ID,MARKET_TYPE_ID, BUSINESS_TYPE_ID, NATURE_OF_BUSINESS, BUSINESS_START_DATE, AVG_MONTHLY_INCOME, NUMBER_OF_WORKERS, CONTACT_NUMBER, BRN, EMAIL) " +

                                           "VALUES(@BenificiaryId, @MarketTypeId, @BusinessTypeId, @NatureOfBusiness, @BusinessStartDate, @AvgMonthlyIncome, @NumberOfWorkers, @ContactNumber, @Brn, @Email )";


            dbConnection.cmd.Parameters.AddWithValue("@BenificiaryId", entrepreneur.BeneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@MarketTypeId", entrepreneur.MarketTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@BusinessTypeId", entrepreneur.BusinessTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@NatureOfBusiness", entrepreneur.NatureOfBusiness);
            dbConnection.cmd.Parameters.AddWithValue("@BusinessStartDate", entrepreneur.BusinessStartDate);
            dbConnection.cmd.Parameters.AddWithValue("@AvgMonthlyIncome", entrepreneur.AvgMonthlyIncome);
            dbConnection.cmd.Parameters.AddWithValue("@NumberOfWorkers", entrepreneur.NumberOfWorkers);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", entrepreneur.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Brn", entrepreneur.Brn);
            dbConnection.cmd.Parameters.AddWithValue("@Email", entrepreneur.Email);

            dbConnection.cmd.ExecuteNonQuery();


            return 1;
        }

        public List<Entrepreneur> GetAllEntrepreneur(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM ENTREPRENEUR";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Entrepreneur>(dbConnection.dr);

        }

        public List<Entrepreneur> GetAllEntrepreneurFilter(string runBrn, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM ENTREPRENEUR WHERE BRN  = '" + runBrn + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Entrepreneur>(dbConnection.dr);

        }
    }
}

