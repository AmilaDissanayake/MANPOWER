using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface BeneficiaryDAO
    {
        int SaveBeneficiary(Beneficiary beneficiary, DBConnection dbConnection);

        List<Beneficiary> GetAllBeneficiary(DBConnection dbConnection);
    }

    public class BeneficiaryDAOImpl : BeneficiaryDAO
    {
        public int getMaxBeneficiaryId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM BENEFICIARY";
            int beneficiaryId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (beneficiaryId == 0)
            {
                beneficiaryId = 1;
            }
            else
            {
                beneficiaryId += 1;
            }


            return beneficiaryId;
        }

        public int SaveBeneficiary(Beneficiary beneficiary, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int beneficiaryId = getMaxBeneficiaryId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY(BENEFICIARY_TYPE_ID,DISTRICT,DIVISIONAL_SECRETERY) " +

                                           "VALUES(@BeneficiaryTypeId,@District,@DivisionalSecretery) ";


            //dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", beneficiaryId);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryTypeId", beneficiary.BeneficiaryTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@District", beneficiary.District);
            dbConnection.cmd.Parameters.AddWithValue("@DivisionalSecretery", beneficiary.DivisionalSecretery);


            dbConnection.cmd.ExecuteNonQuery();


            return 1;
        }

        public List<Beneficiary> GetAllBeneficiary(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM BENEFICIARY";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Beneficiary>(dbConnection.dr);

        }
    }
}
