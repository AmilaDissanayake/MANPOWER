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
    public interface DependantController
    {
        int SaveDependant(Dependant dependant);
    }

    public class DependantControllerImpl : DependantController
    {
        DBConnection dBConnection;
        DependentDAO aa = DAOFactory.CreateDependentDAO();


        public int SaveDependant(Dependant dependant)
        {

            try
            {
                dBConnection = new DBConnection();
                aa.SaveDependant(dependant, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}

