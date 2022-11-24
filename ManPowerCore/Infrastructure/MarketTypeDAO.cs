using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface MarketTypeDAO
    {
        List<MarketType> GetAllMarketType(DBConnection dbConnection);
    }

    public class MarketTypeDAOImpl : MarketTypeDAO
    {
        public List<MarketType> GetAllMarketType(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM MARKET_TYPE";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<MarketType>(dbConnection.dr);

        }
    }
}
