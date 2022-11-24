using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface DesignationDAO
    {
        List<Designation> GetAllDesignation(DBConnection dbConnection);
        Designation GetDesignation(int id, DBConnection dbConnection);
    }

    public class DesignationDAOImpl : DesignationDAO
    {
        public List<Designation> GetAllDesignation(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DESIGNATION ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<Designation>(dbConnection.dr);

        }

        public Designation GetDesignation(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM DESIGNATION WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<Designation>(dbConnection.dr);

        }
    }
}
