using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface UserTypeDAO
    {
        List<UserType> GetAllUserType(DBConnection dbConnection);
        UserType GetUserType(int id, DBConnection dbConnection);
    }

    public class UserTypeDAOImpl : UserTypeDAO
    {
        public List<UserType> GetAllUserType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM USER_TYPE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<UserType>(dbConnection.dr);

        }

        public UserType GetUserType(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM USER_TYPE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<UserType>(dbConnection.dr);

        }
    }
}
