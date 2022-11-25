using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DependantTypeDAO
    {
        List<DependantType> GetAllDependantType(DBConnection dbConnection);
    }

    public class DependantTypeDAOImpl : DependantTypeDAO
    {
        public List<DependantType> GetAllDependantType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Dependent_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<DependantType>(dbConnection.dr);
        }
    }
}
