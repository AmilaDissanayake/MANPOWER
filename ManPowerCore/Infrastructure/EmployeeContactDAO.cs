using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface EmployeeContactDAO
    {
        List<EmployeeContact> GetAllEmployeeContact(DBConnection dbConnection);

        EmployeeContact GetEmployeeContactById(int id, DBConnection dbConnection);

        int SaveEmployeeContact(EmployeeContact empContact, DBConnection dbConnection);

        int UpdateEmployeeContact(EmployeeContact empContact, DBConnection dbConnection);
    }

    public class EmployeeContactDAOImpl : EmployeeContactDAO
    {

        public int SaveEmployeeContact(EmployeeContact empContact, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO EMPLOYEE_CONTACT(CONTACT_MODE_ID,EMPLOYEE_ID,CONTACT_DETAIL) VALUES(@ContactModeId,@EmpID,@ContactDetials)";



            dbConnection.cmd.Parameters.AddWithValue("@ContactModeId", empContact.ContactModeId);
            dbConnection.cmd.Parameters.AddWithValue("@EmpID", empContact.EmpID);
            dbConnection.cmd.Parameters.AddWithValue("@ContactDetials", empContact.ContactDetials);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public int UpdateEmployeeContact(EmployeeContact empContact, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE EMPLOYEE_CONTACT SET CONTACT_MODE+ID = @ContactModeID, EMPLOYEE_ID = @EmpID CONTACT_DETAIL = @ContactDetials, WHERE ID = @EmployeeContactId ";

            dbConnection.cmd.Parameters.AddWithValue("@EmployeeContactId", empContact.EmployeeContactId);
            dbConnection.cmd.Parameters.AddWithValue("@ContactModeId", empContact.ContactModeId);
            dbConnection.cmd.Parameters.AddWithValue("@EmpID", empContact.EmpID);
            dbConnection.cmd.Parameters.AddWithValue("@ContactDetials", empContact.ContactDetials);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public List<EmployeeContact> GetAllEmployeeContact(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<EmployeeContact>(dbConnection.dr);

        }

        public EmployeeContact GetEmployeeContactById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM EMPLOYEE_CONTACT WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<EmployeeContact>(dbConnection.dr);

        }
    }
}

