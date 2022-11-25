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
    public interface MarketTypeController
    {
        List<MarketType> GetAllMarketType();
    }

    public class MarketTypeControllerImpl : MarketTypeController 
    {
        DBConnection dBConnection;
        MarketTypeDAO marketTypeDAO = DAOFactory.CreateMarketTypeDAO();

        public List<MarketType> GetAllMarketType()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                MarketTypeDAO DAO = DAOFactory.CreateMarketTypeDAO();
                return DAO.GetAllMarketType(dbConnection);
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
