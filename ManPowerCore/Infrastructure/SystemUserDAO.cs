using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface SystemUserDAO
    {
        int SaveSystemUser(SystemUser systemuser, DBConnection dbConnection);
        int UpdateSystemUser(SystemUser systemuser, DBConnection dbConnection);
        List<SystemUser> GetAllSystemUser(DBConnection dbConnection);
        SystemUser GetSystemUser(int id, DBConnection dbConnection);
        List<SystemUser> GetAllSystemUserByUserTypeId(int userTypeId, DBConnection dbConnection);
        List<SystemUser> GetAllSystemUserByDesignationId(int designationId, DBConnection dbConnection);

        List<SystemUser> SystemUserLogin(string runUserName, DBConnection dbConnection);
        List<SystemUser> SystemUserValider(string runUserName, string runEmail, int runContactNumber, int runEmpNumber, DBConnection dbConnection);
        int UpdateCountInvaliedAttempts(SystemUser systemuser, DBConnection dbConnection);
        List<SystemUser> CheckSystemUserLoginPassword(string runUserName, string runPassword, DBConnection dbConnection);
        List<SystemUser> CheckInvaliedLogingCount(string runUserName, DBConnection dbConnection);
        int ResetInvaliedAttempts(SystemUser systemuser, DBConnection dbConnection);
        int UpdateLastLoginDate(SystemUser systemuser, DBConnection dbConnection);
    }

    public class SystemUserDAOImpl : SystemUserDAO
    {
        public int getMaxSystemUserId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM COMPANY_USER";
            int SystemUser = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (SystemUser == 0)
            {
                SystemUser = 1;
            }
            else
            {
                SystemUser += 1;
            }


            return SystemUser;
        }

        public int SaveSystemUser(SystemUser systemuser, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxSystemUserId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO COMPANY_USER( DESIGNATION_ID, USER_TYPE_ID, EMP_NUMBER, NAME, EMAIL," +
                " CONTACT_NUMBER, USER_NAME, USER_PWD,CREATED_DATE) values (@DesignationId,@UserTypeId,@EmpNumber,@Name,@Email,@ContactNumber," +
                "@UserName,@UserPwd,@CreatedDate) SELECT SCOPE_IDENTITY() ";


            dbConnection.cmd.Parameters.AddWithValue("@DesignationId", systemuser.DesignationId);
            dbConnection.cmd.Parameters.AddWithValue("@UserTypeId", systemuser.UserTypeId);
            dbConnection.cmd.Parameters.AddWithValue("@EmpNumber", systemuser.EmpNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Name", systemuser.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Email", systemuser.Email);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", systemuser.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@UserName", systemuser.UserName);
            dbConnection.cmd.Parameters.AddWithValue("@UserPwd", systemuser.UserPwd);
            //dbConnection.cmd.Parameters.AddWithValue("RESET_CODE", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("VALIDITY_PERIOD", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("RESET_CODE_VALIDITY_PERIOD", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("INVALIDE_LOGIN_COUNT", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("LAST_LOGIN_DATE", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("IS_ACTIVE", DBNull.Value);
            //dbConnection.cmd.Parameters.AddWithValue("CREATED_USER", DBNull.Value);
            dbConnection.cmd.Parameters.AddWithValue("@CreatedDate", systemuser.CreatedDate);

            // dbConnection.cmd.CommandType = System.Data.CommandType.Text;



            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public int UpdateSystemUser(SystemUser systemuser, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE COMPANY_USER SET DESIGNATION_ID = '" + systemuser.DesignationId + "', USER_TYPE_ID = '" + systemuser.UserTypeId + "', EMP_NUMBER = '" + systemuser.EmpNumber + "', NAME = '" + systemuser.Name + "', EMAIL = '" + systemuser.Email + "', CONTACT_NUMBER = '" + systemuser.ContactNumber + "', USER_NAME = '" + systemuser.UserName + "', USER_PWD = '" + systemuser.UserPwd + "', RESET_CODE = '" + systemuser.ResetCode + "', VALIDITY_PERIOD = '" + systemuser.ValidityPeriod + "', RESET_CODE_VALIDITY_PERIOD = '" + systemuser.ResetCodeValidityPeriod + "', INVALIDE_LOGIN_COUNT = '" + systemuser.InvalideLoginCount + "', LAST_LOGIN_DATE = '" + systemuser.LastLoginDate + "', IS_ACTIVE = '" + systemuser.IsActive + "', CREATED_USER = '" + systemuser.CreatedUser + "', CREATED_DATE = '" + systemuser.CreatedDate + "' WHERE ID = " + systemuser.SystemUserId;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<SystemUser> GetAllSystemUser(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);

        }

        public SystemUser GetSystemUser(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<SystemUser>(dbConnection.dr);
        }

        public List<SystemUser> GetAllSystemUserByUserTypeId(int userTypeId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE USER_TYPE_ID = " + userTypeId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);
        }

        public List<SystemUser> GetAllSystemUserByDesignationId(int designationId, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE DESIGNATION_ID = " + designationId + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);
        }

        public List<SystemUser> SystemUserLogin(string runUserName, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE USER_NAME = '" + runUserName + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);

        }

        public List<SystemUser> CheckSystemUserLoginPassword(string runUserName, string runPassword, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE USER_NAME = '" + runUserName + "' AND USER_PWD = '" + runPassword + "'";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);

        }

        public List<SystemUser> CheckInvaliedLogingCount(string runUserName, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM COMPANY_USER WHERE USER_NAME = '" + runUserName + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);

        }

        public List<SystemUser> SystemUserValider(string runUserName, string runEmail, int runContactNumber, int runEmpNumber, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT *  FROM COMPANY_USER WHERE USER_NAME = '" + runUserName + "' OR EMAIL = '" + runEmail + "' OR CONTACT_NUMBER = '" + runContactNumber + "' OR EMP_NUMBER = '" + runEmpNumber + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<SystemUser>(dbConnection.dr);

        }

        public int UpdateCountInvaliedAttempts(SystemUser systemuser, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE COMPANY_USER SET INVALIDE_LOGIN_COUNT = " + systemuser.InvalideLoginCount + " WHERE USER_NAME = '" + systemuser.UserName + "' ";

            return dbConnection.cmd.ExecuteNonQuery();

        }

        public int ResetInvaliedAttempts(SystemUser systemuser, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE COMPANY_USER SET INVALIDE_LOGIN_COUNT = " + systemuser.InvalideLoginCount + " WHERE USER_NAME = '" + systemuser.UserName + "' ";
            return dbConnection.cmd.ExecuteNonQuery();

        }

        public int UpdateLastLoginDate(SystemUser systemuser, DBConnection dbConnection)
        {

            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE COMPANY_USER SET LAST_LOGIN_DATE = GETDATE() WHERE USER_NAME = '" + systemuser.UserName + "' ";
            return dbConnection.cmd.ExecuteNonQuery();

        }

    }
}
