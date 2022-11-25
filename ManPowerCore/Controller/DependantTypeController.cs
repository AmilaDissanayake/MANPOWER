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
    public interface DependantTypeController
    {
        List<DependantType> GetAllDependantType();
    }

    public class DependantTypeControllerImpl : DependantTypeController
    {
        DBConnection dBConnection;
        DependantTypeDAO aa = DAOFactory.CreateDependantTypeDAO();

        public List<DependantType> GetAllDependantType()

        {
            try
            {
                dBConnection = new DBConnection();
                List<DependantType> list = aa.GetAllDependantType(dBConnection);

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
