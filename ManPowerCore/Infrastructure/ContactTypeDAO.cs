using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ContactTypeDAO
    {
        List<ContactType> GetAllContactType(DBConnection dbConnection);

        ContactType GetContactTypeById(int id, DBConnection dbConnection);
    }


    public class ContactTypeDAOImpl : ContactTypeDAO
    {
        public List<ContactType> GetAllContactType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ContactType>(dbConnection.dr);

        }

        public ContactType GetContactTypeById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CONTACT_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ContactType>(dbConnection.dr);

        }
    }
}

