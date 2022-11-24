using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface BusinessTypeDAO
    {
        List<BusinessType> GetAllBusinessType(DBConnection dbConnection);
    }

    public class BusinessTypeDAOImpl : BusinessTypeDAO
    {
        public List<BusinessType> GetAllBusinessType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM BUSINESS_TYPE";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<BusinessType>(dbConnection.dr);

        }
    }
}
