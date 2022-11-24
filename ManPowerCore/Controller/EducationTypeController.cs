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
    public interface EducationTypeController
    {
        List<EducationType> GetAllEducationType();
    }

    public class EducationTypeControllerImpl : EducationTypeController
    {
        DBConnection dBConnection;
        EducationTypeDAO aa = DAOFactory.CreateEducationTypeDAO();

        public List<EducationType> GetAllEducationType()

        {
            try
            {
                dBConnection = new DBConnection();
                List<EducationType> list = aa.GetAllEducationType(dBConnection);

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
