using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface AutSystemRoleFunctionDAO
    {
        List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId, DBConnection dbConnection);
    }

    public class AutSystemRoleFunctionDAOImpl : AutSystemRoleFunctionDAO
    {
        public List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId, DBConnection dbConnection)
        {
            dbConnection.cmd.Parameters.Clear();
            dbConnection.cmd.CommandText = "SELECT * FROM AUT_SYSTEM_ROLE_FUNCTION where USER_Type_ID = " + UserTypeId + " and AUT_SYSTEM_ID = 1 ";
            dbConnection.cmd.CommandType = System.Data.CommandType.Text;

            using (dbConnection.dr = dbConnection.cmd.ExecuteReader())
            {
                DataAccessObject dataAccessObject = new DataAccessObject();
                return dataAccessObject.ReadCollection<AutSystemRoleFunction>(dbConnection.dr);
            }
        }
    }
}
