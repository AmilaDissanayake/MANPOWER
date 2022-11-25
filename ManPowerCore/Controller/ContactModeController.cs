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
    public interface ContactModeController
    {
        int SaveContactMode(ContactMode contactMode);

        int UpdateContactMode(ContactMode contactMode);

        List<ContactMode> GetAllContactMode();

        ContactMode GetContactMode(int id);
    }

    public class ContactModeControllerImpl : ContactModeController
    {
        DBConnection dBConnection;
        ContactModeDAO contactModeDAO = DAOFactory.CreateContactModeDAO();


        public int SaveContactMode(ContactMode contactMode)
        {

            try
            {
                dBConnection = new DBConnection();
                contactModeDAO.SaveContactMode(contactMode, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public int UpdateContactMode(ContactMode contactMode)
        {


            try
            {
                dBConnection = new DBConnection();
                contactModeDAO.UpdateContactMode(contactMode, dBConnection);
                return 1;
            }
            catch (Exception)
            {
                dBConnection.RollBack();
                return 0;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }


        public List<ContactMode> GetAllContactMode()
        {
            try
            {
                DBConnection dBConnection = new DBConnection();
                ContactModeDAO DAO = DAOFactory.CreateContactModeDAO();
                List<ContactMode> contacts = DAO.GetAllContactMode(dBConnection);
                return contacts;
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

        public ContactMode GetContactMode(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                ContactModeDAO DAO = DAOFactory.CreateContactModeDAO();
                ContactMode contacts = DAO.GetContactModeById(id,dBConnection);
                return contacts;
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

