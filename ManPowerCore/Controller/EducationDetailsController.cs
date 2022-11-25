using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Controller
{
    public interface EducationDetailsController
    {
        int SaveEducationDetails(EducationDetails educationDetails);
    }

    public class EducationDetailsControllerImpl : EducationDetailsController
    {
        DBConnection dBConnection;
        EducationDetailsDAO eDetails = DAOFactory.CreateEducationDetailsDAO();


        public int SaveEducationDetails(EducationDetails educationDetails)
        {

            try
            {
                dBConnection = new DBConnection();
                eDetails.SaveEducationDetails(educationDetails, dBConnection);
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
