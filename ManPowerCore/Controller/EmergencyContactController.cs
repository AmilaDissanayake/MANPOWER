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
    public interface EmergencyContactController
    {
        int SaveEmergencyContact(EmergencyContact emergencyContact);
    }

    public class EmergencyContactControllerImpl : EmergencyContactController
    {
        DBConnection dBConnection;
        EmergencyContactDAO eContact = DAOFactory.CreateEmergencyContactDAO();


        public int SaveEmergencyContact(EmergencyContact emergencyContact)
        {

            try
            {
                dBConnection = new DBConnection();
                eContact.SaveEmergencyContact(emergencyContact, dBConnection);
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
    }
}

