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
    public interface EthnicityController
    {
        List<Ethnicity> GetAllEthnicity();
    }

    public class EthnicityControllerImpl : EthnicityController
    {
        DBConnection dBConnection;
        EthnicityDAO aa = DAOFactory.CreateEthnicityDAO();

        public List<Ethnicity> GetAllEthnicity()

        {
            try
            {
                dBConnection = new DBConnection();
                List<Ethnicity> list = aa.GetAllEthnicity(dBConnection);

                return list;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return null;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }

        }
    }
}

