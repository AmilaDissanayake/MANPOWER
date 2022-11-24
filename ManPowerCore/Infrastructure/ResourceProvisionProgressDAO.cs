using ManPowerCore.Common;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManPowerCore.Infrastructure
{
    public interface ResourceProvisionProgressDAO
    {

        int SaveResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress, DBConnection dbConnection);
        int UpdateResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress, DBConnection dbConnection);
        List<ResourceProvisionProgress> GetAllResourceProvisionProgress(DBConnection dbConnection);
        ResourceProvisionProgress GetResourceProvisionProgress(int id, DBConnection dbConnection);
        List<ResourceProvisionProgress> GetAllResourceProvisionProgressFilterDetails(string runInstitute, string runYear, DBConnection dbConnection);
        List<ResourceProvisionProgress> ValidateResourceProvisionProgress(string runInstitute, string runYear, string runDS, DBConnection dbConnection);



    }

    public class ResourceProvisionProgressDAOImpl : ResourceProvisionProgressDAO
    {
        public int getMaxResourceProvisionProgressId(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT ISNULL(MAX(ID),0) FROM RESOURCE_PROVISION_PROGRESS";
            int orderId = Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
            if (orderId == 0)
            {
                orderId = 1;
            }
            else
            {
                orderId += 1;
            }


            return orderId;
        }

        public int SaveResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            int id = getMaxResourceProvisionProgressId(dbConnection);

            dbConnection.cmd.CommandType = System.Data.CommandType.Text;
            dbConnection.cmd.CommandText = "INSERT INTO RESOURCE_PROVISION_PROGRESS(DATE,NAME_OF_THE_PROGRAM,INSTITUTE,ADDRESS,SUBJECT_AREA_OR_TOPIC," +
                                            "NAME_OF_THE_ORGANIZATION,ORGANIZATION_TYPE,DS,ORGANIZATION_ADDRESS,NAME,POSITION,CONTACT_NUMBER," +
                                            "WHATSAPP_NUMBER,EMAIL,DETAILS_OF_THE_PROVIDED_SERVICE) " +

                                 "VALUES(@Date,@NameOfTheProgram,@Institute,@Address,@SubjectAreaOrTopic,@NameOfTheOrganization,@OrganizationType,@Ds,@OrganizationAddress,@Name,@Position,@ContactNumber,@WhatsappNumber,@Email,@DetailsOfTheProvidedService) ";


            //dbConnection.cmd.Parameters.AddWithValue("@id", id);
            dbConnection.cmd.Parameters.AddWithValue("@Date", resourceProvisionProgress.Date);
            dbConnection.cmd.Parameters.AddWithValue("@NameOfTheProgram", resourceProvisionProgress.NameOfTheProgram);
            dbConnection.cmd.Parameters.AddWithValue("@Institute", resourceProvisionProgress.Institute);
            dbConnection.cmd.Parameters.AddWithValue("@Address", resourceProvisionProgress.Address);
            dbConnection.cmd.Parameters.AddWithValue("@SubjectAreaOrTopic", resourceProvisionProgress.SubjectAreaOrTopic);
            dbConnection.cmd.Parameters.AddWithValue("@NameOfTheOrganization", resourceProvisionProgress.NameOfTheOrganization);
            dbConnection.cmd.Parameters.AddWithValue("@OrganizationType", resourceProvisionProgress.OrganizationType);
            dbConnection.cmd.Parameters.AddWithValue("@Ds", resourceProvisionProgress.Ds);
            dbConnection.cmd.Parameters.AddWithValue("@OrganizationAddress", resourceProvisionProgress.OrganizationAddress);
            dbConnection.cmd.Parameters.AddWithValue("@Name", resourceProvisionProgress.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Position", resourceProvisionProgress.Position);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", resourceProvisionProgress.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", resourceProvisionProgress.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Email", resourceProvisionProgress.Email);
            dbConnection.cmd.Parameters.AddWithValue("@DetailsOfTheProvidedService", resourceProvisionProgress.DetailsOfTheProvidedService);



            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int UpdateResourceProvisionProgress(ResourceProvisionProgress resourceProvisionProgress, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "UPDATE RESOURCE_PROVISION_PROGRESS SET DATE =@Date, NAME_OF_THE_PROGRAM=@NameOfTheProgram, INSTITUTE = @Institute," +
                " ADDRESS = @Address, SUBJECT_AREA_OR_TOPIC = @SubjectAreaOrTopic , NAME_OF_THE_ORGANIZATION = @NameOfTheOrganization,ORGANIZATION_TYPE = @OrganizationType, DS = @Ds," +
                " ORGANIZATION_ADDRESS = @OrganizationAddress, NAME = @Name, POSITION = @Position," +
                " CONTACT_NUMBER = @ContactNumber ,WHATSAPP_NUMBER = @WhatsappNumber, EMAIL=@Email, DETAILS_OF_THE_PROVIDED_SERVICE = @DetailsOfTheProvidedService WHARE ID = @ResourceProvisionProgressId";



            dbConnection.cmd.Parameters.AddWithValue("@ResourceProvisionProgressId", resourceProvisionProgress.ResourceProvisionProgressId);
            dbConnection.cmd.Parameters.AddWithValue("@Date", resourceProvisionProgress.Date);
            dbConnection.cmd.Parameters.AddWithValue("@NameOfTheProgram", resourceProvisionProgress.NameOfTheProgram);
            dbConnection.cmd.Parameters.AddWithValue("@Institute", resourceProvisionProgress.Institute);
            dbConnection.cmd.Parameters.AddWithValue("@Address", resourceProvisionProgress.Address);
            dbConnection.cmd.Parameters.AddWithValue("@SubjectAreaOrTopic", resourceProvisionProgress.SubjectAreaOrTopic);
            dbConnection.cmd.Parameters.AddWithValue("@NameOfTheOrganization", resourceProvisionProgress.NameOfTheOrganization);
            dbConnection.cmd.Parameters.AddWithValue("@OrganizationType", resourceProvisionProgress.OrganizationType);
            dbConnection.cmd.Parameters.AddWithValue("@Ds", resourceProvisionProgress.Ds);
            dbConnection.cmd.Parameters.AddWithValue("@OrganizationAddress", resourceProvisionProgress.OrganizationAddress);
            dbConnection.cmd.Parameters.AddWithValue("@Name", resourceProvisionProgress.Name);
            dbConnection.cmd.Parameters.AddWithValue("@Position", resourceProvisionProgress.Position);
            dbConnection.cmd.Parameters.AddWithValue("@ContactNumber", resourceProvisionProgress.ContactNumber);
            dbConnection.cmd.Parameters.AddWithValue("@WhatsappNumber", resourceProvisionProgress.WhatsappNumber);
            dbConnection.cmd.Parameters.AddWithValue("@Email", resourceProvisionProgress.Email);
            dbConnection.cmd.Parameters.AddWithValue("@DetailsOfTheProvidedService", resourceProvisionProgress.DetailsOfTheProvidedService);




            return dbConnection.cmd.ExecuteNonQuery();
        }


        public List<ResourceProvisionProgress> GetAllResourceProvisionProgress(DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM RESOURCE_PROVISION_PROGRESS ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ResourceProvisionProgress>(dbConnection.dr);

        }


        public List<ResourceProvisionProgress> GetAllResourceProvisionProgressFilterDetails(string runInstitute, string runYear, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM RESOURCE_PROVISION_PROGRESS  WHERE INSTITUTE = '" + runInstitute + "' and YEAR(DATE) = '" + runYear + "' ORDER BY ID ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ResourceProvisionProgress>(dbConnection.dr);
        }


        public List<ResourceProvisionProgress> ValidateResourceProvisionProgress(string runInstitute, string runYear, string runDS, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM RESOURCE_PROVISION_PROGRESS  WHERE INSTITUTE = '" + runInstitute + "' AND YEAR(DATE) = '" + runYear + "' OR DS = '" + runDS + "' ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ResourceProvisionProgress>(dbConnection.dr);
        }


        public ResourceProvisionProgress GetResourceProvisionProgress(int id, DBConnection dbConnection)
        {
            if (dbConnection.dr != null)
                dbConnection.dr.Close();

            dbConnection.cmd.CommandText = "SELECT * FROM RESOURCE_PROVISION_PROGRESS WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ResourceProvisionProgress>(dbConnection.dr);

        }


    }

}

