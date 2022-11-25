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
    public interface BusinessTypeController
    {
        List<BusinessType> GetAllBusinessType();
    }

    public class BusinessTypeControllerImpl : BusinessTypeController
    {
        DBConnection dBConnection;
        BusinessTypeDAO businessTypeDAO = DAOFactory.CreateBusinessTypeDAO();

        public List<BusinessType> GetAllBusinessType()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                BusinessTypeDAO DAO = DAOFactory.CreateBusinessTypeDAO();
                return DAO.GetAllBusinessType(dbConnection);
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
