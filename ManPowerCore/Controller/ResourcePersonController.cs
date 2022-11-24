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
    public interface ResourcePersonController
    {
        int SaveResourcePerson(ResourcePerson resourcePerson);

        List<ResourcePerson> GetAllResourcePerson();
    }

    public class ResourcePersonControllerImpl : ResourcePersonController
    {
        DBConnection dBConnection;
        ResourcePersonDAO resourcePersonDAO = DAOFactory.CreateResourcePersonDAO();
        public int SaveResourcePerson(ResourcePerson resourcePerson)
        {
            try
            {
                dBConnection = new DBConnection();
                int result = resourcePersonDAO.SaveResourcePerson(resourcePerson, dBConnection);
                return result;
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

        public List<ResourcePerson> GetAllResourcePerson()
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ResourcePersonDAO DAO = DAOFactory.CreateResourcePersonDAO();
                return DAO.GetAllResourcePerson(dbConnection);
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
