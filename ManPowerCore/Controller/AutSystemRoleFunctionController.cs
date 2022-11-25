using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Controller
{
    public interface AutSystemRoleFunctionController
    {
        List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId);
    }

    public class AutSystemRoleFunctionControllerImpl : AutSystemRoleFunctionController
    {
        public List<AutSystemRoleFunction> GetAllAutSystemRoleFunctionById(int UserTypeId)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                AutSystemRoleFunctionDAO DAO = DAOFactory.CreateAutSystemRoleFunctionDAO();
                return DAO.GetAllAutSystemRoleFunctionById(UserTypeId, dbConnection);
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                throw;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}
