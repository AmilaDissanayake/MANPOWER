using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EducationTypeDAO
    {
        List<EducationType> GetAllEducationType(DBConnection dbConnection);
    }

    public class EducationTypeDAOImpl : EducationTypeDAO
    {
        public List<EducationType> GetAllEducationType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM Education_Type";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<EducationType>(dbConnection.dr);
        }
    }
}
