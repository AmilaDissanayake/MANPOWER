using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface ContactTypeController
    {
        List<ContactType> GetAllContactType();

        ContactType GetContactType(int id);
    }

    public class ContactTypeControllerImpl : ContactTypeController
    {
        public List<ContactType> GetAllContactType()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                ContactTypeDAO DAO = DAOFactory.CreateContactTypeDAO();
                List<ContactType> list = DAO.GetAllContactType(dBConnection);
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

        public ContactType GetContactType(int id)
        {
            DBConnection dbConnection = new DBConnection();

            try
            {
                ContactTypeDAO DAO = DAOFactory.CreateContactTypeDAO();
                ContactType list = DAO.GetContactTypeById(id,dbConnection);
                return list;
            }
            catch (Exception ex)
            {
                dbConnection.RollBack();
                return null;
            }
            finally
            {
                if (dbConnection.con.State == System.Data.ConnectionState.Open)
                    dbConnection.Commit();
            }
        }
    }
}
