using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EthnicityDAO
    {
        List<Ethnicity> GetAllEthnicity(DBConnection dbConnection);
    }

    public class EthnicityDAOImpl : EthnicityDAO
    {
        public List<Ethnicity> GetAllEthnicity(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Ethnicity";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Ethnicity>(dbConnection.dr);
        }
    }
}
