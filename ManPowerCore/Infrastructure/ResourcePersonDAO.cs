using ManPowerCore.Common;
using ManPowerCore.Domain;
using ManPowerCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManPowerCore.Infrastructure
{
    public interface ResourcePersonDAO
    {
        int SaveResourcePerson(ResourcePerson resourcePerson, DBConnection dbConnection);

        List<ResourcePerson> GetAllResourcePerson(DBConnection dbConnection);
    }

    public class ResourcePersonDAOImpl : ResourcePersonDAO
    {
        public int getMaxResourcePersonId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM RESOURCE_PERSON";
            int id = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (id == 0)
            {
                id = 1;
            }
            else
            {
                id += 1;
            }
            return id;
        }

        public int SaveResourcePerson(ResourcePerson resourcePerson, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxResourcePersonId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO RESOURCE_PERSON(RESOURCE_PERSON_TYPE,NIC,NAME,DESIGNATION,WORK_PLACE,QUALIFICATIONS,ADDRESS,CONTACT_NUMBER,WHATSAPP_NUMBER,EMAIL) " +
            "VALUES(@ResourcePersonType,@NIC,@Name,@Designation,@WorkPlace,@Qualifications,@Address,@ContactNumber,@WhatsappNumber,@Email) ";

            dbConnection.cmd.Parameters.AddWithValue("@ResourcePersonType", resourcePerson.ResourcePersonType);
            dbConnection.cmd.Parameters.AddWithValue("@NIC", resourcePerson.NIC);
            dbConnection.cmd.Parameters.AddWithValue("@Name", resourcePerson.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Designation", resourcePerson.Designation);
            dbConnection.cmd.Parameters.AddWithValue("@WorkPlace", resourcePerson.WorkPlace);
            dbConnection.cmd.Parameters.AddWithValue("@Qualifications", resourcePerson.Qualifications);
            dbConnection.cmd.Parameters.AddWithValue("@Address", resourcePerson.Address);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", resourcePerson.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", resourcePerson.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Email", resourcePerson.Email);

            dbConnection.cmd.ExecuteNonQuery();
            return 1;
        }

        public List<ResourcePerson> GetAllResourcePerson(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM RESOURCE_PERSON ORDER BY NAME ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ResourcePerson>(dbConnection.dr);

        }

    }
}

