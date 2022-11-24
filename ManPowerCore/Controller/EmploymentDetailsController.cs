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
    public interface EmploymentDetailsController
    {
        int SaveEmploymentDetails(EmploymentDetails empDetails);

        int UpdateEmploymentDetails(EmploymentDetails empDetails);

        List<EmploymentDetails> GetAllEmploymentDetails();

        EmploymentDetails GetEmploymentDetails(int id);
    }

    public class EmploymentDetailsControllerImpl : EmploymentDetailsController
    {
        DBConnection dBConnection;
        EmploymentDetailsDAO empDetailsDAO = DAOFactory.CreateEmploymentDetailsDAO();


        public int SaveEmploymentDetails(EmploymentDetails empDetails)
        {

            try
            {
                dBConnection = new DBConnection();
                empDetailsDAO.SaveEmploymentDetails(empDetails, dBConnection);
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

        public int UpdateEmploymentDetails(EmploymentDetails empDetails)
        {


            try
            {
                dBConnection = new DBConnection();
                empDetailsDAO.UpdateEmploymentDetails(empDetails, dBConnection);
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


        public List<EmploymentDetails> GetAllEmploymentDetails()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                EmploymentDetailsDAO DAO = DAOFactory.CreateEmploymentDetailsDAO();
                List<EmploymentDetails> list = DAO.GetAllEmploymentDetails(dBConnection);
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

        public EmploymentDetails GetEmploymentDetails(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                EmploymentDetailsDAO DAO = DAOFactory.CreateEmploymentDetailsDAO();
                EmploymentDetails list = DAO.GetEmploymentDetailsById(id,dBConnection);
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

