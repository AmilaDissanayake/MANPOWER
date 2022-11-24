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
    public interface EmployeeContactController
    {
        int SaveEmployeeContact(EmployeeContact empContact);

        int UpdateEmployeeContact(EmployeeContact empContact);

        List<EmployeeContact> GetAllEmployeeContact();

        EmployeeContact GetEmployeeContact(int id);
    }

    public class EmployeeContactControllerImpl : EmployeeContactController
    {

        DBConnection dBConnection;
        EmployeeContactDAO employeeContact = DAOFactory.CreateEmployeeContactDAO();


        public int SaveEmployeeContact(EmployeeContact empContact)
        {

            try
            {
                dBConnection = new DBConnection();
                employeeContact.SaveEmployeeContact(empContact, dBConnection);
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

        public int UpdateEmployeeContact(EmployeeContact empContact)
        {


            try
            {
                dBConnection = new DBConnection();
                employeeContact.UpdateEmployeeContact(empContact, dBConnection);
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


        public List<EmployeeContact> GetAllEmployeeContact()
        {
            DBConnection dBConnection = new DBConnection();

            try
            {
                EmployeeContactDAO DAO = DAOFactory.CreateEmployeeContactDAO();
                List<EmployeeContact> list = DAO.GetAllEmployeeContact(dBConnection);
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

        public EmployeeContact GetEmployeeContact(int id)
        {
            DBConnection dbConnection = new DBConnection();
            try
            {
                EmployeeContactDAO DAO = DAOFactory.CreateEmployeeContactDAO();
                EmployeeContact emp = DAO.GetEmployeeContactById(id, dbConnection);

                return emp;
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

