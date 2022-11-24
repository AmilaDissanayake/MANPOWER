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
    public interface ReligionController
    {
        List<Religion> GetAllReligion();
    }

    public class ReligionControllerImpl : ReligionController
    {
        DBConnection dBConnection;
        ReligionDAO religionDAO = DAOFactory.CreateReligionDAO();

        public List<Religion> GetAllReligion()
        {
            try
            {
                dBConnection = new DBConnection();
                List<Religion> list = religionDAO.GetAllReligion(dBConnection);

                return list;
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
