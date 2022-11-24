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
    public interface EmployeeController
    {
        int SaveEmployee(Employee emp);
    }

    public class EmployeeControllerImpl : EmployeeController
    {
        DBConnection dBConnection;

        EmployeeDAO employeeDAO = DAOFactory.CreateEmployeeDAO();
        EmployeeContactDAO employeeContactDAO = DAOFactory.CreateEmployeeContactDAO();
        EmploymentDetailsDAO employmentDetailsDAO = DAOFactory.CreateEmploymentDetailsDAO();
        DependentDAO dependentDAO = DAOFactory.CreateDependentDAO();
        EducationDetailsDAO educationDetailsDAO = DAOFactory.CreateEducationDetailsDAO();
        EmergencyContactDAO emergencyContactDAO = DAOFactory.CreateEmergencyContactDAO();

        public int SaveEmployee(Employee emp)
        {
            int id = 0;

            try
            {
                dBConnection = new DBConnection();
                id = employeeDAO.SaveEmployee(emp, dBConnection);

                if (emp._EmployeeContact.Count > 0)
                {
                    foreach (var item in emp._EmployeeContact)
                    {
                        item.EmpID = id;
                        employeeContactDAO.SaveEmployeeContact(item, dBConnection);
                    }
                }

                if (emp._EmploymentDetails.Count > 0)
                {
                    foreach (var item in emp._EmploymentDetails)
                    {
                        item.EmpID = id;
                        employmentDetailsDAO.SaveEmploymentDetails(item, dBConnection);
                    }
                }

                if (emp._Dependant.Count > 0)
                {
                    foreach (var item in emp._Dependant)
                    {
                        item.EmpId = id;
                        dependentDAO.SaveDependant(item, dBConnection);
                    }
                }

                if (emp._EducationDetails.Count > 0)
                {
                    foreach (var item in emp._EducationDetails)
                    {
                        item.EmployeeId = id;
                        educationDetailsDAO.SaveEducationDetails(item, dBConnection);
                    }
                }

                emp._EmergencyContact.EmployeeId = id;
                emergencyContactDAO.SaveEmergencyContact(emp._EmergencyContact, dBConnection);

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

