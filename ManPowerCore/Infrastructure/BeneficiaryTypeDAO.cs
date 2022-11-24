using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface BeneficiaryTypeDAO
    {
        int SaveBeneficiaryType(BeneficiaryType beneficiaryType, DBConnection dbConnection);

        List<BeneficiaryType> GetAllBeneficiaryType(DBConnection dbConnection);
    }

    public class BeneficiaryTypeDAOImpl : BeneficiaryTypeDAO
    {
        public int getMaxBeneficiaryTypeId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM BENEFICIARY_TYPE";
            int BeneficiaryTypeId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (BeneficiaryTypeId == 0)
            {
                BeneficiaryTypeId = 1;
            }
            else
            {
                BeneficiaryTypeId += 1;
            }


            return BeneficiaryTypeId;
        }

        public int SaveBeneficiaryType(BeneficiaryType beneficiaryType, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int BeneficiaryType = getMaxBeneficiaryTypeId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO BENEFICIARY_TYPE(ID,NAME,IS_ACTIVE) " +

                                           "VALUES(@BeneficiaryTypeId,@BeneficiaryTypeName,@IsActive)";


            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryId", BeneficiaryType);
            dbConnection.cmd.Parameters.AddWithValue("@BeneficiaryTypeName", beneficiaryType.BeneficiaryTypeName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", beneficiaryType.IsActive);


            dbConnection.cmd.ExecuteNonQuery();


            return 1;
        }

        public List<BeneficiaryType> GetAllBeneficiaryType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM BENEFICIARY_TYPE";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<BeneficiaryType>(dbConnection.dr);

        }
    }
}
