using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManPowerCore.Infrastructure
{
    public interface ContactModeDAO
    {
        List<ContactMode> GetAllContactMode(DBConnection dbConnection);

        ContactMode GetContactModeById(int id, DBConnection dbConnection);

        int SaveContactMode(ContactMode contactMode, DBConnection dbConnection);

        int UpdateContactMode(ContactMode contactMode, DBConnection dbConnection);
    }

    public class ContactModeDAOImpl : ContactModeDAO
    {
        public int SaveContactMode(ContactMode contactMode, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO CONTACT_MODE(NAME,IS_ACTIVE,AIIAS) VALUES(@ContactModeName,@IsActive,@ContactAlias)";



            dbConnection.cmd.Parameters.AddWithValue("@ContactModeName", contactMode.ContactModeName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", contactMode.IsActive);
            dbConnection.cmd.Parameters.AddWithValue("@ContactAlias", contactMode.ContactAlias);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public int UpdateContactMode(ContactMode contactMode, DBConnection dbConnection)
        { 
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE CONTACT_MODE SET NAME = @ContactModeName, IS_ACTIVE = @IsActive AIIAS = @ContactAlias, WHERE ID = @ContactModeId ";

            dbConnection.cmd.Parameters.AddWithValue("@ContactModeId", contactMode.ContactModeId);
            dbConnection.cmd.Parameters.AddWithValue("@ContactModeName", contactMode.ContactModeName);
            dbConnection.cmd.Parameters.AddWithValue("@IsActive", contactMode.IsActive);
            dbConnection.cmd.Parameters.AddWithValue("@ContactAlias", contactMode.ContactAlias);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }


        public List<ContactMode> GetAllContactMode(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CONTACT_MODE ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ContactMode>(dbConnection.dr);
        }

        public ContactMode GetContactModeById(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM CONTACT_MODE WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ContactMode>(dbConnection.dr);

        }
    }
}

